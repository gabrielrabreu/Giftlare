import { useLocation, useNavigate } from "react-router-dom";
import React, { useEffect, useState } from "react";
import { toast } from "react-toastify";

import { GroupInterface } from "../../interfaces/GroupInterface";

import groupService from "../../services/GroupService";

import { MemberRoles } from "../../enums/MemberRoles";
import "./AcceptInvitePage.css";

const AcceptInvitePage: React.FC = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const [group, setGroup] = useState<GroupInterface | null>(null);

  const queryParams = new URLSearchParams(location.search);
  const groupId = queryParams.get("id");
  const inviteToken = queryParams.get("token");

  useEffect(() => {
    const fetch = async () => {
      if (groupId === null) return navigate("/not-found");
      if (inviteToken === null) return navigate("/not-found");
      try {
        const group = await groupService.getById(groupId);
        setGroup(group);
      } catch (error) {
        toast.error((error as Error).message as React.ReactNode);
      }
    };
    fetch();
  }, [groupId, inviteToken, navigate]);

  const acceptInvite = async () => {
    try {
      await groupService.acceptInvite(groupId as string, inviteToken as string);
      toast.success("Successfully added to the group!");
      navigate("/list-groups");
    } catch (error) {
      toast.error((error as Error).message as React.ReactNode);
    }
  };

  return (
    <div className="page-container">
      <div className="page-content">
        <div className="page-header">
          <p data-testid="page-title" className="page-header-title">
            Accept Invite
          </p>
          <p data-testid="page-description" className="page-header-description">
            You were invited by{" "}
            <b>
              {
                group?.members.find(
                  (member) => member.role === MemberRoles.ADMIN,
                )?.name
              }
            </b>{" "}
            to enter the group <b>{group?.name}</b>!
          </p>
          <button
            className="accept-invite-button"
            onClick={() => acceptInvite()}
          >
            <span className="accept-invite-button-text">Accept</span>
          </button>
        </div>
      </div>
    </div>
  );
};

export default AcceptInvitePage;
