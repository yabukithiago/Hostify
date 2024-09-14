import React from "react";
import { useState, useEffect } from "react";
import { FaUser, FaPhoneAlt } from "react-icons/fa";
import { IoIosMail } from "react-icons/io";
// import { Input } from "../Button/Input";
import { Button } from "../Button/Button";
import { useNavigate } from "react-router-dom";
import {
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  CardTitle,
  Container,
  Form,
} from "react-bootstrap";

export default function PerfilUsuario() {
  const navigate = useNavigate();
  const token = localStorage.getItem("authToken");
  const [newnameUtilizador, setNewNameUtilizador] = useState("");
  const [newemailUtilizador, setNewEmailUtilizador] = useState("");
  const [newphoneUtilizador, setNewPhoneUtilizador] = useState("");
  const [userId, setUserId] = useState(null);
  const [userType, setUserType] = useState(null);

  useEffect(() => {
    if (!token) {
      navigate("/login");
      return;
    }

    try {
      const decodedToken = JSON.parse(atob(token.split(".")[1]));
      console.log("Decoded token:", decodedToken);
      setUserId(decodedToken.role);
      setUserType(decodedToken.Type);
    } catch (e) {
      console.error("Error parsing token:", e);
      navigate("/login");
    }
  }, [token, navigate]);

  const handleEdit = async () => {
    if (!userId || !userType) {
      console.error("User ID or User Type is undefined.");
      return;
    }

    const apiEndpoint =
      userType === "Hospede"
        ? `https://localhost:7244/api/Hospede/${userId}`
        : `https://localhost:7244/api/Hotel/${userId}`;

        try {
          const currentUserResponse = await fetch(apiEndpoint, {
            method: "GET",
            headers: {
              "Content-Type": "application/json",
              Authorization: `Bearer ${token}`,
            },
          });
      
          if (!currentUserResponse.ok) {
            throw new Error("Failed to fetch current user details.");
          }
      
          const currentUser = await currentUserResponse.json();
      
          const response = await fetch(apiEndpoint, {
            method: "PUT",
            headers: {
              "Content-Type": "application/json",
              Authorization: `Bearer ${token}`,
            },
            body: JSON.stringify({
              idUtilizador: userId,
              usernameUtilizador: currentUser.usernameUtilizador,
              passwordUtilizador: currentUser.passwordUtilizador,
              nameUtilizador: newnameUtilizador,
              typeUtilizador: userType,
              emailUtilizador: newemailUtilizador,
              phoneUtilizador: newphoneUtilizador,
            }),
          });
      
          if (response.ok) {
            const data = await response.json();
            console.log("Usuario atualizado:", data);
            navigate("/home");
          } else {
            const errorData = await response.json();
            console.error("Erro na data", errorData.errors);
          }
        } catch (error) {
          console.error("Erro inesperado.", error);
          //Mesmo atualizando ele seta o erro
        }
      };

  return (
    <>
      <Container className="login-container d-flex justify-content-center align-items-center vh-100">
        <div className="login-form text-center p-4 bg-light rounded shadow">
          <h1 className="text-3xl font-bold mb-6">Gerenciar Perfil</h1>
          <Card>
            <CardHeader>
              <CardTitle>Informações Pessoais</CardTitle>
              <CardBody>Atualize suas informações de contato</CardBody>
            </CardHeader>
            <CardBody className="mb-3 space-y-4">
              <div className="flex items-center space-x-4">
                <FaUser className="mb-2 text-gray-500" />
                <Form.Control
                  type="text"
                  placeholder="Name"
                  className="mb-2"
                  value={newnameUtilizador}
                  onChange={(e) => setNewNameUtilizador(e.target.value)}
                />
              </div>
              <div className="flex items-center space-x-4">
                <IoIosMail className="mb-2 text-gray-500" />
                <Form.Control
                  type="text"
                  placeholder="Email"
                  className="mb-2"
                  value={newemailUtilizador}
                  onChange={(e) => setNewEmailUtilizador(e.target.value)}
                />
              </div>
              <div className="flex items-center space-x-4">
                <FaPhoneAlt className="mb-2 text-gray-500" />
                <Form.Control
                  type="text"
                  placeholder="Phone"
                  className="mb-2"
                  value={newphoneUtilizador}
                  onChange={(e) => setNewPhoneUtilizador(e.target.value)}
                />
              </div>
            </CardBody>
            <CardFooter>
              <Button
                variant="primary"
                onClick={handleEdit}
                className="search-button btn btn-primary"
              >
                Save changes
              </Button>
            </CardFooter>
          </Card>
        </div>
      </Container>
    </>
  );
}
