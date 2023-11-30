import { BrowserRouter } from "react-router-dom";
import React from "react";

import Routing from "./routes/Routing";

function App() {
  return (
    <BrowserRouter>
      <Routing />
    </BrowserRouter>
  );
}

export default App;
