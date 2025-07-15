import React, { useState } from 'react';
import { createEmployee } from '../../services/adminService';
import { Form, Button, Alert } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

const AddEmployeeForm = () => {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    fullName: '',
    email: '',
    phoneNumber: '',
    address: '',
    password: '',
    roleName: 'Employee',
  });

  const [errors, setErrors] = useState({});
  const [successMessage, setSuccessMessage] = useState('');
  const [errorMessage, setErrorMessage] = useState('');

  const validateField = (name, value) => {
    let error = '';

    switch (name) {
      case 'fullName':
        if (!value.trim()) error = 'Full Name is required';
        else if (!/^[a-zA-Z\s]+$/.test(value)) error = 'Only letters and spaces are allowed';
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

      case 'password':
        if (!value.trim()) error = 'Password is required';
        else if (!/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$/.test(value)) {
          error = 'Must be 8+ characters, include upper, lower, number & special char';
        }
        break;

      case 'roleName':
        if (!value) error = 'Role is required';
        break;

      default:
        break;
    }

    setErrors(prev => ({ ...prev, [name]: error }));
  };

  const validateForm = () => {
    const fields = Object.keys(formData);
    let valid = true;

    fields.forEach(field => {
      validateField(field, formData[field]);
      if (!formData[field].trim() || errors[field]) {
        valid = false;
      }
    });

    return valid;
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
    validateField(name, value);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setSuccessMessage('');
    setErrorMessage('');

    if (!validateForm()) return;

    try {
      const res = await createEmployee(formData);
      setSuccessMessage(res.message || 'Employee created successfully.');
      setFormData({
        fullName: '',
        email: '',
        phoneNumber: '',
        address: '',
        password: '',
        roleName: 'Employee',
      });
      setErrors({});
    } catch (err) {
      setErrorMessage(err?.response?.data?.error || 'Failed to create employee');
    }
  };

  return (
    <div className="container py-4">
      <h3 className="mb-4">Add New Employee</h3>

      {successMessage && <Alert variant="success">{successMessage}</Alert>}
      {errorMessage && <Alert variant="danger">{errorMessage}</Alert>}

      <Form onSubmit={handleSubmit}>
        <Form.Group className="mb-3">
          <Form.Label>Full Name</Form.Label>
          <Form.Control
            type="text"
            name="fullName"
            value={formData.fullName}
            onChange={handleChange}
            onBlur={(e) => validateField('fullName', formData.fullName)}
            isInvalid={!!errors.fullName}
          />
          <Form.Control.Feedback type="invalid">{errors.fullName}</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Email</Form.Label>
          <Form.Control
            type="email"
            name="email"
            value={formData.email}
            onChange={handleChange}
            onBlur={(e) => validateField('email', formData.email)}
            isInvalid={!!errors.email}
          />
          <Form.Control.Feedback type="invalid">{errors.email}</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Phone Number</Form.Label>
          <Form.Control
            type="text"
            name="phoneNumber"
            value={formData.phoneNumber}
            onChange={handleChange}
            onBlur={(e) => validateField('phoneNumber', formData.phoneNumber)}
            isInvalid={!!errors.phoneNumber}
          />
          <Form.Control.Feedback type="invalid">{errors.phoneNumber}</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Address</Form.Label>
          <Form.Control
            type="text"
            name="address"
            value={formData.address}
            onChange={handleChange}
            onBlur={(e) => validateField('address', formData.address)}
            isInvalid={!!errors.address}
          />
          <Form.Control.Feedback type="invalid">{errors.address}</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Password</Form.Label>
          <Form.Control
            type="password"
            name="password"
            value={formData.password}
            onChange={handleChange}
            onBlur={(e) => validateField('password', formData.password)}
            isInvalid={!!errors.password}
          />
          <Form.Control.Feedback type="invalid">{errors.password}</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Role</Form.Label>
          <Form.Select
            name="roleName"
            value={formData.roleName}
            onChange={handleChange}
            onBlur={(e) => validateField('roleName', formData.roleName)}
            isInvalid={!!errors.roleName}
          >
            <option value="Employee">Employee</option>
          </Form.Select>
          <Form.Control.Feedback type="invalid">{errors.roleName}</Form.Control.Feedback>
        </Form.Group>

        <Button type="submit" variant="primary">Create Employee</Button>
      </Form>

      <div className="mt-4 text-center">
        <button className="btn btn-secondary" onClick={() => navigate('/admin/employees')}>Back to Employees</button>
      </div>
    </div>
  );
};

export default AddEmployeeForm;
