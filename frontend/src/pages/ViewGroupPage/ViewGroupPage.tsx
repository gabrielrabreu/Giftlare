import { useParams } from "react-router-dom";
import React from "react";

import "./ViewGroupPage.css";

const ViewGroupPage: React.FC = () => {
  const { groupId } = useParams<{ groupId: string }>();
  console.log(groupId);

  return (
    <div className="page-container">
      <div className="page-content">
        <div className="page-header">
          <p className="page-header-title">View a Group</p>
          <p className="page-header-description">The page description</p>
        </div>
      </div>
    </div>
  );
};

export default ViewGroupPage;
