import React from "react";
import "./TaskCard.css"; 
export default function TaskCard({ task }) {
  const cardStyle = {
    border: "1px solid blue",
    borderRadius: "5px",
    padding: "15px",
    marginBottom: "10px",
    boxShadow: "0 2px 5px rgba(0,0,0,0.2)",
  };

  const statusColor = {
    Pending: "#FFFF00",
    "In Progress": "#0000FF",
    Completed: "#008000",
  };

  // Convert status to lowercase for dynamic class
  const statusClass = task.status.toLowerCase().replace(" ", "-");

  return (
    <div className="taskContainer">
      <div className={`taskCard ${statusClass}`} style={cardStyle}>
        <h3>{task.title}</h3>
        <p>{task.description}</p>
        <p
          style={{
            color: statusColor[task.status],
            fontWeight: "bold",
          }}
        >
          Status: {task.status}
        </p>
      </div>
    </div>
  );
}
