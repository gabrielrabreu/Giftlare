import React from "react";

import "./InviteModal.css";

const InviteModal: React.FC<{ onClose: () => void; invite: string }> = ({
  onClose,
  invite,
}) => {
  const handleCancel = () => {
    onClose();
  };

  const handleShare = () => {
    const baseUrl = window.location.origin;
    const url = `${baseUrl}/accept-invite?${invite}`;
    navigator.clipboard.writeText(url);
  };

  return (
    <div className="invite-modal">
      <div className="invite-content">
        <div className="invite-header">
          <p data-testid="invite-title" className="invite-header-title">
            Invite!
          </p>
          <p
            data-testid="invite-description"
            className="invite-header-description"
          >
            Invite your friends to participate in the group.
          </p>
        </div>
        <div className="form">
          <div className="form-buttons">
            <button
              data-testid="submit-button"
              className="form-submit"
              type="button"
              onClick={handleShare}
            >
              Share
            </button>
            <button
              data-testid="cancel-button"
              className="form-cancel"
              type="button"
              onClick={handleCancel}
            >
              Cancel
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default InviteModal;
