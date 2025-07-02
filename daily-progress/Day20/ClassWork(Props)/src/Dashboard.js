import React from "react";
import { useUser } from "./UserContext";

export default function Dashboard({ onLogout }) {
  const user = useUser();

  return (
    <div className="text-center mt-5">
      <img
        src={user.avatarUrl}
        alt={user.name}
        style={{ width: "120px", borderRadius: "10px" }}
      />
      <h3 className="mt-3">{user.name}</h3>
      <p><strong>Role:</strong> {user.role}</p>

      {user.role === "Admin" && (
        <button className="btn btn-warning mt-3">Go to Admin Panel</button>
      )}
      {user.role === "Employee" && (
        <button className="btn btn-success mt-3">Request Asset</button>
      )}
      
      <button onClick={onLogout} className="btn btn-danger mt-4">
        Logout
      </button>
    </div>
  );
}
