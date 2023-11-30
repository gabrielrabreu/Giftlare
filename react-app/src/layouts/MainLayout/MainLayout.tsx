import React, { ReactNode } from "react";

import NavBar from "../NavBar/NavBar";
import Footer from "../Footer/Footer";

import "./MainLayout.css";

interface MainLayoutProps {
  children: ReactNode;
}

const MainLayout: React.FC<MainLayoutProps> = ({ children }) => {
  return (
    <div className="container">
      <NavBar />
      <main className="container-content">{children}</main>
      <Footer />
    </div>
  );
};

export default MainLayout;
