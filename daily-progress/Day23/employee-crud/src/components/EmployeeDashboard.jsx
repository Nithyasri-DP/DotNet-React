import React from "react";
import {useEffect, useState, useMemo} from "react";
import { EmployeeService } from "../services/EmployeeService";
import DepartmentFilter from "./DepartmentFilter";
import EmployeeForm from "./EmployeeForm";
import EmployeeTable from "./EmployeeTable";

export default function EmployeeDashboard(){
 
    const [employees, setEmployees] = useState([]);
    const [filterDept, setFilterDept] = useState("All");
    const [error, setError] = useState("");

    useEffect(
        () => {EmployeeService 
        .getAll()
        .then(setEmployees)
        .catch(() => setError("Unable to load Employees"));
    }, []);

    const departments = useMemo(
        () => ["All", ...new Set(employees.map((e)=>e.department))],
        [employees]
    );

    const filtered = useMemo(
        () => filterDept==="All" ? employees : employees.filter((e) => e.department === filterDept),
        [employees, filterDept]
    );

    const totalSalary = useMemo(
        () => filtered.reduce((sum,emp) => sum + emp.salary, 0),
        [filtered]
    );

    const handleAdd = async (emp) => {
        try {
            const added = await EmployeeService.add(emp); // already pushed inside service
            setEmployees((prev) => [...prev, added]);    
        } catch {
            setError("Failed to add new Employee");
        }
    };        

    const handleDelete = async(id) => {
        try { 
            await EmployeeService.remove(id)
            setEmployees((prev)=> prev.filter((e)=>e.id!==id));
        }
        catch{
            setError("Unable to delete");
        }
    };

    return (
        <div className="container">
            <h2> Employee Dashboard </h2>
            {error && <div className="alert alert-danger">{error}</div>}

            <DepartmentFilter
            departments={departments}
            value={filterDept}
            onChange={setFilterDept}/>

            <EmployeeTable employees={filtered} onDelete={handleDelete}/>

            <p className="fw-5">Total Salary : {totalSalary} </p>

            <EmployeeForm onAdd={handleAdd}/>
        </div>
    )
};
