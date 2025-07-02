import React, { useState } from "react";

export default function LoginForm({ onLogin }) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();

    // Simulated login logic
    if (email === "admin@example.com" && password === "admin123") {
      onLogin({
        name: "Jaanu",
        avatarUrl: "/avatar-3-custom-image-1.avif",
        role: "Admin"
      });
    } else if (email === "user@example.com" && password === "user123") {
      onLogin({
        name: "Nivash",
        avatarUrl: "https://i.pravatar.cc/150?img=68",
        role: "Employee"
      });
    } else {
      alert("Invalid credentials");
    }
  };

  return (
    <div className="container mt-4" style={{ maxWidth: "400px" }}>
      <h3 className="mb-3 text-center">Login</h3>
      <form onSubmit={handleSubmit}>
        <input
          type="email"
          className="form-control mb-2"
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />
        <input
          type="password"
          className="form-control mb-2"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />
        <button className="btn btn-primary w-100" type="submit">
          Login
        </button>
      </form>
    </div>
  );
}
