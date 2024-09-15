import React, { useState, useEffect } from "react";
import { Nav, Navbar, Dropdown, Container } from "react-bootstrap";
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
                  <Dropdown.Item as={Link} to="/profile">
                    Profile
                  </Dropdown.Item>
                  {userType === "Hospede" ? (
                    <Dropdown.Item as={Link} to="/reservation">
                      Reservations
                    </Dropdown.Item>
                  ) : (
                    <Dropdown.Item as={Link} to="/rooms">
                      Manage Rooms
                    </Dropdown.Item>
                  )}
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
