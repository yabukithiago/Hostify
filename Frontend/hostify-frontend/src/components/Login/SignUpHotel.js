import React, { useState } from "react";
import { Form, Button } from "react-bootstrap";

const SignUpHotel = ({ onSignUp }) => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [name, setName] = useState("");

  const handleSubmit = () => {
    const userId = 0;
    onSignUp({ idUtilizador: userId, usernameUtilizador: username, passwordUtilizador: password, nameUtilizador: name, typeUtilizador: "Hotel" });
  };

  return (
    <div>
      <h2>Sign Up as Hotel</h2>
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
        <Button
          variant="primary"
          onClick={handleSubmit}
          className="w-100"
        >
          Sign Up
        </Button>
      </Form>
    </div>
  );
};

export default SignUpHotel;
