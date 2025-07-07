import React from "react";
import { Navigate } from "react-router-dom";
import { useAuth } from "./AuthContext";

export default function PrivateRoute({ children }) {
  const { auth } = useAuth();
  return auth.isLoggedIn ? children : <Navigate to="/login" />;
}

