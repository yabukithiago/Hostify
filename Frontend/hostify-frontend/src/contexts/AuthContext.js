import React, { createContext, useState, useContext } from 'react';

const AuthContext = createContext();

export function AuthProvider({ children }) {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [name, setName] = useState("");

  const login = (name) => {
    setIsAuthenticated(true);
    setName(name);
  };

  const logout = () => {
    setIsAuthenticated(false);
    setName("");
  };

  return (
    <AuthContext.Provider value={{ isAuthenticated, name, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}

export function useAuth() {
  return useContext(AuthContext);
}
