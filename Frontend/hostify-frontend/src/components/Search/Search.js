import { useState, useEffect } from 'react';
import { useLocation } from 'react-router-dom';
import { Container, Row, Col, Card, Button } from 'react-bootstrap';
import { FaMapMarkedAlt, FaUsers } from 'react-icons/fa';

function Search() {
  const [results, setResults] = useState([]);
  const [loading, setLoading] = useState(true);
  const query = new URLSearchParams(useLocation().search).get('query');

  useEffect(() => {
    async function fetchResults() {
      try {
        const response = await fetch(`https://localhost:7244/api/Quarto/search?query=${encodeURIComponent(query)}`);
        const data = await response.json();
        setResults(data);
      } catch (error) {
        console.error("Error fetching search results:", error);
      } finally {
        setLoading(false);
      }
    }

    fetchResults();
  }, [query]);

  if (loading) {
    return <p>Loading...</p>;
  }

  return (
    <Container>
      <h2>Search Results for "{query}"</h2>
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
