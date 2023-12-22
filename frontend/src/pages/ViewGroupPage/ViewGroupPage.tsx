import React, { useCallback, useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { toast } from "react-toastify";

import InviteModal from "../../components/InviteModal/InviteModal";

import { MemberRoles } from "../../enums/MemberRoles";

import { GroupInterface } from "../../interfaces/GroupInterface";

import groupService from "../../services/GroupService";

import "./ViewGroupPage.css";

const ViewGroupPage: React.FC = () => {
  const navigate = useNavigate();
  const { groupId } = useParams<{ groupId: string }>();
  const [group, setGroup] = useState<GroupInterface | null>(null);
  const [isInviteModalOpen, setInviteModalOpen] = useState<boolean>(false);
  const [invite, setInvite] = useState<string>("");

  useEffect(() => {
    const fetch = async () => {
      if (groupId === undefined) return navigate("/not-found");
      try {
        const group = await groupService.getById(groupId);
        setGroup(group);
      } catch (error) {
        toast.error((error as Error).message as React.ReactNode);
      }
    };
    fetch();
  }, [groupId, navigate]);

  const getInvite = async () => {
    try {
      if (groupId === undefined) return navigate("/not-found");
      const response = await groupService.invite(groupId);
      setInvite(response);
      setInviteModalOpen(true);
    } catch (error) {
      toast.error((error as Error).message as React.ReactNode);
    }
  };

  const closeInviteModal = useCallback(() => {
    setInviteModalOpen(false);
  }, [setInviteModalOpen]);

  return (
    <div className="page-container">
      <div className="page-content">
        <div className="page-header">
          <p data-testid="page-title" className="page-header-title">
            View a Group: {group?.name}
          </p>
          <p data-testid="page-description" className="page-header-description">
            The page description
          </p>
        </div>
        <div className="group-info">
          <div className="group-members">
            <p className="group-members-title">Admins</p>
            <ul className="group-members-list">
              {group?.members
                .filter((member) => member.role === MemberRoles.ADMIN)
                .map((member, index) => (
                  <li key={index}>
                    <p>{member.name}</p>
                  </li>
                ))}
            </ul>
          </div>
          <hr />
          <div className="group-members">
            <p className="group-members-title">Members</p>
            <ul className="group-members-list">
              {group?.members
                .filter((member) => member.role === MemberRoles.MEMBER)
                .map((member, index) => (
                  <li key={index}>
                    <p>{member.name}</p>
                  </li>
                ))}
            </ul>
          </div>
          <hr />
          <button className="invite-button" onClick={() => getInvite()}>
            <span className="invite-button-text">Invite</span>
          </button>
        </div>
      </div>
      {isInviteModalOpen && (
        <InviteModal onClose={closeInviteModal} invite={invite} />
      )}
    </div>
  );
};

export default ViewGroupPage;
