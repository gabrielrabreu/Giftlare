import { Link } from "react-router-dom";
import React from "react";

import "./ListGroupPage.css";

const ListGroupPage: React.FC = () => {
  return (
    <div className="page-container">
      <div className="page-content">
        <div className="page-header">
          <p className="page-header-title">My Groups</p>
          <p className="page-header-description">The page description</p>
        </div>
        <div className="groups-list">
          <Link to="/view-group" className="group-item">
            <img
              src="images/tatiana-byzova-nbe4qiyfwx8-unsplashjpg_1677495264_54382.jpg"
              className="group-image"
              alt="Imagem do Group 1"
            />
            <div className="group-info">
              <h3>Group A</h3>
              <p>10 participants</p>
            </div>
          </Link>
          <Link to="/view-group" className="group-item">
            <img
              src="images/eugenivy_now-1jjjihh7-mk-unsplashjpg_1677495264_52864.jpg"
              className="group-image"
              alt="Imagem do Group 2"
            />
            <div className="group-info">
              <h3>Group B</h3>
              <p>8 participants</p>
            </div>
          </Link>
          <Link to="/view-group" className="group-item">
            <img
              src="images/filipe-freitas-z9fyqvtqgeu-unsplashjpg_1677495264_89541.jpg"
              className="group-image"
              alt="Imagem do Group 2"
            />
            <div className="group-info">
              <h3>Group C</h3>
              <p>4 participants</p>
            </div>
          </Link>
          <Link to="/view-group" className="group-item">
            <img
              src="images/juan-domenech-fc-kml4ndfq-unsplashjpg_1677495264_28415.jpg"
              className="group-image"
              alt="Imagem do Group 2"
            />
            <div className="group-info">
              <h3>Group D</h3>
              <p>2 participants</p>
            </div>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default ListGroupPage;
