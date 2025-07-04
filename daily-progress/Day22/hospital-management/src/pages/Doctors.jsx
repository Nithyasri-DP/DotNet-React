import { Link, useParams } from "react-router-dom";

const doctors = [
    {id:1, name:"Lakshmi", department:"General"},
    {id:2, name:"Latha", department:"General"},
    {id:3, name:"Sharmi", department:"Dental"},
    {id:4, name:"Vedha", department:"ENT"},
]

function Doctors(){
    const {department} = useParams();
    const filteredDoctors = doctors.filter(doc => doc.department === department);
    return (
        <div className="container mt-4">
            <h3 className="mb-4"> Doctors Available in {department} </h3>
            <div className="row justify-content-center">
                {filteredDoctors.map((doc)=>(
                    <div className="col-md-4" key={doc.id}>
                    <div className="card">
                        <div className="card-body">
                          <h5 className="card-title">{doc.name}</h5>
                            <Link to = {`/book/${doc.id}`}  className="btn btn-primary">Book Appointment</Link>
                    </div>
                    </div>    
                    </div>
                ))}
            </div>
        </div>
    );
}

export default Doctors;