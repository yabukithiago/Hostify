import React, { useState, useEffect } from "react";
import Login from "./components/Login/Login";
import Footer from "./components/Footer/Footer";
import Scroll from "./components/Scroll/Scroll";
import Home from "./components/Home/Home";
import Room from "./components/Room/Room";
import Navbar from "./components/Navbar/Navbar";
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
    <Router>
      <div className="App" id={load ? "no-scroll" : "scroll"}>
        <Navbar />
        <Scroll />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="*" element={<Navigate to="/" />} />
          <Route path="/login" element={<Login />} />
          <Route path="/room/:id" element={<Room />} />
        </Routes>
        <Footer />
      </div>
    </Router>
  );
}

export default App;