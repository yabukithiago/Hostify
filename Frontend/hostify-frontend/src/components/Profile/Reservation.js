import React from "react";
import { Button } from "../Button/Button";
import {
  Card,
  CardHeader,
  CardTitle,
  CardBody,
  CardFooter,
  Container,
} from "react-bootstrap";

export default function SeeReservations() {
  return (
    <Container className="login-container d-flex justify-content-center align-items-center vh-100">
      <div className="login-form text-center p-4 bg-light rounded shadow">
        <Card>
          <CardHeader>
            <CardTitle>Histórico de Reservas</CardTitle>
            <CardBody>Suas últimas reservas</CardBody>
          </CardHeader>
          <CardBody>
            <ul className="space-y-2">
              {/* Linkar com o get da API para mostrar as reservas do usuário */}
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
  );
}
