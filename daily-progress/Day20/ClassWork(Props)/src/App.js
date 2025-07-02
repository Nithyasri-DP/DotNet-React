import React, { useState, useEffect } from "react";
import { UserContext } from "./UserContext";
import LoginForm from "./LoginForm";
import Dashboard from "./Dashboard";

function App() {
  const [currentUser, setCurrentUser] = useState(null);

  // Load from localStorage when app starts
  useEffect(() => {
    const storedUser = localStorage.getItem("loggedInUser");
    if (storedUser) {
      setCurrentUser(JSON.parse(storedUser));  // convert back to object
    }
  }, []);

  // When login, save to localStorage
  const handleLogin = (user) => {
    setCurrentUser(user);
    localStorage.setItem("loggedInUser", JSON.stringify(user));
  };

  // User logs out, remove data from localStorage
  const handleLogout = () => {
  setCurrentUser(null);                             
  localStorage.removeItem("loggedInUser");     
  console.log("User logged out");
console.log("LocalStorage after logout:", localStorage.getItem("loggedInUser"));
     
};  

  return (
    <UserContext.Provider value={currentUser}>
      <div className="App">
        {!currentUser ? (
          <LoginForm onLogin={handleLogin} />
        ) : (
          <Dashboard onLogout={handleLogout} />
        )}
      </div>
    </UserContext.Provider>
  );
}

export default App;

