import React, { useState } from "react";

const initialEmployees = [
    {id:1, name:"Abi", department:"HR", salary:40000},
    {id:2, name:"Divi", department:"Finance", salary:45000},
    {id:3, name:"Kalai", department:"IT", salary:50000},
    {id:4, name:"Rekha", department:"Finance", salary:45000},
]

export default function EmployeeCrud()
{
    const [employees, setEmployees] = useState(initialEmployees);
    const [filterDept, setFilterDept] = useState("All");
    const departments = ["All",...new Set(initialEmployees.map((emp)=>emp.department))];
    const filteredEmployees = filterDept==="All" ? employees : employees.filter((emp)=>emp.department===filterDept);

    const [formData, setFormData] = useState({name:"", department:"", salary:""});
    const handleChange = (e)=> { setFormData ({...formData, [e.target.name] : e.target.value}); };

    const addEmployee = (e) => {
        e.preventDefault();
        const newEmployee = {
            id: employees.length+1,
            name: formData.name,
            department: formData.department,
            salary: parseFloat(formData.salary),
        };
        setEmployees([...employees, newEmployee]);
        setFormData({name:"", department:"", salary:""});
    };

    const deleteEmployee = (id) => {
        setEmployees(employees.filter((emp)=> emp.id!==id));
    };

    const totalSalary = filteredEmployees.reduce((sum,emp) => sum + emp.salary,0);

    return (
        <div className="container p-4">
            <h2>Employee Dashboard</h2>
            <label> Filter By Department </label>
            <select value={filterDept} onChange={(e)=>setFilterDept(e.target.value)}>
                {departments.map((dept,idx)=>
                <option key={idx} value={dept}> {dept} </option>
                )}
            </select>
            <div className="d-flex justify-content-center">
            <table className="table table-bordered w-50">
                <thead className="table-dark">
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Department</th>
                        <th>Salary</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {filteredEmployees.map((emp) => 
                    <tr key={emp.id}>
                        <td>{emp.id}</td>
                        <td>{emp.name}</td>
                        <td>{emp.department}</td>
                        <td>{emp.salary}</td>
                        <td>
                            <button onClick={()=>deleteEmployee(emp.id)} className="btn btn-danger">Delete Employee</button>
                        </td>
                    </tr>                    
                    )}
                </tbody>
            </table>
            </div>
            <p> 
                <strong>Total Salary: {totalSalary}</strong>
            </p>

            <h3>Adding new Employee</h3> 
            <div className="d-flex justify-content-center">
                <form onSubmit={addEmployee} className="w-50">
                    <input 
                    type = "text"
                    name = "name"
                    placeholder="Enter name"
                    className = "form-control"
                    value = {formData.name}
                    onChange = {handleChange}
                    required/>
                    <br/>

                    <input 
                    type = "text"
                    name = "department"
                    placeholder="Enter department"
                    className = "form-control"
                    value = {formData.department}
                    onChange = {handleChange}
                    required/>
                    <br/>

                    <input 
                    type = "number"
                    name = "salary"
                    placeholder="Enter salary"
                    className = "form-control"
                    value = {formData.salary}
                    onChange = {handleChange}
                    required/>
                    <br/>

                    <button type = "submit" className="btn btn-primary">Add Employee</button>
                </form>
            </div>
        </div>        
    );
}