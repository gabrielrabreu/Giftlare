import React from "react";

import {
  faFacebookSquare,
  faTwitterSquare,
} from "@fortawesome/free-brands-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import { translate } from "../../translate";

import "./Footer.css";

const Footer: React.FC = () => {
  return (
    <footer className="footer">
      <div className="footer-content">
        <div className="social-icons">
          <h3>{translate("footer.follow-us")}</h3>
          <div className="social-links">
            <span>
              <FontAwesomeIcon icon={faFacebookSquare} />
            </span>
            <span>
              <FontAwesomeIcon icon={faTwitterSquare} />
            </span>
          </div>
        </div>
      </div>
      <div className="copyright">
        <p>&copy; {translate("footer.copyright")}</p>
      </div>
    </footer>
  );
};

export default Footer;
