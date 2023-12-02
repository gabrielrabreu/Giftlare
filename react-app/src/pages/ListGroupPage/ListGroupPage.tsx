import { Link } from "react-router-dom";
import React from "react";

import { GroupInterface } from "../../interfaces/GroupInterface";

import "./ListGroupPage.css";

const ListGroupPage: React.FC = () => {
  const groups: GroupInterface[] = [];

  return (
    <div className="page-container">
      <div className="page-content">
        <div className="page-header">
          <p className="page-header-title">My Groups</p>
          <p className="page-header-description">The page description</p>
        </div>
        <div className="groups-list">
          {groups.length === 0 ? (
            <p>No groups available.</p>
          ) : (
            groups.map((group) => (
              <React.Fragment key={group.id}>
                <Link to={`/view-group/${group.id}`} className="group-item">
                  <img
                    src="images/tatiana-byzova-nbe4qiyfwx8-unsplashjpg_1677495264_54382.jpg"
                    className="group-image"
                    alt="Imagem do Group 1"
                  />
                  <div className="group-info">
                    <h3>{group.name}</h3>
                    <p>{group.participantsAmount} participants</p>
                  </div>
                </Link>
              </React.Fragment>
            ))
          )}
        </div>
      </div>
    </div>
  );
};

export default ListGroupPage;
