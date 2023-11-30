import { Routes, Route } from "react-router-dom";
import React from "react";

import NotFoundPage from "../pages/NotFoundPage/NotFoundPage";
import MainLayout from "../layouts/MainLayout/MainLayout";
import GroupsPage from "../pages/GroupsPage/GroupsPage";
import HomePage from "../pages/HomePage/HomePage";

const Routing = () => {
  return (
    <Routes>
      <Route
        path="/"
        element={
          <MainLayout>
            <HomePage />
          </MainLayout>
        }
      ></Route>
      <Route
        path="/groups"
        element={
          <MainLayout>
            <GroupsPage />
          </MainLayout>
        }
      ></Route>
      <Route path="*" element={<NotFoundPage />} />
    </Routes>
  );
};

export default Routing;
