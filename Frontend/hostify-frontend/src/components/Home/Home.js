import { useState, useEffect } from "react";
import { Input } from "../Button/Input";
import { Button } from "../Button/Button";
import Preloader from "../Preloader/Preloader";
import { Container, Row, Col } from "react-bootstrap";
import {
  Card,
  CardContent,
  CardFooter,
  CardHeader,
  CardTitle,
} from "../Card/Card";
import { FaMapMarkedAlt, FaSearch } from "react-icons/fa";

function Home() {
  const [featuredRooms, setFeaturedRooms] = useState([]);
  const [load, upadateLoad] = useState(true);

  useEffect(() => {
    async function fetchRooms() {
      try {
        const response = await fetch("https://localhost:7244/api/Quartos");
        const data = await response.json();
        setFeaturedRooms(data);
      } catch (error) {
        console.error("Error fetching rooms:", error);
      } finally {
        upadateLoad(false);
      }
    }

    fetchRooms();
  }, []);

  if (load) {
    return <Preloader load={load} />;
  }

  return (
    <Container fluid className="home-about-section" id="about">
      <Row>
        <Col md={12} className="home-about-description">
          <h1>Welcome to Hostify</h1>
          <p>
            We help travelers find comfortable and affordable rooms in top
            destinations around the world.
          </p>
        </Col>
      </Row>
      <Row>
        <Col md={12} className=""></Col>
      </Row>
      <Row>
        <Col md={12} className="home-about-social">
          <div className="flex flex-col md:flex-row gap-4">
            <Input
              type="text"
              placeholder="Where are you going?"
              className="flex-grow"
            />
            <Button className="w-full md:w-auto">
              <FaSearch className="h-4 w-4 mr-2" />
              Search Rooms
            </Button>
          </div>
        </Col>
      </Row>
      <Row>
        <Col md={8} className="home-about-description">
          <div className="home-about-body">
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
              {featuredRooms.map((room) => (
                <Card key={room.id}>
                  <CardHeader className="p-0">
                    <img
                      src={room.image}
                      alt={room.title}
                      className="w-full h-48 object-cover"
                    />
                  </CardHeader>
                  <CardContent className="p-4">
                    <CardTitle>{room.title}</CardTitle>
                    <p className="text-gray-600 flex items-center mt-2">
                      <FaMapMarkedAlt className="h-4 w-4 mr-1" />
                      {room.location}
                    </p>
                  </CardContent>
                  <CardFooter className="p-4 flex items-center justify-between">
                    <span className="text-lg font-bold">
                      ${room.price}/night
                    </span>
                    <Button variant="outline">View Details</Button>
                  </CardFooter>
                </Card>
              ))}
            </div>
          </div>
        </Col>
      </Row>
    </Container>
  );
}

export default Home;
