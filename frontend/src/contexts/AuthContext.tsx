import React, {
  createContext,
  useContext,
  ReactNode,
  useState,
  useEffect,
  useMemo,
  useCallback,
} from "react";

import { UserDto } from "../interfaces/UserDto";

interface AuthContextProps {
  token: string | null;
  user: UserDto | null;
  signIn: (token: string, user: UserDto) => void;
  logout: () => void;
  saveAuthData: (token: string, user: UserDto) => void;
  loadAuthData: () => void;
}

const AuthContext = createContext<AuthContextProps | undefined>(undefined);

export const AuthProvider: React.FC<{ children: ReactNode }> = ({
  children,
}) => {
  const [token, setToken] = useState<string | null>(null);
  const [user, setUser] = useState<UserDto | null>(null);

  const saveAuthData = useCallback((newToken: string, newUser: UserDto) => {
    localStorage.setItem("token", newToken);
    localStorage.setItem("user", JSON.stringify(newUser));
  }, []);

  const clearAuthData = useCallback(() => {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
  }, []);

  const signIn = useCallback(
    (newToken: string, newUser: UserDto) => {
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
    }
  }, []);

  const contextValue = useMemo(() => {
    return { token, user, signIn, logout, saveAuthData, loadAuthData };
  }, [token, user, signIn, logout, saveAuthData, loadAuthData]);

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
