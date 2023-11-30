import { Routes, Route } from "react-router-dom";

import ExchangesPage from "../pages/ExchangesPage/ExchangesPage";
import NotFoundPage from "../pages/NotFoundPage/NotFoundPage";
import SignInPage from "../pages/SignInPage/SignInPage";
import HomePage from "../pages/HomePage/HomePage";
import MainLayout from "../layouts/MainLayout";

const AppRoutes = () => {
  return (
    <Routes>
      <Route
        path="/"
        element={
          <MainLayout>
            <HomePage />
          </MainLayout>
        }
      />
      <Route path="/signin" element={<SignInPage />} />
      <Route
        path="/exchanges"
        element={
          <MainLayout>
            <ExchangesPage />
          </MainLayout>
        }
      />
      <Route path="*" element={<NotFoundPage />} />
    </Routes>
  );
};

export default AppRoutes;
