import React from "react";
import { Container, Row, Col } from "react-bootstrap";

function Footer() {
  let date = new Date();
  let year = date.getFullYear();
  return (
    <Container fluid className="footer">
      <Row>
        <Col md="4" className="footer-copywright">
          <h3>Designed and Developed by Thiago Yabuki and Gabriel Jablonski</h3>
          <Col classname="footer-body">
            <br />
            <div>
              <h3 className="text-lg font-semibold mb-4">Quick Links</h3>
              <ul className="footer-icons">
                <li className="footer-routes">
                  <a
                    href="/"
                    className="text-white text-decoration-none"
                    target="_blank"
                    rel="noopener noreferrer"
                  >
                    {" "}
                    Home{" "}
                  </a>
                </li>
                <li className="footer-routes">
                  <a
                    href="/"
                    className="text-white text-decoration-none"
                    target="_blank"
                    rel="noopener noreferrer"
                  >
                    {" "}
                    Rooms{" "}
                  </a>
                </li>
                <li className="footer-routes">
                  <a
                    href="/"
                    className="text-white text-decoration-none"
                    target="_blank"
                    rel="noopener noreferrer"
                  >
                    {" "}
                    About{" "}
                  </a>
                </li>
              </ul>
            </div>
          </Col>
        </Col>
        <Col md="4" className="footer-copywright">
          <h3>Copyright © {year}</h3>
        </Col>
        <Col md="4" className="footer-body">
          <div>
            <h3 className="text-lg font-semibold mb-4">Contact Us</h3>
            <p className="text-gray-400">endereço</p>
            <p className="text-gray-400">Email: info@hostify.com</p>
            <p className="text-gray-400">Phone: (+351) 000 000 000</p>
          </div>
        </Col>
      </Row>
    </Container>
  );
}

export default Footer;
