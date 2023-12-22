import { Routes, Route, Outlet, Navigate } from "react-router-dom";
import React from "react";

import AcceptInvitePage from "../pages/AcceptInvitePage/AcceptInvitePage";
import CreateGroupPage from "../pages/CreateGroupPage/CreateGroupPage";
import ListGroupPage from "../pages/ListGroupPage/ListGroupPage";
import ViewGroupPage from "../pages/ViewGroupPage/ViewGroupPage";
import NotFoundPage from "../pages/NotFoundPage/NotFoundPage";
import MainLayout from "../layouts/MainLayout/MainLayout";
import HomePage from "../pages/HomePage/HomePage";
import { useAuth } from "../contexts/AuthContext";

const PrivateRoute = ({ children }: { children: React.ReactNode }) => {
  const { user } = useAuth();

  if (!user) {
    localStorage.setItem(
      "redirectUrl",
      window.location.pathname + window.location.search,
    );
    return <Navigate to="/" />;
  }

  return <>{children}</>;
};

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
        <Route
          path="list-groups"
          element={
            <PrivateRoute>
              <ListGroupPage />
            </PrivateRoute>
          }
        />
        <Route
          path="create-group"
          element={
            <PrivateRoute>
              <CreateGroupPage />
            </PrivateRoute>
          }
        />
        <Route
          path="view-group/:groupId"
          element={
            <PrivateRoute>
              <ViewGroupPage />
            </PrivateRoute>
          }
        />
        <Route
          path="accept-invite"
          element={
            <PrivateRoute>
              <AcceptInvitePage />
            </PrivateRoute>
          }
        />
      </Route>
      <Route path="*" element={<NotFoundPage />} />
    </Routes>
  );
};

export default AppRouter;
