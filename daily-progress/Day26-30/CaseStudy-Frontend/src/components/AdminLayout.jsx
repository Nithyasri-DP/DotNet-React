import React, { useState } from 'react';
import { Link, useLocation, useNavigate, Outlet } from 'react-router-dom';
import Navbar from './Navbar';
import { Modal, Button } from 'react-bootstrap';
import bgthree from '../assets/bgthree.jpg';

const AdminLayout = () => {
  const [sidebarVisible, setSidebarVisible] = useState(true);
  const [showLogoutModal, setShowLogoutModal] = useState(false);
  const location = useLocation();
  const navigate = useNavigate();

  const toggleSidebar = () => setSidebarVisible(!sidebarVisible);

  const handleLogoutConfirm = () => {
    sessionStorage.clear();
    setShowLogoutModal(false);
    navigate('/');
  };

  const linkStyle = (path) =>
    `nav-link ${location.pathname === path ? 'active-link fw-bold text-primary' : 'text-white'}`;

  return (
    <div
      className="d-flex flex-column min-vh-100"
      style={{
        backgroundImage: `url(${bgthree})`,
        backgroundSize: 'cover',
        backgroundRepeat: 'no-repeat',
        backgroundPosition: 'center',
      }}
    >
      {/* Top Navbar */}
      <Navbar
        title="Admin Dashboard"
        onToggleSidebar={toggleSidebar}
        isSidebarVisible={sidebarVisible}
      />

      <div className="d-flex flex-grow-1" style={{ backdropFilter: 'blur(4px)' }}>
        {/* Sidebar */}
        <div
          className={`border-end text-white ${sidebarVisible ? 'd-block' : 'd-none'}`}
          style={{
            width: '240px',
            minHeight: '100%',
            transition: 'width 0.3s ease',
            backgroundColor: '#376ea5ff',
          }}
        >
          <div className="p-3">
            <h5 className="text-white">Key Functions</h5>
            <ul className="nav flex-column mt-4">
              <li className="nav-item">
                <Link to="/admin/dashboard" className={linkStyle('/admin/dashboard')}>
                  Dashboard
                </Link>
              </li>
              <li className="nav-item">
                <Link to="/admin/employees" className={linkStyle('/admin/employees')}>
                  Employees
                </Link>
              </li>
              <li className="nav-item">
                <Link to="/admin/assets" className={linkStyle('/admin/assets')}>
                  Assets
                </Link>
              </li>
              <li className="nav-item">
                <Link to="/admin/assigned-assets" className={linkStyle('/admin/assigned-assets')}>
                  Assets History
                </Link>
              </li>
              <li className="nav-item">
                <Link to="/admin/categories" className={linkStyle('/admin/categories')}>
                  Asset Categories
                </Link>
              </li>
              <li className="nav-item">
                <Link to="/admin/pending-requests" className={linkStyle('/admin/pending-requests')}>
                  Asset Requests
                </Link>
              </li>
              <li className="nav-item">
                <Link to="/admin/return-requests" className={linkStyle('/admin/return-requests')}>
                  Return Requests
                </Link>
              </li>
              <li className="nav-item">
                <Link to="/admin/service-requests" className={linkStyle('/admin/service-requests')}>
                  Service Requests
                </Link>
              </li>
              <li className="nav-item">
                <Link to="/admin/audit-requests" className={linkStyle('/admin/audit-requests')}>
                  Audit Requests
                </Link>
              </li>
              <li className="nav-item mt-3">
                <button
                  className="btn btn-outline-light btn-sm w-100"
                  onClick={() => setShowLogoutModal(true)}
                >
                  Logout
                </button>
              </li>
            </ul>
          </div>
        </div>

        <div className="flex-grow-1 bg-white bg-opacity-50 overflow-auto" style={{ minHeight: '100%' }}>
          <div className="container-fluid p-3 p-md-4">
            <Outlet />
          </div>
        </div>
      </div>

      <Modal show={showLogoutModal} onHide={() => setShowLogoutModal(false)} centered>
        <Modal.Header closeButton>
          <Modal.Title>Confirm Logout</Modal.Title>
        </Modal.Header>
        <Modal.Body>Are you sure you want to logout?</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setShowLogoutModal(false)}>
            Cancel
          </Button>
          <Button variant="danger" onClick={handleLogoutConfirm}>
            Logout
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default AdminLayout;
