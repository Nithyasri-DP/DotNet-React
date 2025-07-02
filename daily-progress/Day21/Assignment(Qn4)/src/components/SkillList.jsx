import React from "react";

function SkillList({ skills }) {
  return (
    <div style={styles.card}>
      <h2>Skills</h2>
      <ul>
        {skills.map((skill, index) => (
          <li key={index}>{skill}</li>  
        ))}
      </ul>
    </div>
  );
}

const styles = {
  card: {
    border: "1px solid #ccc",
    padding: "15px",
    borderRadius: "8px",
    width: "300px",
    marginBottom: "20px",
    backgroundColor: "#f9f9f9",
    textAlign: "left",
  }
};

export default SkillList;
