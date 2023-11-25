import { useAuth } from "../../contexts/AuthContext";

import "./HomePage.css";

const HomePage: React.FC = () => {
  const { user } = useAuth();

  return (
    <div className="home-page">
      <h1>Bem-vindo, {user?.name}!</h1>
    </div>
  );
};

export default HomePage;
