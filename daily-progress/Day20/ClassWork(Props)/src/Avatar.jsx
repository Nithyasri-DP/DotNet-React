import React from "react";
import { useUser } from "./UserContext";

export default function Avatar() {
    const user = useUser();  // Direct access to user (useContext)

  return (
    <div className="avatar">
      <img
        src={user.avatarUrl}
        alt={user.name}
        style={{ borderRadius: "50%", width: "350px", height: "300px" }}
      />
      
      <p><strong>Name:</strong> {user.name}</p>
      <p><strong>Role:</strong> {user.role}</p> 

{user.role === "Admin" && (
  <button className="btn btn-warning mt-3">Go to Admin Panel</button>
)}
  </div>
  );
}
