import EmployeeRow from "./EmployeeRow";

export default function EmployeeTable({employees, onDelete}){
    return(
        <table className="table table-bordered">
            <thead className="table-dark">
                <tr>
                    <td>ID</td>
                    <td>Name</td>
                    <td>Department</td>
                    <td>Salary</td>
                    <td>Actions</td>
                </tr>
            </thead>
            <tbody>
                {employees.length ? (employees.map((emp) => (
                    <EmployeeRow key={emp.id} emp={emp} onDelete={onDelete}/> ))) :
                  (<tr>
                        <td className="text-center text-muted"> No Employees Found</td>
                    </tr>
                  )
                }                
            </tbody>
        </table>
    );
}