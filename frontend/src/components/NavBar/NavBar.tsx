import React, { useState, useEffect, useRef } from "react";
import { Link } from "react-router-dom";

import { faUser, faTimes } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import { useAuth } from "../../contexts/AuthContext";
import { translate } from "../../translate";

import "./NavBar.css";

const NavBar: React.FC = () => {
  const [isMenuOpen, setMenuOpen] = useState(false);
  const { user, logout } = useAuth();
  const menuRef = useRef<HTMLDivElement | null>(null);

  const toggleMenu = () => {
    setMenuOpen(!isMenuOpen);
  };

  const closeMenu = () => {
    setMenuOpen(false);
  };

  useEffect(() => {
    const handleClickOutside = (event: Event) => {
      if (menuRef.current && !menuRef.current.contains(event.target as Node)) {
        closeMenu();
      }
    };

    document.addEventListener("click", handleClickOutside);

    return () => {
      document.removeEventListener("click", handleClickOutside);
    };
  }, []);

  return (
    <nav className="navbar">
      <div className="logo">Logo</div>
      <ul className="nav-list">
        <li>
          <Link to="/">{translate("navbar.home")}</Link>
          <Link to="/exchanges">{translate("navbar.exchange")}</Link>
        </li>
      </ul>
      <div className="user-icon" onClick={toggleMenu} ref={menuRef}>
        <FontAwesomeIcon icon={faUser} />
        {isMenuOpen && (
          <div className="user-menu">
            <div className="user-info">
              <FontAwesomeIcon icon={faUser} />
              <div className="user-details">
                <p>{user?.name}</p>
                <p>{user?.email}</p>
              </div>
            </div>
            <hr className="divider" />
            <ul className="user-links">
              <li>
                <span onClick={logout}>{translate("navbar.logout")}</span>
              </li>
            </ul>
            <button className="close-btn" onClick={closeMenu}>
              <FontAwesomeIcon icon={faTimes} />
            </button>
          </div>
        )}
      </div>
    </nav>
  );
};

export default NavBar;
