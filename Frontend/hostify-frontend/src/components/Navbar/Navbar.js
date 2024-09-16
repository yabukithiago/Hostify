import React, { useState, useEffect } from "react";
import { Nav, Navbar, Dropdown, Container, NavItem } from "react-bootstrap";
import { PiUserBold } from "react-icons/pi";
import { IoBedOutline } from "react-icons/io5";
import { useAuth } from "../../contexts/AuthContext";
import { useNavigate, Link } from "react-router-dom";

function NavBar() {
  const token = localStorage.getItem("authToken");
  const [expand, updateExpanded] = useState(false);
  const [navColour, updateNavbar] = useState(false);
  const [userType, setUserType] = useState(null);
  const { user, logout } = useAuth();
  const navigate = useNavigate();

  useEffect(() => {
    try {
      const decodedToken = JSON.parse(atob(token.split(".")[1]));
      console.log("Decoded token:", decodedToken);
      setUserType(decodedToken.Type);
    } catch (e) {
      console.error("Error parsing token:", e);
    }
  }, [token, navigate]);

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

  const commonNav = (
    <>
      <Navbar.Brand href="/">
        <IoBedOutline style={{ marginBottom: "2px", color: "#0051ff" }} />{" "}
        Hostify
      </Navbar.Brand>
      <Navbar.Toggle
        aria-controls="responsive-navbar-nav"
        onClick={() => updateExpanded(expand ? false : "expanded")}
      />
    </>
  );

  const hospedeNav = (
    <Nav className="ms-auto" defaultActiveKey="#home">
      <NavItem>
        <Nav.Link as={Link} to="/explore">
          Explore
        </Nav.Link>
      </NavItem>
      <Dropdown align="end">
        <Dropdown.Toggle as={Nav.Link} className="d-flex align-items-center">
          <PiUserBold style={{ marginBottom: "2px" }} /> {user?.username}
        </Dropdown.Toggle>
        <Dropdown.Menu>
          <Dropdown.Item as={Link} to="/profile">
            Profile
          </Dropdown.Item>
          <Dropdown.Item as={Link} to="/reservation">
            Reservations
          </Dropdown.Item>
          <Dropdown.Item
            onClick={() => {
              logout();
              updateExpanded(false);
              navigate("/");
            }}
          >
            Logout
          </Dropdown.Item>
        </Dropdown.Menu>
      </Dropdown>
    </Nav>
  );

  const hotelNav = (
    <Nav className="ms-auto" defaultActiveKey="#home">
      <NavItem>
        <Nav.Link as={Link} to="/new-room">
          Add your room
        </Nav.Link>
      </NavItem>
      <Dropdown align="end">
        <Dropdown.Toggle as={Nav.Link} className="d-flex align-items-center">
          <PiUserBold style={{ marginBottom: "2px" }} /> {user?.username}
        </Dropdown.Toggle>
        <Dropdown.Menu>
          <Dropdown.Item as={Link} to="/profile">
            Profile
          </Dropdown.Item>
          <Dropdown.Item as={Link} to="/hotelrooms">
            Manage Rooms
          </Dropdown.Item>
          <Dropdown.Item
            onClick={() => {
              logout();
              updateExpanded(false);
              navigate("/");
            }}
          >
            Logout
          </Dropdown.Item>
        </Dropdown.Menu>
      </Dropdown>
    </Nav>
  );

  const guestNav = (
    <Nav className="ms-auto">
      <Nav.Item>
        <Nav.Link as={Link} to="/explore">
          Explore
        </Nav.Link>
      </Nav.Item>
      <Nav.Item>
        <Nav.Link
          as={Link}
          to="/login"
          onClick={() => updateExpanded(false)}
        >
          <PiUserBold style={{ marginBottom: "2px" }} /> Login
        </Nav.Link>
      </Nav.Item>
    </Nav>
  );

  return (
    <Navbar
      expanded={expand}
      fixed="top"
      expand="md"
      className={navColour ? "sticky" : "navbar"}
    >
      <Container>
        {commonNav}
        <Navbar.Collapse id="responsive-navbar-nav">
          {user ? (
            userType === "Hospede" ? hospedeNav : hotelNav
          ) : (
            guestNav
          )}
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default NavBar;
