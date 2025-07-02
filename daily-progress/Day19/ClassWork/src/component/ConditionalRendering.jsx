import React, { useState } from "react";

function ConditionalRendering() {
  const employees = ["Varsha", "Preethi", "Kaavya", "Megna"];

  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [username, setUsername] = useState("");
  const [user, setUser] = useState(null); // Will store { username, role }

  const error = null;

  // Event handler for login
  const handleLogin = () => {
    if (username.trim() === "") {
      alert("Please enter a username.");
      return;
    }

    // Simulate admin login only for Meena
    const role = username === "Meena" ? "admin" : "user";
    setUser({ username, role });
    setIsLoggedIn(true);
    alert(`Logged in as ${username} (${role})`);
  };

  return (
    <div style={{ padding: "20px", border: "1px solid #ddd", marginTop: "20px" }}>
      <h2>Conditional Rendering Demo</h2>

      {/* Error Handling */}
      {error ? (
        <p style={{ color: "red" }}>
          Something went wrong. Please try again later.
        </p>
      ) : (
        <>
          {/* Login Check */}
          {isLoggedIn ? (
            <p>Welcome {user.username}</p>
          ) : (
            <div>
              <input
                type="text"
                placeholder="Enter your username"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
              />
              <button onClick={handleLogin}>Login</button>
            </div>
          )}

          {/* Employee List */}
          <h3>Employee List</h3>
          {employees.length === 0 ? (
            <p>No employees found.</p>
          ) : (
            <ul>
              {employees.map((emp, index) => (
                <li key={index}>{emp}</li>
              ))}
            </ul>
          )}

          {/* Admin Check */}
          <div>
            {isLoggedIn && user.role === "admin" ? (
              <button>Manage Customers</button>
            ) : (
              <p>You have read-only access.</p>
            )}
          </div>
        </>
      )}
    </div>
  );
}

export default ConditionalRendering;
