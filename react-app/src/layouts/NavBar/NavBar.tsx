import { Link, useMatch } from "react-router-dom";
import React, { useState } from "react";

import "./NavBar.css";

const NavBar: React.FC = () => {
  const isHomePage = useMatch("/");

  return (
    <nav className="nav">
      <div className="nav-overlay"></div>
      <div className="nav-content">
        <div className="nav-logo">Giftlare</div>
        <ul className="nav-links">
          <li className="nav-link">
            <Link to="/">Home</Link>
          </li>
          <li className="nav-link">
            <Link to="/groups">Groups</Link>
          </li>
          <li className="nav-link">
            <Link to="/create">Create</Link>
          </li>
          <li className="nav-link">
            <Link to="/contact">Contact</Link>
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
