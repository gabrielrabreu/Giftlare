import { Link } from "react-router-dom";
import React from "react";

import "./HomePage.css";

const HomePage: React.FC = () => {
  return (
    <div className="home-container">
      <div className="section">
        <div className="section-column-left">
          <div className="section-text">
            <p className="section-title">
              Connect with Loved Ones in Festive Groups
            </p>
            <p className="section-description">
              This Christmas, spread the holiday joy further with Santa Secrets.
              Join or create groups with your loved ones and discover the fun of
              festive gifting. Allow the spirit of giving to bring you closer.
            </p>
            <Link to="/list-groups" className="section-button">
              <span className="section-button-text">See a Group Now</span>
            </Link>
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
            <p className="section-title">Create Your Own Festive Group Today</p>
            <p className="section-description">
              With Santa Secrets, you are not just a part of the festive joy,
              you create it. Develop your own group, invite friends and see the
              joy multiply. Unwrap happiness today.
            </p>
            <Link to="/create-group" className="section-button">
              <span className="section-button-text">Create a Group Now</span>
            </Link>
          </div>
        </div>
      </div>
    </div>
  );
};

export default HomePage;
