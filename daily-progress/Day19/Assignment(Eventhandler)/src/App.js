import React, { useState } from "react";
import "./App.css";

function App() {
  return (
    <div className="App">
      <h2>User Registration Form</h2>
      <UserForm />
    </div>
  );
}

function UserForm() {
  const [formData, setFormData] = useState({
    name: "",
    email: "",
    password: "",
  });

  const [errors, setErrors] = useState({});
  const [successMessage, setSuccessMessage] = useState("");

  // Event: onChange 
  const handleChange = (e) => {
    const { name, value } = e.target;

    setFormData({
      ...formData,
      [name]: value,
    });

    setErrors({
      ...errors,
      [name]: "",
    });
  };

  // Event: onBlur
  const handleBlur = (e) => {
    const { name, value } = e.target;
    let errorMsg = "";

    if (name === "name" && value.trim() === "") {
      errorMsg = "Name is required";
    } else if (name === "email" && !/^\S+@\S+\.\S+$/.test(value)) {
      errorMsg = "Enter a valid email";
    } else if (name === "password" && value.length < 6) {
      errorMsg = "Password must be at least 6 characters";
    }

    setErrors({
      ...errors,
      [name]: errorMsg,
    });
  };

  // Event: onSubmit 
  const handleSubmit = (e) => {
    e.preventDefault(); 

    const newErrors = {};

    if (formData.name.trim() === "") {
      newErrors.name = "Name is required";
    }

    if (!/^\S+@\S+\.\S+$/.test(formData.email)) {
      newErrors.email = "Enter a valid email";
    }

    if (formData.password.length < 6) {
      newErrors.password = "Password must be at least 6 characters";
    }

    if (Object.keys(newErrors).length > 0) {
      setErrors(newErrors);
      setSuccessMessage("");
    } else {
      alert("Form submitted successfully!");
      setSuccessMessage("Form submitted successfully!");

      // Reset form after success
      setFormData({
        name: "",
        email: "",
        password: "",
      });
      setErrors({});
    }
  };

  // Event: onClick 
  const handleReset = () => {
    setFormData({
      name: "",
      email: "",
      password: "",
    });
    setErrors({});
    setSuccessMessage("");
  };

  return (
    <form onSubmit={handleSubmit}> 
      <div>
        <label>Name:</label><br />
        <input
          type="text"
          name="name"
          value={formData.name}
          onChange={handleChange}   
          onBlur={handleBlur}      
        />
        {errors.name && <p className="error">{errors.name}</p>}
      </div>

      <div>
        <label>Email:</label><br />
        <input
          type="email"
          name="email"
          value={formData.email}
          onChange={handleChange}   
          onBlur={handleBlur}      
        />
        {errors.email && <p className="error">{errors.email}</p>}
      </div>

      <div>
        <label>Password:</label><br />
        <input
          type="password"
          name="password"
          value={formData.password}
          onChange={handleChange}   
          onBlur={handleBlur}       
        />
        {errors.password && <p className="error">{errors.password}</p>}
      </div>

      <button type="submit">Submit</button>
      <button type="button" onClick={handleReset} style={{ marginLeft: "10px" }}>
        Reset
      </button>

      {successMessage && <p className="success">{successMessage}</p>}
    </form>
  );
}

export default App;
