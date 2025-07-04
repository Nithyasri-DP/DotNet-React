import { useAuth } from "../auth/AuthContext";
import { useState, useEffect } from "react";

function DoctorDashboard() {
  const { user } = useAuth();
  const [appointments, setAppointments] = useState([]);

  useEffect(() => {
    const allAppointments = JSON.parse(localStorage.getItem("appointments")) || [];
    const myAppointments = allAppointments.filter(
      (appt) => appt.doctorName === user?.username // or match by ID if available
    );
    setAppointments(myAppointments);
  }, [user]);

  return (
    <div className="container mt-4">
      <h3>Welcome Dr. {user?.username}</h3>

      <h5 className="mt-4">Appointments Booked:</h5>
      {appointments.length === 0 ? (
        <p>No appointments yet.</p>
      ) : (
        <ul className="list-group">
          {appointments.map((appt, idx) => (
            <li key={idx} className="list-group-item">
              Patient: <strong>{appt.patientName}</strong> — Date: <em>{appt.date}</em> at {appt.time}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default DoctorDashboard;

