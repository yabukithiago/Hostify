import { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import { Container, Row, Col, Card, Button } from "react-bootstrap";
import { FaMapMarkedAlt, FaUsers, FaList } from "react-icons/fa";

function Search() {
  const [results, setResults] = useState([]);
  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);
  
  const query = queryParams.get("query")?.toLowerCase();
  const type = queryParams.get("type")?.toLowerCase();
  const maxPrice = queryParams.get("maxPrice");
  const capacity = queryParams.get("capacity");
  const searchLocation = queryParams.get("location")?.toLowerCase();

  useEffect(() => {
    async function fetchResults() {
      try {
        const url = new URL("https://localhost:7244/api/Quarto/search");
        if (query) url.searchParams.append("query", query);
        if (type) url.searchParams.append("type", type);
        if (maxPrice) url.searchParams.append("maxPrice", maxPrice);
        if (capacity) url.searchParams.append("capacity", capacity);
        if (searchLocation) url.searchParams.append("location", searchLocation);

        const response = await fetch(url.toString());
        const data = await response.json();

        const filteredData = data.filter((room) => {
          const roomType = room.quartoTipo?.toLowerCase();
          const roomLocation = room.quartoLocalizacao?.toLowerCase();
          const roomDescription = room.quartoDescricao?.toLowerCase();
          const searchTerm = query?.toLowerCase();

          return (
            (!searchTerm || roomType.includes(searchTerm) || roomLocation.includes(searchTerm) || roomDescription.includes(searchTerm)) &&
            (!type || roomType.includes(type)) &&
            (!searchLocation || roomLocation.includes(searchLocation)) &&
            (!maxPrice || room.quartoDiaria <= maxPrice) && (!capacity || room.quartoCapacidade <= capacity)
          );
        });

        setResults(filteredData);
      } catch (error) {
        console.error("Error fetching search results:", error);
      }
    }

    fetchResults();
  }, [query, type, searchLocation, maxPrice, capacity]);

  return (
    <Container className="home-content">
      <h2>Search Results</h2>
      <Row>
        {results.length > 0 ? (
          results.map((room) => (
            <Col md={4} key={room.idQuarto}>
              <Card>
                <Card.Img variant="top" src={`https://localhost:7244${room.quartoImagem}`} />
                <Card.Body>
                  <Card.Title>{room.quartoTipo}</Card.Title>
                  <Card.Text>
                    <FaUsers /> {room.quartoCapacidade}
                    <br />
                    <FaList /> {room.quartoDescricao}
                    <br />
                    <FaMapMarkedAlt /> {room.quartoLocalizacao}
                  </Card.Text>
                  <Button variant="primary" href={`/room/${room.idQuarto}`}>View Details</Button>
                </Card.Body>
              </Card>
            </Col>
          ))
        ) : (
          <p>No rooms found.</p>
        )}
      </Row>
    </Container>
  );
}

export default Search;
