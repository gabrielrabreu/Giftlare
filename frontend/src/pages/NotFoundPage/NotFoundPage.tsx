import { useNavigate } from "react-router-dom";
import React from "react";

import "./NotFoundPage.css";

const NotFoundPage: React.FC = () => {
  const navigate = useNavigate();

  return (
    <div className="not-found-container">
      <div className="not-found-content">
        <p data-testid="error-code" className="error-code">
          ERROR 404
        </p>
        <p data-testid="error-message" className="error-message">
          Oops! Page not found.
        </p>
        <p data-testid="error-detail" className="error-detail">
          Looks like the page you are looking for doesn't exist.
        </p>
        <button
          data-testid="redirect-button"
          className="redirect-button"
          onClick={() => navigate("/")}
        >
          Back to HomePage
        </button>
      </div>
    </div>
  );
};

export default NotFoundPage;
