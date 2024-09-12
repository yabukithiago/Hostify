import React, { useState } from "react";
import { Container, Button, Form, Alert } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";
import SignUpHospede from "./SignUpHospede";
import SignUpHotel from "./SignUpHotel";

const Login = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [showSignUp, setShowSignUp] = useState(null);
  const [errorMessage, setErrorMessage] = useState("");
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
        console.log(data.nameUtilizador); // não retorna o nome do utilizador
        setErrorMessage("");
        login(username);
        navigate("/home");
      } else {
        const errorData = await response.json();
        setErrorMessage(errorData.error || "Invalid username or password.");
        console.error("Login error:", errorData.error);
      }
    } catch (error) {
      setErrorMessage("Unexpected error occurred. Please try again.");
      console.error("Unexpected error:", error);
    }
  };

  const handleSignUp = async (userDetails) => {
    try {
      const {
        usernameUtilizador,
        passwordUtilizador,
        nameUtilizador,
        typeUtilizador,
      } = userDetails;
      const apiEndpoint =
        typeUtilizador === "Hospede" ? "/api/Hospede" : "/api/Hotel";

      const checkResponse = await fetch(
        `/api/CheckUserExists?username=${usernameUtilizador}`
      );
      const userExists = await checkResponse.json();

      if (userExists) {
        setErrorMessage("Username already exists");
        return;
      }

      const response = await fetch(apiEndpoint, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          idUtilizador: 0,
          usernameUtilizador,
          passwordUtilizador,
          nameUtilizador,
          typeUtilizador,
        }),
      });

      if (response.ok) {
        const data = await response.json();
        console.log("Sign Up successful:", data);
        setErrorMessage("");
        login();
        navigate("/home");
      } else {
        const errorData = await response.json();
        setErrorMessage(errorData.error || "Sign Up failed. Please try again.");
        console.error("Sign Up error:", errorData.error);
      }
    } catch (error) {
      setErrorMessage(
        "Unexpected error occurred during sign up. Please try again."
      );
      console.error("Unexpected error:", error);
    }
  };

  return (
    <Container className="login-container d-flex justify-content-center align-items-center vh-100">
      <div className="login-form text-center p-4 bg-light rounded shadow">
        {errorMessage && <Alert variant="danger">{errorMessage}</Alert>}{" "}
        {showSignUp ? (
          showSignUp === "Hospede" ? (
            <SignUpHospede onSignUp={handleSignUp} />
          ) : (
            <SignUpHotel onSignUp={handleSignUp} />
          )
        ) : (
          <>
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
                  onClick={() => setShowSignUp("Hospede")}
                  className="w-45"
                >
                  Sign Up as Hospede
                </Button>
                <Button
                  variant="secondary"
                  onClick={() => setShowSignUp("Hotel")}
                  className="w-45"
                >
                  Sign Up as Hotel
                </Button>
              </div>
            </Form>
          </>
        )}
      </div>
    </Container>
  );
};

export default Login;
