import { useNavigate } from "react-router-dom";
import React from "react";

import "./Footer.css";

const Footer: React.FC = () => {
  const navigate = useNavigate();

  return (
    <footer className="footer">
      <div className="footer-logo">Giftlare</div>
      <ul className="footer-links">
        <li className="footer-link">
          <button onClick={() => navigate("/about")}>About</button>
        </li>
        <li className="footer-link">
          <button onClick={() => navigate("/faq")}>FAQ</button>
        </li>
        <li className="footer-link">
          <button onClick={() => navigate("/terms")}>Terms</button>
        </li>
      </ul>
    </footer>
  );
};
export default Footer;
