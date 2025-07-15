import React from 'react';
import { useNavigate } from 'react-router-dom';

const EmployeeDashboard = () => {
  const navigate = useNavigate();

  const cardItems = [
    {
      title: 'User Profile',
      text: 'View your personal information',
      path: '/employee/my-profile',
      image: '/dashboard/profile.jpg',
    },
    {
      title: 'Owned Asset',
      text: 'Send return asset request or Send service requests',
      path: '/employee/my-assets',
      image: '/dashboard/assetpic.png',
    },
    {
      title: 'Available Assets',
      text: 'Request assets available in inventory',
      path: '/employee/available-assets',
      image: '/dashboard/availasset.png',
    },
    {
      title: 'Audit Responses',
      text: 'Respond to audit requests from admin',
      path: '/employee/audit-responses',
      image: '/dashboard/audit.jpeg',
    },
  ];

  return (
    <>
      <h2 className="mb-4">Welcome, Employee</h2>
      <p className="mb-4">You can quickly access your features below:</p>

      <div className="row">        
        {cardItems.map((item, index) => (
          <div className="col-md-3 d-flex justify-content-center mb-4" key={index}>
            <div
              className="card shadow-sm h-100 d-flex flex-column align-items-center text-center p-3"
              style={{ width: '220px', height: '220px' }}
            >
              <img
                src={item.image}
                alt={item.title}
                className="mb-3"
                style={{ width: '64px', height: '64px', objectFit: 'contain' }}
              />
              <h6 className="fw-bold">{item.title}</h6>
              <p className="small">{item.text}</p>
              <button className="btn btn-outline-primary btn-sm mt-auto" onClick={() => navigate(item.path)}>
                Go
              </button>
            </div>
          </div>
        ))}
      </div>
    </>
  );
};

export default EmployeeDashboard;
