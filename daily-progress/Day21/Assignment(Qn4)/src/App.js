import React, { useState } from "react";
import ProfileCard from "./components/ProfileCard";
import WelcomeUser from "./components/WelcomeUser";
import ProductPrice from "./components/ProductPrice";
import SkillList from "./components/SkillList";
import "./App.css";

function App() {

  //2)
const [name, setName] = useState("");
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [error, setError] = useState("");

  const handleLoginClick = () => {
    if (name.trim() === "") {
      setError("Please enter your name before logging in.");
      setIsLoggedIn(false);
    } else {
      setError("");
      setIsLoggedIn(true);
    }
  };

  const handleLogoutClick = () => {
    setIsLoggedIn(false);
    setName("");
    setError("");
  };

  //4)
  const mySkills = ["React", "JavaScript", "CSS", "Bootstrap"]

return (
    <div className="app-container">
      <div className="assignment-block">
        <h2>Assignment 1: Profile Card</h2>
        <div style={{ marginBottom: "30px" }}>
          <ProfileCard
            name="Nithyasri D P"
            title="Frontend Developer"
            imageUrl="\assign.avif"
          />
        </div>

        <h2>Assignment 2: Welcome Message</h2>
        <input
          type="text"
          placeholder="Enter your name"
          value={name}
          onChange={(e) => setName(e.target.value)}
          style={{ padding: "8px", marginBottom: "10px" }}
        />
        <br />

        {isLoggedIn ? (
          <button onClick={handleLogoutClick}>Logout</button>
        ) : (
          <button onClick={handleLoginClick}>Login</button>
        )}

        <div style={{ marginTop: "20px" }}>
          <WelcomeUser isLoggedIn={isLoggedIn} name={name} />
          {error && <p style={{ color: "red" }}>{error}</p>}
        </div>

        <h2>Assignment 3: Product Price</h2>
        <div className="assignment-block">
          <ProductPrice name="Laptop" price={60000} quantity={2} />
        </div>

        <h2>Assignment 4: Skill List</h2>
        <div className="assignment-block">
          <SkillList skills={mySkills} />
        </div>
      </div>  
    </div>
  );
}

export default App;
