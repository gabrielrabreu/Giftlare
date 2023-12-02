import { BrowserRouter } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import React from "react";

import { AuthProvider } from "./contexts/AuthContext";
import AppRouter from "./routes/AppRouter";

import "react-toastify/dist/ReactToastify.css";

const App = () => {
  return (
    <BrowserRouter>
      <AuthProvider>
        <ToastContainer />
        <AppRouter />
      </AuthProvider>
    </BrowserRouter>
  );
};

export default App;
