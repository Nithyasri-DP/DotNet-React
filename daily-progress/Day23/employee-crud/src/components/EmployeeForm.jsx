import { useState } from "react";

export default function EmployeeForm({onAdd})
{
    const empty = {name:"", department:"", salary:""};
    const [formData, setFormData] = useState(empty);

    const handleChange = (e) => {
        setFormData ({...formData, [e.target.name] : e.target.value});
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        onAdd(
            {
               name : formData.name.trim(),
               department : formData.department.trim(),
               salary : parseFloat(formData.salary),
            }
        );
        setFormData(empty)
    };

    return(
        <div className="mb-3">
            <h3> Add new Employee </h3>
            <form onSubmit={handleSubmit} className="row g-3">
                <div className="col-md-4">
                    <input
                        type = "text"
                        name = "name"
                        placeholder= "Enter Name"
                        className="form-control"
                        value={formData.name}
                        onChange={handleChange}
                        required/>
                </div>
                <div className="col-md-4">
                      <input
                        type = "text"
                        name = "department"
                        placeholder= "Enter Department"
                        className="form-control"
                        value={formData.department}
                        onChange={handleChange}
                        required/>
                </div>
                 <div className="col-md-4">
                      <input
                        type = "number"
                        name = "salary"
                        placeholder= "Enter Salary"
                        className="form-control"
                        value={formData.salary}
                        onChange={handleChange}
                        required/>
                </div>                
                <button type = "submit" className="btn btn-success"> Add new Employee</button>
            </form>
        </div>
    );
}