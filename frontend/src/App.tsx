import SignInPage from "./pages/SignInPage/SignInPage";
import { AuthProvider } from "./contexts/AuthContext";

function App() {
  return (
    <AuthProvider>
      <div className="App">
        <SignInPage />
      </div>
    </AuthProvider>
  );
}

export default App;
