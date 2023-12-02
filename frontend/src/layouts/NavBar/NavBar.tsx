import { useMatch, useNavigate } from "react-router-dom";
import React from "react";

import { useAuth } from "../../contexts/AuthContext";

import "./NavBar.css";

const NavBar: React.FC = () => {
  const navigate = useNavigate();
  const { restrictedNavigate } = useAuth();

  const isHomePage = useMatch("/");

  return (
    <nav className="nav">
      <div className="nav-overlay"></div>
      <div className="nav-content">
        <div className="nav-logo">Giftlare</div>
        <ul className="nav-links">
          <li className="nav-link">
            <button onClick={() => navigate("/")}>Home</button>
          </li>
          <li className="nav-link">
            <button onClick={() => restrictedNavigate("/list-groups")}>
              Groups
            </button>
          </li>
          <li className="nav-link">
            <button onClick={() => restrictedNavigate("/create-group")}>
              Create
            </button>
          </li>
          <li className="nav-link">
            <button onClick={() => navigate("/contact")}>Contact</button>
          </li>
        </ul>
      </div>
      {isHomePage && (
        <div className="nav-description">
          <p className="nav-title">
            Experience the Joy of Gifting with Santa Secrets
          </p>
          <p className="nav-subtitle">Join us this Christmas</p>
        </div>
      )}
    </nav>
  );
};

export default NavBar;
