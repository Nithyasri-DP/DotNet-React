import React from "react";
import { NavLink, useNavigate } from "react-router-dom";
import { useAuth } from "../auth/AuthContext";

export default function NavBar() {
  const { user, logout } = useAuth();
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();             // clear user & back to login
    navigate("/login");   
  };

  return (
    <nav className="nav nav-dark" style={{ gap: "20px", padding: "10px" }}>
      <NavLink to="/">  Home  </NavLink>
      <NavLink to="/about">  About  </NavLink>
      <NavLink to="/products">  Products  </NavLink>

      {user ? (
        <>
          <NavLink to="/dashboard">  Dashboard  </NavLink>
          <NavLink to="/orders">  Orders  </NavLink>
          <NavLink to="/profile">  Profile  </NavLink>
          <button onClick={handleLogout}>  Logout  </button>
        </>
      ) : (
        <NavLink to="/login">  Login  </NavLink>
      )}
    </nav>
  );
}
