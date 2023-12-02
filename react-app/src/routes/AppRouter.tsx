import { Routes, Route, Outlet } from "react-router-dom";
import React from "react";

import CreateGroupPage from "../pages/CreateGroupPage/CreateGroupPage";
import ListGroupPage from "../pages/ListGroupPage/ListGroupPage";
import ViewGroupPage from "../pages/ViewGroupPage/ViewGroupPage";
import NotFoundPage from "../pages/NotFoundPage/NotFoundPage";
import MainLayout from "../layouts/MainLayout/MainLayout";
import HomePage from "../pages/HomePage/HomePage";

const AppRouter = () => {
  return (
    <Routes>
      <Route
        path="/"
        element={
          <MainLayout>
            <Outlet />
          </MainLayout>
        }
      >
        <Route index element={<HomePage />} />
        <Route path="list-groups" element={<ListGroupPage />} />
        <Route path="create-group" element={<CreateGroupPage />} />
        <Route path="view-group/:groupId" element={<ViewGroupPage />} />
      </Route>
      <Route path="*" element={<NotFoundPage />} />
    </Routes>
  );
};

export default AppRouter;
