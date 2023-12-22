import React, { useEffect, useState } from "react";
import { toast } from "react-toastify";

import { PagedParameters } from "../../interfaces/PagedParameters";
import { GroupInterface } from "../../interfaces/GroupInterface";
import groupService from "../../services/GroupService";
import { PagedList } from "../../interfaces/PagedList";
import { useAuth } from "../../contexts/AuthContext";

import "./ListGroupPage.css";

const ListGroupPage: React.FC = () => {
  const { restrictedNavigate } = useAuth();
  const [pagedList, setPagedList] = useState<PagedList<GroupInterface> | null>(
    null,
  );
  const [page, setPage] = useState<number>(1);

  useEffect(() => {
    const fetch = async () => {
      try {
        const parameters: PagedParameters = {
          page: page,
          size: 4,
        };
        const options = await groupService.paged(parameters);
        setPagedList(options);
      } catch (error) {
        toast.error((error as Error).message as React.ReactNode);
      }
    };
    fetch();
  }, [page]);

  const handleNextPage = () => {
    setPage((prevPage) => prevPage + 1);
  };

  const handlePreviousPage = () => {
    setPage((prevPage) => Math.max(prevPage - 1, 1));
  };

  return (
    <div className="page-container">
      <div className="page-content">
        <div className="page-header">
          <p data-testid="page-title" className="page-header-title">
            My Groups
          </p>
          <p data-testid="page-description" className="page-header-description">
            The page description
          </p>
        </div>
        <div className="groups-list">
          {pagedList === null || pagedList.data.length === 0 ? (
            <p data-testid="empty-group-list">No groups available.</p>
          ) : (
            pagedList.data.map((group) => (
              <button
                data-testid={`group-item-${group.id}`}
                key={group.id}
                className="group-item"
                onClick={() => restrictedNavigate(`/view-group/${group.id}`)}
              >
                <img
                  data-testid={`group-item-image-${group.id}`}
                  src={
                    group.image ||
                    "images/tatiana-byzova-nbe4qiyfwx8-unsplashjpg_1677495264_54382.jpg"
                  }
                  className="group-item-image"
                  alt={`Group ${group.name}`}
                />
                <div className="group-item-info">
                  <h3 data-testid={`group-item-name-${group.id}`}>
                    {group.name}
                  </h3>
                  <p data-testid={`group-item-total-members-${group.id}`}>
                    {group.totalMembers} members
                  </p>
                </div>
              </button>
            ))
          )}
        </div>
        <div className="pagination-controls">
          <button
            data-testid="previus-page"
            className="previus-page"
            onClick={handlePreviousPage}
            disabled={page === 1}
          >
            Previous Page
          </button>
          <span className="page-number">Page {page}</span>
          <button
            data-testid="next-page"
            className="next-page"
            onClick={handleNextPage}
            disabled={!pagedList || page === pagedList.totalPages}
          >
            Next Page
          </button>
        </div>
      </div>
    </div>
  );
};

export default ListGroupPage;
