import React, { useState, useEffect } from "react";
import Login from "./components/Login/Login";
import Footer from "./components/Footer/Footer";
import Scroll from "./components/Scroll/Scroll";
import Search from "./components/Search/Search";
import Home from "./components/Home/Home";
import Room from "./components/Room/Room";
import Navbar from "./components/Navbar/Navbar";
import Profile from "./components/Profile/Profile";
import SignUpHospede from "./components/Login/SignUpHospede";
import SignUpHotel from "./components/Login/SignUpHotel";
import { AuthProvider } from "./contexts/AuthContext";
import {
  BrowserRouter as Router,
  Route,
  Routes,
  Navigate,
} from "react-router-dom";
import "./style.css";
import "./index.css";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";

function App() {
  const [load, upadateLoad] = useState(true);

  useEffect(() => {
    const timer = setTimeout(() => {
      upadateLoad(false);
    }, 1200);

    return () => clearTimeout(timer);
  }, []);

  return (
    <AuthProvider>
      <Router>
        <div className="App" id={load ? "no-scroll" : "scroll"}>
          <Navbar />
          <Scroll />
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="*" element={<Navigate to="/" />} />
            <Route path="/login" element={<Login />} />
            <Route path="/signuphospede" element={<SignUpHospede />} />
            <Route path="/signuphotel" element={<SignUpHotel />} />
            <Route path="/room/:id" element={<Room />} />
            <Route path="/search" element={<Search />} />
            <Route path="/profile" element={<Profile />} />
          </Routes>
          <Footer />
        </div>
      </Router>
    </AuthProvider>
  );
}

export default App;
