import React, { useState } from "react";
import { Container, Button, Form } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";

const Login = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();
  const { login } = useAuth();

  const handleLogin = async () => {
    try {
      const response = await fetch("https://localhost:7244/api/Auth/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ username, password }),
      });

      if (response.ok) {
        const data = await response.json();
        console.log("Login successful:", data);
        login(data.userName);
        navigate("/dashboard");
      } else {
        const errorData = await response.json();
        console.error("Login error:", errorData.error);
      }
    } catch (error) {
      console.error("Unexpected error:", error);
    }
  };

  const handleSignUp = async (userType) => {
    try {
      const apiEndpoint = userType === 'Hospede' ? '/api/Hospede' : '/api/Hotel';
  
      const response = await fetch(apiEndpoint, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ username, password }),
      });
  
      if (response.ok) {
        const data = await response.json();
        console.log('Sign Up successful:', data);
        login();
        navigate("/home");
      } else {
        const errorData = await response.json();
        console.error('Sign Up error:', errorData.error);
      }
    } catch (error) {
      console.error('Unexpected error:', error);
    }
  };

  return (
    <Container className="login-container d-flex justify-content-center align-items-center vh-100">
      <div className="login-form text-center p-4 bg-light rounded shadow">
        <h1 className="mb-4">Login</h1>
        <Form>
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
            onClick={handleLogin}
            className="w-100 mb-3"
          >
            Login
          </Button>
          <div className="d-flex justify-content-between">
            <Button
              variant="secondary"
              onClick={() => handleSignUp("Hospede")}
              className="w-45"
            >
              Sign Up as Hospede
            </Button>
            <Button
              variant="secondary"
              onClick={() => handleSignUp("Hotel")}
              className="w-45"
            >
              Sign Up as Hotel
            </Button>
          </div>
        </Form>
      </div>
    </Container>
  );
};

export default Login;
