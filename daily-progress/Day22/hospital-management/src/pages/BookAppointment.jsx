import { useParams } from "react-router-dom";
import React, {useState} from "react";

const doctors = [
    {id:1, name:"Lakshmi", department:"General"},
    {id:2, name:"Latha", department:"General"},
    {id:3, name:"Sharmi", department:"Dental"},
    {id:4, name:"Vedha", department:"ENT"},
]

function BookAppointment(){
    const{doctorId} = useParams();
    const selectedDoctor = doctors.find(
        (doc) => doc.id === parseInt(doctorId)
    );

    const[formData, setFormData] = useState(
                {
                    name:'',
                    date:'',
                    time:'',
                }
            );

    const handleSubmit = (e) => {
        e.preventDefault();

          const appointment = {
            patientName: formData.name,
            doctorName: selectedDoctor.name,
            date: formData.date,
            time: formData.time,
        };

        // Get existing appointments
        const stored = JSON.parse(localStorage.getItem("appointments")) || [];
        stored.push(appointment);

        localStorage.setItem("appointments", JSON.stringify(stored));
        alert("Appointment booked!");
    };

    return(
        <div className="container mt-4">
            <h3 className="mb-4 text-center"> Booking Appointment with {selectedDoctor.name}</h3>

            {/* Form inputs */}
        <div className="d-flex justify-content-center">
            <form onSubmit = {handleSubmit} className="w-25">
                <div className="mb-3 ">
                <label>Patient Name</label>
                <input 
                    type = "text"
                    className="form-control"
                    value={formData.name}
                    onChange={(e)=>setFormData({...formData, name:e.target.value})}
                />
            </div>
            <div className="mb-3">
                <label>Appointment Date</label>
                <input 
                type="date"
                className="form-control"
                value={formData.date}
                onChange={(e)=>setFormData({...formData, date:e.target.value})}
                />
            </div>
            <div className="mb-3">
                <label>Appointment Time</label>
                <input 
                type ="time"
                className="form-control"
                value={formData.time}
                onChange={(e)=>setFormData({...formData, time:e.target.value})}
                />
            </div>
            <button type = "submit" className="btn btn-primary"> Confirm Appointment </button>
            </form>
        </div>
        </div>
    );
}

export default BookAppointment;