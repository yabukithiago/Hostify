import React, { useState } from "react";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import Container from "react-bootstrap/Container";
import { Link } from "react-router-dom";
import { PiUserBold } from "react-icons/pi";
import { IoBedOutline } from "react-icons/io5";
import { useAuth } from "../../contexts/AuthContext";

function NavBar() {
  const [expand, updateExpanded] = useState(false);
  const [navColour, updateNavbar] = useState(false);
  const { isAuthenticated, userName, logout } = useAuth();

  function scrollHandler() {
    if (window.scrollY >= 20) {
      updateNavbar(true);
    } else {
      updateNavbar(false);
    }
  }

  window.addEventListener("scroll", scrollHandler);

  return (
    <Navbar
      expanded={expand}
      fixed="top"
      expand="md"
      className={navColour ? "sticky" : "navbar"}
    >
      <Container>
        <Navbar.Brand href="/">
          <IoBedOutline style={{ marginBottom: "2px", color: "#0051ff" }} />{" "}
          Hostify
        </Navbar.Brand>
        <Navbar.Toggle
          aria-controls="responsive-navbar-nav"
          onClick={() => {
            updateExpanded(expand ? false : "expanded");
          }}
        >
          <span></span>
          <span></span>
          <span></span>
        </Navbar.Toggle>
        <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className="ms-auto" defaultActiveKey="#home">
            {isAuthenticated ? (
              <>
                <Nav.Item>
                  <Nav.Link
                    as={Link}
                    to="/profile"
                    onAbort={() => updateExpanded(false)}
                  >
                    <PiUserBold style={{ marginBottom: "2px" }} />
                    {userName}
                  </Nav.Link>
                </Nav.Item>
                <Nav.Item>
                  <Nav.Link onClick={logout}>Logout</Nav.Link>
                </Nav.Item>
              </>
            ) : (
              <Nav.Item>
                <Nav.Link
                  as={Link}
                  to="/login"
                  onAbort={() => updateExpanded(false)}
                >
                  <PiUserBold style={{ marginBottom: "2px" }} /> Login
                </Nav.Link>
              </Nav.Item>
            )}
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default NavBar;