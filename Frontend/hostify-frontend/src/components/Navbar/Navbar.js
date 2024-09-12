import React, { useState, useEffect } from "react";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import Container from "react-bootstrap/Container";
import { Dropdown } from "react-bootstrap";
import { Link } from "react-router-dom";
import { PiUserBold } from "react-icons/pi";
import { IoBedOutline } from "react-icons/io5";
import { useAuth } from "../../contexts/AuthContext";

function NavBar() {
  const [expand, updateExpanded] = useState(false);
  const [navColour, updateNavbar] = useState(false);
  const { user, logout } = useAuth();

  useEffect(() => {
    function scrollHandler() {
      if (window.scrollY >= 20) {
        updateNavbar(true);
      } else {
        updateNavbar(false);
      }
    }

    window.addEventListener("scroll", scrollHandler);
    
    return () => window.removeEventListener("scroll", scrollHandler);
  }, []);

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
          onClick={() => updateExpanded(expand ? false : "expanded")}
        />
        <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className="ms-auto" defaultActiveKey="#home">
            {user ? (
              <Dropdown align="end">
                <Dropdown.Toggle
                  as={Nav.Link}
                  className="d-flex align-items-center"
                >
                  <PiUserBold style={{ marginBottom: "2px" }} /> {user.username}
                </Dropdown.Toggle>

                <Dropdown.Menu>
                  <Dropdown.Item as={Link} to="/profile">Profile</Dropdown.Item>
                  <Dropdown.Item as={Link} to="/settings">Settings</Dropdown.Item>
                  <Dropdown.Item onClick={() => {
                    logout();
                    updateExpanded(false);
                  }}>Logout</Dropdown.Item>
                </Dropdown.Menu>
              </Dropdown>
            ) : (
              <Nav.Item>
                <Nav.Link
                  as={Link}
                  to="/login"
                  onClick={() => updateExpanded(false)}
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
