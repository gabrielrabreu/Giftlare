import { Link } from "react-router-dom";
import React from "react";

import "./NotFoundPage.css";

const NotFoundPage: React.FC = () => {
  return (
    <div className="not-found-container">
      <p className="error-code">ERROR 404</p>
      <p className="error-message">Oops! Page not found.</p>
      <p className="additional-text">
        Looks like the page you are looking for doesn't exist.
      </p>
      <Link to="/">
        <button className="redirect-button">Back to HomePage</button>
      </Link>
    </div>
  );
};

export default NotFoundPage;
