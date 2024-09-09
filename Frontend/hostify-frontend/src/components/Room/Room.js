import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { Container, Row, Col, Button } from 'react-bootstrap';
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from '../Card/Card';
import { FaMapMarkedAlt, FaUsers, FaPhone, FaEnvelope } from 'react-icons/fa';

function Room() {
  const { id } = useParams();
  const [room, setRoom] = useState(null);
  const [load, setLoad] = useState(true);

  useEffect(() => {
    async function fetchRoom() {
      try {
        const response = await fetch(`https://localhost:7244/api/Quarto/${id}`);
        const data = await response.json();
        setRoom(data);
      } catch (error) {
        console.error("Error fetching room details:", error);
      } finally {
        setLoad(false);
      }
    }

    fetchRoom();
  }, [id]);

  if (load) {
    return <p>Loading...</p>;
  }

  if (!room) {
    return <p>Room not found.</p>;
  }

  return (
    <Container>
      <Row>
        <Col md={12}>
          <Card>
            <CardHeader>
              <img
                src={`https://localhost:7244${room.quartoImagem}`}
                alt={room.title}
                className="room-image"
              />
            </CardHeader>
            <CardContent className="room-content">
              <CardTitle>{room.quartoTipo}</CardTitle>
              <p className="text-gray-600">
                <FaUsers className="h-4 w-4 mr-1" /> &nbsp;
                {room.quartoCapacidade}
              </p>
              <p className="text-gray-600">{room.quartoDescricao}</p>
              <p className="text-gray-600 flex items-center mt-2">
                <FaMapMarkedAlt className="h-4 w-4 mr-1" />
                &nbsp;{room.quartoLocalizacao}
              </p>
              <p className="text-gray-600">
                <FaPhone className="h-4 w-4 mr-1" />
                &nbsp;{room.contactNumber}
              </p>
              <p className="text-gray-600">
                <FaEnvelope className="h-4 w-4 mr-1" />
                &nbsp;{room.contactEmail}
              </p>
              {/* <Row className="mt-4">
                {room.additionalImages.map((image, index) => (
                  <Col key={index} md={4}>
                    <img
                      src={`https://localhost:7244${image}`}
                      alt={`Additional ${index + 1}`}
                      className="room-image additional-image"
                    />
                  </Col>
                ))}
              </Row> */}
            </CardContent>
            <CardFooter className="room-footer">
              <span className="text-lg font-bold">
                ${room.quartoDiaria}/night
              </span>
              <Button className="btn btn-primary">Book Now</Button>
            </CardFooter>
          </Card>
        </Col>
        <Col md={4}>
          <div className="room-map">
            {/* adicionar informações adicionais */}
          </div>
        </Col>
      </Row>
    </Container>
  );
}

export default Room;
