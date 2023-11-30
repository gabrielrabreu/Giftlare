import React, { ReactNode } from "react";

import NavBar from "../components/NavBar/NavBar";
import "./MainLayout.css";

interface MainLayoutProps {
  children: ReactNode;
}

const MainLayout: React.FC<MainLayoutProps> = ({ children }) => {
  return (
    <div className="container">
      <NavBar />
      <main>{children}</main>
    </div>
  );
};

export default MainLayout;
