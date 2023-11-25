import { BrowserRouter as Router } from "react-router-dom";
import { ToastContainer } from "react-toastify";

import { AuthProvider } from "./contexts/AuthContext";
import AppRoutes from "./routes/AppRoutes";

import "react-toastify/dist/ReactToastify.css";

function App() {
  return (
    <Router>
      <AuthProvider>
        <ToastContainer />
        <AppRoutes />
      </AuthProvider>
    </Router>
  );
}

export default App;
