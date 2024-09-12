import { FaUser, FaPhoneAlt } from "react-icons/fa";
import { IoIosMail } from "react-icons/io";
import { Input } from "../Button/Input";
import { Button } from "../Button/Button";
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
                />
              </div>
              <div className="flex items-center space-x-4">
                <IoIosMail className="mb-2 text-gray-500" />
                <Form.Control
                  type="text"
                  placeholder="Email"
                  className="mb-2"
                />
              </div>
              <div className="flex items-center space-x-4">
                <FaPhoneAlt className="mb-2 text-gray-500" />
                <Form.Control
                  type="text"
                  placeholder="Phone"
                  className="mb-2"
                />
              </div>
            </CardBody>
            <CardFooter>
            <Button
                variant="primary"
                // onClick={handleEdit}
                // Linkar com o PUT da API
                className="search-button btn btn-primary"
              >
                Save changes
              </Button>
            </CardFooter>
          </Card>
          <br />
          <Card>
            <CardHeader>
              <CardTitle>Histórico de Reservas</CardTitle>
              <CardBody>Suas últimas reservas</CardBody>
            </CardHeader>
            <CardBody>
              <ul className="space-y-2">
                {/* Linkar com a API para mostrar as reservas do usuário */}
              </ul>
            </CardBody>
            <CardFooter>
            <Button
                variant="primary"
                // onClick={handleSeeAllReservations}
                className="search-button btn btn-primary"
              >
                All Reservations
              </Button>
            </CardFooter>
          </Card>
        </div>
      </Container>
    </>
  );
}
