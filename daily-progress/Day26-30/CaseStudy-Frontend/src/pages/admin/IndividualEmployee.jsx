import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getEmployeeById } from '../../services/adminService';

const IndividualEmployee = () => {
  const { id } = useParams();
  const navigate = useNavigate();

  const [employee, setEmployee] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchEmployee = async () => {
      try {
        const token = sessionStorage.getItem('token');

        console.log('Token:', token);
        console.log('Employee ID:', id);

        if (!token) {
          setError('Unauthorized. Please log in.');
          setLoading(false);
          return;
        }

        const response = await getEmployeeById(id, token);

        console.log(' API Response:', response);

        if (response) {
          setEmployee(response);
        } else {
          setError('Employee not found.');
        }
      } catch (err) {
        console.error(' Error fetching employee:', err);
        setError('Failed to load employee details.');
      } finally {
        setLoading(false);
      }
    };

    fetchEmployee();
  }, [id]);

  console.log('Final employee state:', employee);

  return (
    <div className="container py-4">
      <h3 className="mb-4">Employee Details</h3>

      {loading && <p>Loading...</p>}
      {error && <div className="alert alert-danger">{error}</div>}

      {employee ? (
        <div className="card shadow p-4">
          {console.log("Rendered Employee Object:", employee)}

          <h4 className="mb-3">{employee.fullName ?? 'N/A'}</h4>
          <p><strong>ID:</strong> {employee.userId ?? 'N/A'}</p>
          <p><strong>Email:</strong> {employee.email ?? 'N/A'}</p>
          <p><strong>Phone:</strong> {employee.phoneNumber ?? 'N/A'}</p>
          <p><strong>Address:</strong> {employee.address ?? 'N/A'}</p>
          <p><strong>Role:</strong> {employee.role ?? 'N/A'}</p>

          <button className="btn btn-secondary mt-3" onClick={() => navigate(-1)}>Back</button>
        </div>
      ) : (
        !loading && <p>No employee data available.</p>
      )}
    </div>
  );
};

export default IndividualEmployee;
