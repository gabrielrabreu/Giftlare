import { Routes, Route } from "react-router-dom";

import SignInPage from "../pages/SignInPage/SignInPage";
import HomePage from "../pages/HomePage/HomePage";
import PrivateRoute from "./PrivateRoute";
import GuestRoute from "./GuestRoute";

const AppRoutes = () => {
  return (
    <Routes>
      <Route
        path="/"
        element={
          <PrivateRoute>
            <HomePage />
          </PrivateRoute>
        }
      />
      <Route
        path="/signin"
        element={
          <GuestRoute>
            <SignInPage />
          </GuestRoute>
        }
      />
    </Routes>
  );
};

export default AppRoutes;
