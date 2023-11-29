import { Navigate } from "react-router-dom";
import React, { ReactNode } from "react";

import { ApiServiceConfig } from "../services/ApiService";
import { useAuth } from "../contexts/AuthContext";
import NavBar from "../components/NavBar/NavBar";
import Footer from "../components/Footer/Footer";

interface PrivateRouteProps {
  children: ReactNode;
}

const PrivateRoute: React.FC<PrivateRouteProps> = ({ children }) => {
  const { user, logout } = useAuth();
  if (!user) {
    return <Navigate to="/signin" />;
  }

  ApiServiceConfig.logout = () => {
    logout();
  };

  return (
    <div className="app-container">
      <NavBar />
      <main>{children}</main>
      <Footer />
    </div>
  );
};

export default PrivateRoute;
