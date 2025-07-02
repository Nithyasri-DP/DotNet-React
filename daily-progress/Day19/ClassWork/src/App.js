import './App.css';
import Home from "./component/Home";
import ConditionalRendering from "./component/ConditionalRendering";
import TaskCard from "./component/TaskCard";
import EventHandling from "./component/EventHandling";

function App() {
  // Sample task data
  const tasks = [
    {
      title: "Todo Task",
      description: "Update the status",
      status: "In Progress",
    },
    {
      title: "Frontend Development",
      description: "Complete UI",
      status: "Pending",
    },
    {
      title: "Backend Development",
      description: "Finish API",
      status: "Completed",
    },
  ];

  return (
    <div className="App">      
      <Home />
      <ConditionalRendering />
      <EventHandling />
      <h2 style={{ textAlign: "center" }}>Task List</h2>
      {tasks.map((task, index) => (
        <TaskCard key={index} task={task} />
      ))}
    </div>
  );
}

export default App;
