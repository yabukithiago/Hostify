import React, { useState } from "react";
import { Form, Button, Alert } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

const SignUpHospede = ({ onSignUp }) => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [errorMessage, setErrorMessage] = useState("");
  const [name, setName] = useState("");
  const navigate = useNavigate();
  const handleSubmit = async () => {
    try {
      const response = await fetch("https://localhost:7244/api/Hospede", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          idUtilizador: 0,
          usernameUtilizador: username,
          passwordUtilizador: password,
          nameUtilizador: name,
          typeUtilizador: "Hospede",
        }),
      });

      const responseText = await response.text();

      if (response.ok) {
        const data = JSON.parse(responseText);
        console.log("Sign Up successful:", data);
        setErrorMessage("");
        navigate("/login");
      } else if (response.status === 409) {
        setErrorMessage("Username already exists. Please choose another one.");
      } else {
        setErrorMessage("Sign Up failed. Please try again.");
        console.error("Sign Up error:", responseText);
      }
    } catch (error) {
      setErrorMessage("Unexpected error occurred. Please try again."); // Exibe mensagem de erro inesperado
      console.error("Unexpected error:", error);
    }
  };

  return (
    <div>
      <h2>Sign Up as Hospede</h2>
      {errorMessage && <Alert variant="danger">{errorMessage}</Alert>}
      <Form>
        <Form.Group controlId="formName" className="mb-3">
          <Form.Control
            type="text"
            placeholder="Name"
            value={name}
            onChange={(e) => setName(e.target.value)}
            className="mb-2"
          />
        </Form.Group>
        <Form.Group controlId="formUsername" className="mb-3">
          <Form.Control
            type="text"
            placeholder="Username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            className="mb-2"
          />
        </Form.Group>
        <Form.Group controlId="formPassword" className="mb-4">
          <Form.Control
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </Form.Group>
        <Button variant="primary" onClick={handleSubmit} className="w-100">
          Sign Up
        </Button>
      </Form>
    </div>
  );
};

export default SignUpHospede;
