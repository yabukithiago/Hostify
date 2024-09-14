import React, { useState } from "react";
import { Container, Form, Button, Alert } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

const SignUpHospede = ({ onSignUp }) => {
  const [email, setEmail] = useState("");
  const [phone, setPhone] = useState("");
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [name, setName] = useState("");
  const [errorMessage, setErrorMessage] = useState("");

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
          emailUtilizador: email,
          usernameUtilizador: username,
          passwordUtilizador: password,
          nameUtilizador: name,
          phoneUtilizador: phone,
          typeUtilizador: "Hospede",
        }),
      });

      const responseText = await response.text();

      if (response.ok) {
        const data = JSON.parse(responseText);
        console.log("Sign Up successful:", data);
        navigate("/login");
        setErrorMessage("");
      } else if (response.status === 409) {
        setErrorMessage("Username already exists. Please choose another one.");
      } else {
        setErrorMessage("Sign Up failed. Please try again.");
        console.error("Sign Up error:", responseText);
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
          <h2>Sign Up as Hospede</h2>
          {errorMessage && <Alert variant="danger">{errorMessage}</Alert>}
          <Form>
            <Form.Group controlId="formName" className="mb-3">
              <Form.Group controlId="formEmail" className="mb-3">
                <Form.Control
                  type="text"
                  placeholder="Email"
                  value={email}
                  onChange={(e) => setEmail(e.target.value)}
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
              <Form.Control
                type="text"
                placeholder="Name"
                value={name}
                onChange={(e) => setName(e.target.value)}
                className="mb-2"
              />
            </Form.Group>
            <Form.Group controlId="formPhone" className="mb-4">
              <Form.Control
                type="text"
                placeholder="Phone"
                value={phone}
                onChange={(e) => setPhone(e.target.value)}
              />
            </Form.Group>
            <Button variant="primary" onClick={handleSubmit} className="w-100">
              Sign Up
            </Button>
          </Form>
        </div>
      </Container>
    </div>
  );
};

export default SignUpHospede;
