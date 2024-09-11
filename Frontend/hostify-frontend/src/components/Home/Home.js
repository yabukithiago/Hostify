import { useState, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import { Input } from "../Button/Input";
import { Button } from "../Button/Button";
import Preloader from "../Preloader/Preloader";
import { Container, Row, Col, Collapse, Form } from "react-bootstrap";
import { CardContent, CardFooter, CardHeader, CardTitle } from "../Card/Card";
import { FaMapMarkerAlt, FaSearch } from "react-icons/fa";
import { FaUsers } from "react-icons/fa6";

function Home() {
  const [filters, setFilters] = useState({
    roomType: "",
    maxPrice: "",
    location: "",
    capacity: "",
    searchTerm: ""
  });
  const [showFilters, setShowFilters] = useState(false);
  const [featuredRooms, setFeaturedRooms] = useState([]);
  const [load, updateLoad] = useState(true);
  const navigate = useNavigate();

  const handleFilterChange = (e) => {
    const { name, value } = e.target;
    setFilters(prevFilters => ({
      ...prevFilters,
      [name]: value
    }));
  };

  
  const handleSearch = () => {
    const params = new URLSearchParams();
    Object.keys(filters).forEach(key => {
      if (filters[key].trim()) params.append(key, filters[key].trim());
    });

    const searchUrl = `/search?${params.toString()}`;
    console.log("Navigating to:", searchUrl);
    navigate(searchUrl);
  };

  const handleKeyDown = (e) => {
    if (e.key === "Enter") {
      handleSearch();
    }
  };

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

        const filteredRooms = data.filter((room) => room.quartoDiaria <= 200);
        const shuffledRooms = shuffleArray(filteredRooms);

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
              name="location"
              value={filters.location}
              onChange={handleFilterChange}
              onKeyDown={handleKeyDown}
            />
            <Button
              onClick={() => setShowFilters(!showFilters)}
              className="btn btn-secondary"
            >
              Filters
            </Button>
            <Button
              onClick={handleSearch}
              className="search-button btn btn-primary"
            >
              <FaSearch />
              &nbsp; Search Rooms
            </Button>
          </Col>
        </Row>
        <Collapse in={showFilters}>
          <div className="filters-menu">
            <Row className="mt-3">
              <Col md={4}>
                <Form.Group>
                  <Form.Label>Room Type</Form.Label>
                  <Form.Control
                    type="text"
                    placeholder="Enter room type"
                    name="roomType"
                    value={filters.roomType}
                    onChange={handleFilterChange}
                    onKeyDown={handleKeyDown}
                  />
                </Form.Group>
              </Col>
              <Col md={4}>
                <Form.Group>
                  <Form.Label>Max Price per Night</Form.Label>
                  <Form.Control
                    type="number"
                    placeholder="Enter max price"
                    name="maxPrice"
                    value={filters.maxPrice}
                    onChange={handleFilterChange}
                    onKeyDown={handleKeyDown}
                  />
                </Form.Group>
              </Col>
              <Col md={4}>
                <Form.Group>
                  <Form.Label>Capacity</Form.Label>
                  <Form.Control
                    type="text"
                    placeholder="Enter capacity"
                    name="capacity"
                    value={filters.capacity}
                    onChange={handleFilterChange}
                    onKeyDown={handleKeyDown}
                  />
                </Form.Group>
              </Col>
            </Row>
          </div>
        </Collapse>
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
