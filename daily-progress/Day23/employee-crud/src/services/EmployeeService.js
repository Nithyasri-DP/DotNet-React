let _employees = [
  { id: 1, name: "Abi", department: "HR", salary: 40000 },
  { id: 2, name: "Divi", department: "Finance", salary: 45000 },
  { id: 3, name: "Kalai", department: "IT", salary: 50000 },
  { id: 4, name: "Rekha", department: "Finance", salary: 45000 },
];

export const EmployeeService = {
  getAll() {
    return Promise.resolve([..._employees]); // return a copy
  },

  add(emp) {
    const newEmp = {...emp,id: Math.max(0, ..._employees.map((e) => e.id)) + 1,};
    _employees.push(newEmp); 
    return Promise.resolve(newEmp);
  },

  remove(id) {
    const initialLength = _employees.length;
    _employees = _employees.filter((e) => e.id !== id);
    return Promise.resolve(_employees.length !== initialLength);
  },
};
