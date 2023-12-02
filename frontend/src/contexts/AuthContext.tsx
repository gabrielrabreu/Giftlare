import React, {
  createContext,
  useContext,
  ReactNode,
  useState,
  useEffect,
  useMemo,
  useCallback,
} from "react";
import { useNavigate } from "react-router-dom";

import { UserInterface } from "../interfaces/UserInterface";

interface AuthContextProps {
  token: string | null;
  user: UserInterface | null;
  login: (token: string, user: UserInterface) => void;
  logout: () => void;
  saveAuthData: (token: string, user: UserInterface) => void;
  loadAuthData: () => void;
  isLoginModalOpen: boolean;
  openLoginModal: () => void;
  closeLoginModal: () => void;
  restrictedNavigate: (desiredRoute: string) => void;
}

export const AuthContext = createContext<AuthContextProps | undefined>(
  undefined,
);

export const AuthProvider: React.FC<{ children: ReactNode }> = ({
  children,
}) => {
  const navigate = useNavigate();

  const [token, setToken] = useState<string | null>(null);
  const [user, setUser] = useState<UserInterface | null>(null);
  const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);

  const saveAuthData = useCallback(
    (newToken: string, newUser: UserInterface) => {
      localStorage.setItem("token", newToken);
      localStorage.setItem("user", JSON.stringify(newUser));
      localStorage.setItem("language", newUser.language);
    },
    [],
  );

  const clearAuthData = useCallback(() => {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    localStorage.removeItem("language");
  }, []);

  const login = useCallback(
    (newToken: string, newUser: UserInterface) => {
      setToken(newToken);
      setUser(newUser);
      saveAuthData(newToken, newUser);
    },
    [saveAuthData],
  );

  const logout = useCallback(() => {
    setToken(null);
    setUser(null);
    clearAuthData();
  }, [clearAuthData]);

  const loadAuthData = useCallback(() => {
    const storedToken = localStorage.getItem("token");
    const storedUser = JSON.parse(localStorage.getItem("user") ?? "{}");
    if (storedToken && storedUser) {
      setToken(storedToken);
      setUser(storedUser);
    } else {
      localStorage.setItem("language", navigator.language);
    }
  }, []);

  const openLoginModal = useCallback(() => {
    setIsLoginModalOpen(true);
  }, []);

  const closeLoginModal = useCallback(() => {
    setIsLoginModalOpen(false);
  }, []);

  const restrictedNavigate = useCallback(
    (desiredRoute: string) => {
      if (user != null) {
        navigate(desiredRoute);
      } else {
        openLoginModal();
      }
    },
    [user, navigate, openLoginModal],
  );

  const contextValue = useMemo(() => {
    return {
      token,
      user,
      login,
      logout,
      saveAuthData,
      loadAuthData,
      isLoginModalOpen,
      openLoginModal,
      closeLoginModal,
      restrictedNavigate,
    };
  }, [
    token,
    user,
    login,
    logout,
    saveAuthData,
    loadAuthData,
    isLoginModalOpen,
    openLoginModal,
    closeLoginModal,
    restrictedNavigate,
  ]);

  useEffect(() => {
    loadAuthData();
  }, [loadAuthData]);

  return (
    <AuthContext.Provider value={contextValue}>{children}</AuthContext.Provider>
  );
};

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error("useAuth should be used inside of AuthProvider");
  }
  return context;
};
