import React, { ReactNode } from "react";

import LoginModal from "../../components/LoginModal/LoginModal";
import { ApiServiceConfig } from "../../services/ApiService";
import { useAuth } from "../../contexts/AuthContext";
import NavBar from "../NavBar/NavBar";
import Footer from "../Footer/Footer";

import "./MainLayout.css";

interface MainLayoutProps {
  children: ReactNode;
}

const MainLayout: React.FC<MainLayoutProps> = ({ children }) => {
  const { isLoginModalOpen, closeLoginModal, logout } = useAuth();

  ApiServiceConfig.logout = logout;

  return (
    <div className="container">
      <NavBar />
      <main className="container-content">{children}</main>
      <Footer />

      {isLoginModalOpen && <LoginModal onClose={closeLoginModal} />}
    </div>
  );
};

export default MainLayout;
