import React, { useEffect, useState } from 'react';
import { getMyProfile } from '../../services/employeeService';

const EmployeeProfile = () => {
  const [profile, setProfile] = useState(null);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchProfile = async () => {
      try {
        const data = await getMyProfile();
        setProfile(data);
      } catch (err) {
        setError('Failed to load profile');
      }
    };

    fetchProfile();
  }, []);

  return (
    <div className="container py-4">
      <h2 className="mb-4">Employee Profile</h2>

      {error && <div className="alert alert-danger">{error}</div>}

      {profile && (
        <div className="card shadow-sm p-4">
          <p><strong>Full Name:</strong> {profile.fullName}</p>
          <p><strong>Email:</strong> {profile.email}</p>
          <p><strong>Phone Number:</strong> {profile.phoneNumber}</p>
          <p><strong>Address:</strong> {profile.address}</p>
          <p><strong>Role:</strong> {profile.role}</p>
        </div>
      )}
    </div>
  );
};

export default EmployeeProfile;
