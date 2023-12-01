import { Routes, Route } from "react-router-dom";
import React from "react";

import CreateGroupPage from "../pages/CreateGroupPage/CreateGroupPage";
import ListGroupPage from "../pages/ListGroupPage/ListGroupPage";
import ViewGroupPage from "../pages/ViewGroupPage/ViewGroupPage";
import NotFoundPage from "../pages/NotFoundPage/NotFoundPage";
import MainLayout from "../layouts/MainLayout/MainLayout";
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
        path="/list-groups"
        element={
          <MainLayout>
            <ListGroupPage />
          </MainLayout>
        }
      ></Route>
      <Route
        path="/create-group"
        element={
          <MainLayout>
            <CreateGroupPage />
          </MainLayout>
        }
      ></Route>
      <Route
        path="/view-group"
        element={
          <MainLayout>
            <ViewGroupPage />
          </MainLayout>
        }
      ></Route>
      <Route path="*" element={<NotFoundPage />} />
    </Routes>
  );
};

export default Routing;
