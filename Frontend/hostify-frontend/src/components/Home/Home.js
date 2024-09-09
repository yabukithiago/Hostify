import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { Input } from "../Button/Input";
import { Button } from "../Button/Button";
import Preloader from "../Preloader/Preloader";
import { Container, Row, Col } from "react-bootstrap";
import { CardContent, CardFooter, CardHeader, CardTitle } from "../Card/Card";
import { FaMapMarkerAlt, FaSearch } from "react-icons/fa";
import { FaUsers } from "react-icons/fa6";

function Home() {
  const [featuredRooms, setFeaturedRooms] = useState([]);
  const [load, updateLoad] = useState(true);

  function shuffleArray(array) {
    for (let i = array.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [array[i], array[j]] = [array[j], array[i]];
    }
    return array;
  }

  useEffect(() => {
    async function fetchRooms() {
      try {
        const response = await fetch("https://localhost:7244/api/Quarto");
        const data = await response.json();
        const shuffledRooms = shuffleArray(data);
        setFeaturedRooms(shuffledRooms);
      } catch (error) {
        console.error("Error fetching rooms:", error);
      } finally {
        updateLoad(false);
      }
    }

    fetchRooms();
  }, []);

  if (load) {
    return <Preloader load={load} />;
  }

  return (
    <>
      <Container fluid className="home-about-section" id="about">
        <Row>
          <Col md={12} className="home-welcome">
            <h1>Welcome to Hostify</h1>
            <p>
              We help travelers find comfortable and affordable rooms in top
              destinations around the world.
            </p>
          </Col>
        </Row>
        <Row>
          <Col md={12} className="home-search">
            <Input
              type="text"
              placeholder="Where are you going?"
              className="form-control me-3"
              style={{ maxWidth: "300px" }}
            />
            <Button className="search-button btn btn-primary">
              <FaSearch />
              &nbsp; Search Rooms
            </Button>
          </Col>
        </Row>
      </Container>

      <h2>Featured Rooms</h2>

      <Container className="home-room-section">
        {featuredRooms.length > 0 ? (
          featuredRooms.map((room) => (
            <div className="room-card" key={room.idQuarto}>
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
                  <FaMapMarkerAlt className="h-4 w-4 mr-1" />
                  &nbsp;{room.quartoLocalizacao}
                </p>
              </CardContent>
              <CardFooter className="room-footer">
                <span className="text-lg font-bold">
                  ${room.quartoDiaria}/night
                </span>
                <Link to={`/room/${room.idQuarto}`}>
                  <Button className="btn btn-primary">View Details</Button>
                </Link>
              </CardFooter>
            </div>
          ))
        ) : (
          <p>No rooms available at the moment.</p>
        )}
      </Container>
    </>
  );
}

export default Home;
