import { isAuthenticated } from "../services/loginService";
import React, { useState, useEffect, createContext, useContext } from "react";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
 
  const [auth, setAuth] = useState({
    isLoggedIn: isAuthenticated(), 
  });

  useEffect(() => {
    const stored = isAuthenticated();
    if (stored !== auth.isLoggedIn) {
      setAuth({ isLoggedIn: stored });
    }
  }, []);
 
  const loginUser = () => setAuth({ isLoggedIn: true });
  const logoutUser = () => {
    localStorage.removeItem("token");  
    localStorage.removeItem("username");
    setAuth({ isLoggedIn: false });
  };

  return (
    <AuthContext.Provider value={{ auth, loginUser, logoutUser }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => useContext(AuthContext);
