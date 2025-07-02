import React, { useState } from "react";

const EventHandling = () => {
  const [selectedTech, setSelectedTech] = useState("");

  const handleChange = (e) => {
    setSelectedTech(e.target.value);
  };

  return (
    <div style={{ margin: "20px", padding: "10px", border: "1px solid #ccc" }}>
      <h2>Select your preferred technology</h2>
      <select onChange={handleChange}>
        <option value="">-- Select --</option>
        <option value="React">React</option>
        <option value="Angular">Angular</option>
      </select>

      {selectedTech && (
        <p style={{ marginTop: "10px", fontWeight: "bold", color: "green" }}>
          You selected: {selectedTech}
        </p>
      )}
    </div>
  );
};

export default EventHandling;
