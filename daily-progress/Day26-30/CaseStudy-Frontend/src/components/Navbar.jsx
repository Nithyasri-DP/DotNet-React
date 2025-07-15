import React, { useState } from 'react';
import { Navbar as BSNavbar, Container, Dropdown, Modal, Button } from 'react-bootstrap';

const Navbar = ({ title, onToggleSidebar, isSidebarVisible }) => {
  const userName = sessionStorage.getItem('fullName') || 'Admin';
  const [showLogoutConfirm, setShowLogoutConfirm] = useState(false);

  const handleLogout = () => {
    sessionStorage.clear();
    window.location.href = '/';
  };

  return (
    <>
      <BSNavbar style={{ backgroundColor: '#4A90E2' }} className="shadow-sm mb-0 px-4 py-3">
        <Container fluid className="d-flex justify-content-between align-items-center">
          <h4 className="mb-0 fw-bold text-white">{title}</h4>
          <Dropdown align="end">
            <Dropdown.Toggle
              className="border-0 fw-semibold text-white bg-white bg-opacity-25"
            >
              Welcome, {userName}
            </Dropdown.Toggle>
            <Dropdown.Menu>
              <Dropdown.Item onClick={onToggleSidebar}>
                {isSidebarVisible ? 'Hide Sidebar' : 'Show Sidebar'}
              </Dropdown.Item>
              <Dropdown.Divider />
              <Dropdown.Item onClick={() => setShowLogoutConfirm(true)} className="text-danger">
                Logout
              </Dropdown.Item>
            </Dropdown.Menu>
          </Dropdown>
        </Container>
      </BSNavbar>

      <Modal show={showLogoutConfirm} onHide={() => setShowLogoutConfirm(false)} centered>
        <Modal.Header closeButton>
          <Modal.Title>Confirm Logout</Modal.Title>
        </Modal.Header>
        <Modal.Body>Are you sure you want to log out?</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setShowLogoutConfirm(false)}>Cancel</Button>
          <Button variant="danger" onClick={handleLogout}>Logout</Button>
        </Modal.Footer>
      </Modal>
    </>
  );
};

export default Navbar;
