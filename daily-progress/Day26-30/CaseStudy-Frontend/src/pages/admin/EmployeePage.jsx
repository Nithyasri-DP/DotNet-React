import React, { useEffect, useState } from 'react';
import { getAllEmployees, updateEmployee, deleteEmployee } from '../../services/adminService';
import { Modal, Button, Form } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

const EmployeesPage = () => {
  const navigate = useNavigate();
  const [employees, setEmployees] = useState([]);
  const [error, setError] = useState('');
  const [successMessage, setSuccessMessage] = useState('');
  const [showModal, setShowModal] = useState(false);
  const [formData, setFormData] = useState({
    userId: 0,
    fullName: '',
    email: '',
    phoneNumber: '',
    address: '',
    roleName: 'Employee'
  });
  const [errors, setErrors] = useState({});
  const [originalFormData, setOriginalFormData] = useState(null);
  const [filterName, setFilterName] = useState('');
  const [filterAddress, setFilterAddress] = useState('');
  const [currentPage, setCurrentPage] = useState(1);
  const itemsPerPage = 8;

  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [selectedUserIdToDelete, setSelectedUserIdToDelete] = useState(null);

  const [modalError, setModalError] = useState('');
  const [modalSuccess, setModalSuccess] = useState('');

  const fetchEmployees = async () => {
    try {
      const data = await getAllEmployees();
      setEmployees(data);
    } catch (err) {
      setError('Failed to fetch employees');
    }
  };

  useEffect(() => {
    fetchEmployees();
  }, []);

  const handleEditClick = (emp) => {
    const formattedEmp = {
      ...emp,
      roleName: emp.roleName || 'Employee'
    };
    setFormData(formattedEmp);
    setOriginalFormData(formattedEmp);
    setError('');
    setSuccessMessage('');
    setErrors({});
    setModalError('');
    setModalSuccess('');
    setShowModal(true);
  };

  const validateField = (name, value) => {
    let error = '';

    switch (name) {
      case 'fullName':
        if (!value.trim()) error = 'Full Name is required';
        else if (!/^[a-zA-Z\s]+$/.test(value)) error = 'Only letters and spaces allowed';
        break;
      case 'email':
        if (!value.trim()) error = 'Email is required';
        else if (!/^[\w-.]+@([\w-]+\.)+[\w-]{2,4}$/.test(value)) error = 'Invalid email format';
        break;
      case 'phoneNumber':
        if (!value.trim()) error = 'Phone number is required';
        else if (!/^\d{10}$/.test(value)) error = 'Phone number must be 10 digits';
        break;
      case 'address':
        if (!value.trim()) error = 'Address is required';
        break;
      case 'roleName':
        if (!value) error = 'Role is required';
        break;
      default:
        break;
    }

    setErrors(prev => ({ ...prev, [name]: error }));
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
    validateField(name, value);
  };

  const isFormChanged = () => {
    return JSON.stringify(formData) !== JSON.stringify(originalFormData);
  };

  const handleUpdate = async () => {
    try {
      await updateEmployee(formData);
      setModalSuccess('Employee details updated successfully.');
      setModalError('');
      fetchEmployees();
      setTimeout(() => setShowModal(false), 1000);
    } catch (err) {
      if (err.response && err.response.data) {
        const message =
          typeof err.response.data === 'string'
            ? err.response.data
            : err.response.data.message || 'Failed to update employee';
        setModalError(message);
      } else {
        setModalError('Failed to update employee');
      }
      setModalSuccess('');
    }
  };

  const handleDeleteClick = (userId) => {
    setSelectedUserIdToDelete(userId);
    setShowDeleteModal(true);
  };

  const handleDelete = async () => {
    try {
      await deleteEmployee(selectedUserIdToDelete);
      fetchEmployees();
      setShowDeleteModal(false);
      setSelectedUserIdToDelete(null);
    } catch (err) {
      setError('Failed to delete employee');
    }
  };

  const filteredEmployees = employees.filter(emp =>
    emp.fullName.toLowerCase().includes(filterName.toLowerCase()) &&
    emp.address?.toLowerCase().includes(filterAddress.toLowerCase())
  );

  const totalPages = Math.ceil(filteredEmployees.length / itemsPerPage);
  const paginatedEmployees = filteredEmployees.slice(
    (currentPage - 1) * itemsPerPage,
    currentPage * itemsPerPage
  );

  return (
    <div className="py-2">
      <div className="d-flex justify-content-between align-items-center mb-3">
        <h3>Manage Employees</h3>
        <button className="btn btn-success" onClick={() => navigate('/admin/add-employee')}>
          + Add Employee
        </button>
      </div>

      <div className="mb-3 row">
        <div className="col-md-6 mb-2">
          <Form.Control
            type="text"
            placeholder="Search by name"
            value={filterName}
            onChange={(e) => setFilterName(e.target.value)}
          />
        </div>
        <div className="col-md-6 mb-2">
          <Form.Control
            type="text"
            placeholder="Search by location"
            value={filterAddress}
            onChange={(e) => setFilterAddress(e.target.value)}
          />
        </div>
      </div>

      {error && <div className="alert alert-danger">{error}</div>}
      {successMessage && <div className="alert alert-success">{successMessage}</div>}

      <div className="table-responsive">
        <table className="table table-bordered table-striped align-middle text-nowrap w-100">
          <thead className="table-dark">
            <tr>
              <th>ID</th>
              <th>Full Name</th>
              <th>Email</th>
              <th>Phone</th>
              <th>Location</th>
              <th>Role</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {paginatedEmployees.length > 0 ? (
              paginatedEmployees.map((emp) => (
                <tr key={emp.userId}>
                  <td>{emp.userId}</td>
                  <td>{emp.fullName}</td>
                  <td>{emp.email}</td>
                  <td>{emp.phoneNumber || '-'}</td>
                  <td>{emp.address || '-'}</td>
                  <td>{emp.role}</td>
                  <td>
                    <button className="btn btn-info btn-sm me-2" onClick={() => navigate(`/admin/employee/${emp.userId}`)}>
                      View
                    </button>
                    <button className="btn btn-warning btn-sm me-2" onClick={() => handleEditClick(emp)}>
                      Edit
                    </button>
                    <button className="btn btn-danger btn-sm" onClick={() => handleDeleteClick(emp.userId)}>
                      Delete
                    </button>
                  </td>
                </tr>
              ))
            ) : (
              <tr>
                <td colSpan="7" className="text-center">No employees found.</td>
              </tr>
            )}
          </tbody>
        </table>
      </div>

      {totalPages > 1 && (
        <div className="d-flex justify-content-center align-items-center mt-3 gap-2">
          <Button
            variant="secondary"
            size="sm"
            disabled={currentPage === 1}
            onClick={() => setCurrentPage(prev => prev - 1)}
          >
            « Prev
          </Button>
          {[...Array(totalPages)].map((_, i) => (
            <Button
              key={i}
              size="sm"
              variant={i + 1 === currentPage ? 'primary' : 'outline-primary'}
              onClick={() => setCurrentPage(i + 1)}
            >
              {i + 1}
            </Button>
          ))}
          <Button
            variant="secondary"
            size="sm"
            disabled={currentPage === totalPages}
            onClick={() => setCurrentPage(prev => prev + 1)}
          >
            Next »
          </Button>
        </div>
      )}

      {/* Edit Modal */}
      <Modal show={showModal} onHide={() => setShowModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>Edit Employee</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {modalError && <div className="alert alert-danger">{modalError}</div>}
          {modalSuccess && <div className="alert alert-success">{modalSuccess}</div>}
          <Form>
            <Form.Group className="mb-2">
              <Form.Label>Full Name</Form.Label>
              <Form.Control
                type="text"
                name="fullName"
                value={formData.fullName}
                onChange={handleInputChange}
                isInvalid={!!errors.fullName}
              />
              <Form.Control.Feedback type="invalid">
                {errors.fullName}
              </Form.Control.Feedback>
            </Form.Group>

            <Form.Group className="mb-2">
              <Form.Label>Email</Form.Label>
              <Form.Control
                type="email"
                name="email"
                value={formData.email}
                onChange={handleInputChange}
                isInvalid={!!errors.email}
              />
              <Form.Control.Feedback type="invalid">
                {errors.email}
              </Form.Control.Feedback>
            </Form.Group>

            <Form.Group className="mb-2">
              <Form.Label>Phone</Form.Label>
              <Form.Control
                type="text"
                name="phoneNumber"
                value={formData.phoneNumber}
                onChange={handleInputChange}
                isInvalid={!!errors.phoneNumber}
              />
              <Form.Control.Feedback type="invalid">
                {errors.phoneNumber}
              </Form.Control.Feedback>
            </Form.Group>

            <Form.Group className="mb-2">
              <Form.Label>Address</Form.Label>
              <Form.Control
                type="text"
                name="address"
                value={formData.address}
                onChange={handleInputChange}
                isInvalid={!!errors.address}
              />
              <Form.Control.Feedback type="invalid">
                {errors.address}
              </Form.Control.Feedback>
            </Form.Group>

            <Form.Group>
              <Form.Label>Role</Form.Label>
              <Form.Select
                name="roleName"
                value={formData.roleName}
                onChange={handleInputChange}
                isInvalid={!!errors.roleName}
              >
                <option value="Employee">Employee</option>
              </Form.Select>
              <Form.Control.Feedback type="invalid">
                {errors.roleName}
              </Form.Control.Feedback>
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setShowModal(false)}>Cancel</Button>
          <Button variant="primary" onClick={handleUpdate} disabled={!isFormChanged()}>
            Save Changes
          </Button>
        </Modal.Footer>
      </Modal>

      {/* Delete Confirmation Modal */}
      <Modal show={showDeleteModal} onHide={() => setShowDeleteModal(false)} centered>
        <Modal.Header closeButton>
          <Modal.Title>Confirm Deletion</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Are you sure you want to delete this employee?
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setShowDeleteModal(false)}>Cancel</Button>
          <Button variant="danger" onClick={handleDelete}>Yes, Delete</Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default EmployeesPage;
