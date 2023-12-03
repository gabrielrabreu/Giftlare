import React from "react";

import { useAuth } from "../../contexts/AuthContext";

import "./HomePage.css";

const HomePage: React.FC = () => {
  const { restrictedNavigate } = useAuth();

  return (
    <div className="home-container">
      <div className="section">
        <div className="section-column-left">
          <div className="section-text">
            <p data-testid="first-section-title" className="section-title">
              Connect with Loved Ones in Festive Groups
            </p>
            <p
              data-testid="first-section-description"
              className="section-description"
            >
              This Christmas, spread the holiday joy further with Santa Secrets.
              Join or create groups with your loved ones and discover the fun of
              festive gifting. Allow the spirit of giving to bring you closer.
            </p>
            <button
              data-testid="first-section-button"
              className="section-button"
              onClick={() => restrictedNavigate("/list-groups")}
            >
              <span
                data-testid="first-section-button-text"
                className="section-button-text"
              >
                See a Group Now
              </span>
            </button>
          </div>
        </div>
        <div className="section-column-right">
          <img
            src="images/mifcypa0yqslostibhfx.jpg"
            className="section-image"
            alt="Christmas Celebration"
          ></img>
        </div>
      </div>
      <div className="section">
        <div className="section-column-left">
          <img
            src="images/demmqv130xrtnxb7l0qa.jpg"
            className="section-image"
            alt="Create Your Own Group"
          ></img>
        </div>
        <div className="section-column-right">
          <div className="section-text">
            <p data-testid="second-section-title" className="section-title">
              Create Your Own Festive Group Today
            </p>
            <p
              data-testid="second-section-description"
              className="section-description"
            >
              With Santa Secrets, you are not just a part of the festive joy,
              you create it. Develop your own group, invite friends and see the
              joy multiply. Unwrap happiness today.
            </p>
            <button
              data-testid="second-section-button"
              className="section-button"
              onClick={() => restrictedNavigate("/create-group")}
            >
              <span
                data-testid="second-section-button-text"
                className="section-button-text"
              >
                Create a Group Now
              </span>
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default HomePage;
