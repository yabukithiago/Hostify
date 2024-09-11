import React, { useState } from "react";
import { Form, Button } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

const SignUpHospede = ({ onSignUp }) => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
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
        navigate("/login");
      } else {
        console.error("Sign Up error:", responseText);
      }
    } catch (error) {
      console.error("Unexpected error:", error);
    }
  };

  return (
    <div>
      <h2>Sign Up as Hospede</h2>
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
