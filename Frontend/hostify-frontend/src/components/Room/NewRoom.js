import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { Container, Form, Button, Alert } from "react-bootstrap";

const NewRoom = ({ onSignUp }) => {
  const token = localStorage.getItem("authToken");
  const [userId, setUserId] = useState("");
  const [roomType, setRoomType] = useState("");
  const [description, setDescription] = useState("");
  const [capacity, setCapacity] = useState(0);
  const [price, setPrice] = useState(0);
  const [location, setLocation] = useState("");
  const [errorMessage, setErrorMessage] = useState("");
  const [image, setImage] = useState(null);
    const navigate = useNavigate();

  useEffect(() => {
    try {
      const decodedToken = JSON.parse(atob(token.split(".")[1]));
      setUserId(decodedToken.role);
    } catch (e) {
      console.error("Error parsing token:", e);
    }
  }, [token]);

  const handleSubmit = async () => {
    try {
      const response = await fetch("https://localhost:7244/api/Quarto", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          idQuarto: 0,
          idHotel: userId,
          quartoTipo: roomType,
          quartoDescricao: description,
          quartoCapacidade: capacity,
          quartoDiaria: price,
          quartoLocalizacao: location,
          quartoImagem: "",
          quartoDisponivel: true,
        }),
      });
  
      if (response.ok) {
        const data = await response.json();
        const roomId = data.idQuarto;
        if (image) {
          const formData = new FormData();
          formData.append("file", image);
  
          const imageResponse = await fetch(`https://localhost:7244/api/Quarto/${roomId}/upload-image`, {
            method: "POST",
            body: formData,
          });
  
          if (!imageResponse.ok) {
            const responseText = await imageResponse.text();
            setErrorMessage("Image upload failed. Please try again.");
            console.error("Error:", responseText);
          }
        }
  
        setErrorMessage("");
        navigate('/home');
      } else {
        const responseText = await response.text();
        setErrorMessage("Room creation failed. Please try again.");
        console.error("Error:", responseText);
      }
    } catch (error) {
      setErrorMessage("Unexpected error occurred. Please try again.");
      console.error("Unexpected error:", error);
    }
  };

  return (
    <div>
      <Container className="login-container d-flex justify-content-center align-items-center vh-100">
        <div className="login-form text-center p-4 bg-light rounded shadow">
          <h2>Create a New Room</h2>
          <Form>
            <Form.Group controlId="formRoomType" className="mb-3">
              <Form.Control
                type="text"
                placeholder="Room Type"
                value={roomType}
                onChange={(e) => setRoomType(e.target.value)}
                className="mb-2"
              />
            </Form.Group>
            <Form.Group controlId="formDescription" className="mb-3">
              <Form.Control
                type="text"
                placeholder="Description"
                value={description}
                onChange={(e) => setDescription(e.target.value)}
                className="mb-2"
              />
            </Form.Group>
            <Form.Group controlId="formCapacity" className="mb-3">
              <Form.Control
                type="number"
                placeholder="Capacity"
                value={capacity}
                onChange={(e) => setCapacity(Number(e.target.value))}
                className="mb-2"
              />
            </Form.Group>
            <Form.Group controlId="formPrice" className="mb-3">
              <Form.Control
                type="number"
                placeholder="Price per Night"
                value={price}
                onChange={(e) => setPrice(Number(e.target.value))}
                className="mb-2"
              />
            </Form.Group>
            <Form.Group controlId="formLocation" className="mb-3">
              <Form.Control
                type="text"
                placeholder="Location"
                value={location}
                onChange={(e) => setLocation(e.target.value)}
                className="mb-2"
              />
            </Form.Group>
            <Form.Group controlId="formImage" className="mb-3">
              <Form.Label>Upload Room Image</Form.Label>
              <Form.Control
                type="file"
                onChange={(e) => setImage(e.target.files[0])}
                className="mb-2"
              />
            </Form.Group>
            {errorMessage && <Alert variant="danger">{errorMessage}</Alert>}
            <Button variant="primary" onClick={handleSubmit} className="w-100">
              Create Room
            </Button>
          </Form>
        </div>
      </Container>
    </div>
  );
};

export default NewRoom;
