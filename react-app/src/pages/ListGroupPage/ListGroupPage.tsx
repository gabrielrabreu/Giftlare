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
  const [size] = useState<number>(4);

  useEffect(() => {
    const fetch = async () => {
      try {
        const parameters: PagedParameters = {
          page: page,
          size: size,
        };
        const options = await groupService.paged(parameters);
        setPagedList(options);
      } catch (error) {
        let errorMessage = error instanceof Error ? error.message : error;
        toast.error(errorMessage as React.ReactNode);
      }
    };
    fetch();
  }, [page, size]);

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
          <p className="page-header-title">My Groups</p>
          <p className="page-header-description">The page description</p>
        </div>
        <div className="groups-list">
          {pagedList === null || pagedList.data.length === 0 ? (
            <p>No groups available.</p>
          ) : (
            pagedList.data.map((group) => (
              <div
                key={group.id}
                className="group-item"
                onClick={() => restrictedNavigate(`/view-group/${group.id}`)}
              >
                <img
                  src={
                    group.image ||
                    "images/tatiana-byzova-nbe4qiyfwx8-unsplashjpg_1677495264_54382.jpg"
                  }
                  className="group-image"
                  alt="Imagem do Group 1"
                />
                <div className="group-info">
                  <h3>{group.name}</h3>
                  <p>{group.totalMembers} members</p>
                </div>
              </div>
            ))
          )}
        </div>
        <div className="pagination-controls">
          <button
            className="previus-page"
            onClick={handlePreviousPage}
            disabled={page === 1}
          >
            Previous Page
          </button>
          <span className="page-number">Page {page}</span>
          <button
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
