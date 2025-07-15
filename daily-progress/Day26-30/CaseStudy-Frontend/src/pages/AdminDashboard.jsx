import React from 'react';
import { useNavigate } from 'react-router-dom';

const AdminDashboard = () => {
  const navigate = useNavigate();

  const cardItems = [
    {
      title: 'View Employee',
      text: 'View or Add a new employee to the system',
      path: '/admin/employees',
      image: '/dashboard/empone.jpg',
    },
    {
      title: 'View Asset',
      text: 'View or Add a new asset to the inventory',
      path: '/admin/assets',
      image: '/dashboard/assetpic.png',
    },
    {
      title: 'View Services',
      text: 'Respond to the raised service requests',
      path: '/admin/service-requests',
      image: '/dashboard/service.jpg',
    },
    {
      title: 'Request Audit',
      text: 'Send audit requests or View asset allocation',
      path: '/admin/assigned-assets',
      image: '/dashboard/audit.jpeg',
    },
  ];

  return (
    <>
      <h2 className="mb-4">Welcome, Admin</h2>
      <p className="mb-4">Here are some quick actions you can take:</p>

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
              <button
                className="btn btn-outline-primary btn-sm mt-auto"
                onClick={() => navigate(item.path)}
              >
                Go
              </button>
            </div>
          </div>
        ))}
      </div>
    </>
  );
};

export default AdminDashboard;


