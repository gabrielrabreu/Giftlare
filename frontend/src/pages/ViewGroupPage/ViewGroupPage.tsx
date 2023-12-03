import { useParams } from "react-router-dom";
import React from "react";

const ViewGroupPage: React.FC = () => {
  const { groupId } = useParams<{ groupId: string }>();
  console.log(groupId);

  return (
    <div className="page-container">
      <div className="page-content">
        <div className="page-header">
          <p data-testid="page-title" className="page-header-title">
            View a Group
          </p>
          <p data-testid="page-description" className="page-header-description">
            The page description
          </p>
        </div>
      </div>
    </div>
  );
};

export default ViewGroupPage;
