import { Link } from "react-router-dom";

const departments = [
    { id:1, name:"General"}, 
    { id:2, name:"Dental"},
    { id:3, name:"ENT"},
]

function Departments () {
    return (
        <div className="container mt-4">
            <h2 className="mb-4"> Departments List </h2>
                <div className="row justify-content-center">
                    {departments.map((dept)=> (
                        <div className="col-md-4" key={dept.id}>
                            <div className="card h=300 p-4">
                                <div className="card-body">
                                    <h5 className="card-title">{dept.name}</h5>
                                        <Link to = {`/doctors/${dept.name}`} className="btn btn-primary"> View Doctors </Link>
                                </div>
                            </div>
                        </div>                                
                    ))}
                </div>
        </div>
    ); 
}

export default Departments;