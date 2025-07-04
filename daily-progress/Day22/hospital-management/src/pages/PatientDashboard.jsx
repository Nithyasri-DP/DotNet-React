import { useEffect, useState } from "react";

function PatientDashboard() {
  const [appointments, setAppointments] = useState([]);

  useEffect(() => {
    const stored = JSON.parse(localStorage.getItem("appointments")) || [];
    setAppointments(stored);
  }, []);

  return (
    <div className="container mt-4">
      <h2 className="mb-4">Your Appointments</h2>
      {appointments.length === 0 ? (
        <p>No appointments found.</p>
      ) : (
        <ul>
        {appointments.map((appt, index) => (
            <li key={index}>
            <strong>{appt.doctorName}</strong> on <em>{appt.date}</em> at{" "}
            {appt.time} — Booked for <strong>{appt.patientName}</strong>
            </li>
        ))}
        </ul>

    )}
    </div>
  );
}

export default PatientDashboard;
