import { Link } from "react-router-dom";
import React from "react";

import "./Footer.css";

const Footer: React.FC = () => {
  return (
    <footer className="footer">
      <div className="footer-logo">Giftlare</div>
      <ul className="footer-links">
        <li className="footer-link">
          <Link to="/about">About</Link>
        </li>
        <li className="footer-link">
          <Link to="/faq">FAQ</Link>
        </li>
        <li className="footer-link">
          <Link to="/terms">Terms</Link>
        </li>
      </ul>
    </footer>
  );
};
export default Footer;
