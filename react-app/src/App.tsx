import { BrowserRouter } from "react-router-dom";
import React from "react";

import AppRouter from "./routes/AppRouter";

const App = () => {
  return (
    <BrowserRouter>
      <AppRouter />
    </BrowserRouter>
  );
};

export default App;
