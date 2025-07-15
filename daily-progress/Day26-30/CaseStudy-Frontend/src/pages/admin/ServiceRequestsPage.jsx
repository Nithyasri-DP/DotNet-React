import React, { useEffect, useState } from 'react';
import { getAllServiceRequests, updateServiceStatus } from '../../services/adminService';
import { Table, Badge, Form, Modal, Button, Pagination } from 'react-bootstrap';

const ServiceRequestsPage = () => {
  const [requests, setRequests] = useState([]);
  const [filtered, setFiltered] = useState([]);
  const [employeeSearch, setEmployeeSearch] = useState('');
  const [assetSearch, setAssetSearch] = useState('');
  const [statusFilter, setStatusFilter] = useState('All');

  const [showModal, setShowModal] = useState(false);
  const [selectedRequest, setSelectedRequest] = useState(null);
  const [newStatus, setNewStatus] = useState('');

  const [currentPage, setCurrentPage] = useState(1);
  const itemsPerPage = 5;

  useEffect(() => {
    loadRequests();
  }, []);

  const loadRequests = async () => {
    try {
      const data = await getAllServiceRequests();
      setRequests(data);
      setFiltered(data);
    } catch (err) {
      console.error('Failed to load service requests', err);
    }
  };

  useEffect(() => {
    filterRequests();
  }, [employeeSearch, assetSearch, statusFilter, requests]);

  const filterRequests = () => {
    let filteredData = [...requests];

    if (employeeSearch.trim()) {
      filteredData = filteredData.filter(req =>
        req.user.fullName.toLowerCase().includes(employeeSearch.trim().toLowerCase())
      );
    }

    if (assetSearch.trim()) {
      filteredData = filteredData.filter(req =>
        req.asset.assetName.toLowerCase().includes(assetSearch.trim().toLowerCase())
      );
    }

    if (statusFilter !== 'All') {
      filteredData = filteredData.filter(req => req.status.toLowerCase() === statusFilter.toLowerCase());
    }

    setFiltered(filteredData);
    setCurrentPage(1); 
  };

  const getStatusBadgeVariant = (status) => {
    switch (status.toLowerCase()) {
      case 'pending': return 'warning';
      case 'inprogress': return 'info';
      case 'completed': return 'success';
      case 'rejected': return 'danger';
      default: return 'secondary';
    }
  };

  const handleStatusChange = (request, status) => {
    if (status === request.status) return;

    setSelectedRequest(request);
    setNewStatus(status);
    setShowModal(true);
  };

  const confirmStatusUpdate = async () => {
    if (!selectedRequest || !newStatus) return;

    try {
      await updateServiceStatus(selectedRequest.requestId, newStatus);
      setShowModal(false);
      setSelectedRequest(null);
      setNewStatus('');
      loadRequests();
    } catch (err) {
      alert('Failed to update status');
    }
  };
 
  const totalPages = Math.ceil(filtered.length / itemsPerPage);
  const paginatedData = filtered.slice((currentPage - 1) * itemsPerPage, currentPage * itemsPerPage);

  return (
    <div className="container py-4">
      <h3>Service Requests</h3>

      <div className="d-flex justify-content-between mb-3 gap-3">
        <Form.Control
          type="text"
          placeholder="Search by Employee Name"
          value={employeeSearch}
          onChange={(e) => setEmployeeSearch(e.target.value)}
        />
        <Form.Control
          type="text"
          placeholder="Search by Asset Name"
          value={assetSearch}
          onChange={(e) => setAssetSearch(e.target.value)}
        />
        <Form.Select
          value={statusFilter}
          onChange={(e) => setStatusFilter(e.target.value)}
          style={{ maxWidth: '200px' }}
        >
          <option value="All">All Statuses</option>
          <option value="Pending">Pending</option>
          <option value="InProgress">InProgress</option>
          <option value="Completed">Completed</option>
          <option value="Rejected">Rejected</option>
        </Form.Select>
      </div>

      <Table striped bordered hover responsive>
        <thead className="table-dark">
          <tr>
            <th>#</th>
            <th>Asset</th>
            <th>Employee</th>
            <th>Issue</th>
            <th>Description</th>
            <th>Date</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {paginatedData.length === 0 ? (
            <tr>
              <td colSpan="7" className="text-center">No matching records found.</td>
            </tr>
          ) : (
            paginatedData.map((req, index) => (
              <tr key={req.requestId}>
                <td>{(currentPage - 1) * itemsPerPage + index + 1}</td>
                <td>{req.asset.assetName}</td>
                <td>{req.user.fullName}</td>
                <td>{req.issueType}</td>
                <td>{req.description}</td>
                <td>{new Date(req.requestDate).toLocaleDateString()}</td>
                <td>
                  <div className="d-flex align-items-center gap-2">
                    <Badge bg={getStatusBadgeVariant(req.status)} className="text-uppercase">
                      {req.status}
                    </Badge>
                    <Form.Select
                      value={req.status}
                      onChange={(e) => handleStatusChange(req, e.target.value)}
                      size="sm"
                      style={{ width: '130px' }}
                      disabled={['completed', 'rejected'].includes(req.status.toLowerCase())}
                    >
                      <option value="Pending">Pending</option>
                      <option value="InProgress">InProgress</option>
                      <option value="Completed">Completed</option>
                      <option value="Rejected">Rejected</option>
                    </Form.Select>
                  </div>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </Table>

      {/* Pagination */}
      {totalPages > 1 && (
        <div className="d-flex justify-content-center mt-3">
          <Pagination size="sm">
            <Pagination.Prev disabled={currentPage === 1} onClick={() => setCurrentPage(prev => prev - 1)} />
            {[...Array(totalPages)].map((_, i) => (
              <Pagination.Item
                key={i}
                active={currentPage === i + 1}
                onClick={() => setCurrentPage(i + 1)}
              >
                {i + 1}
              </Pagination.Item>
            ))}
            <Pagination.Next disabled={currentPage === totalPages} onClick={() => setCurrentPage(prev => prev + 1)} />
          </Pagination>
        </div>
      )}

      {/* Confirmation Modal */}
      <Modal show={showModal} onHide={() => setShowModal(false)} centered>
        <Modal.Header closeButton>
          <Modal.Title>Confirm Status Update</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Are you sure you want to mark <strong>{selectedRequest?.asset.assetName}</strong> as{' '}
          <strong>{newStatus}</strong>?
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setShowModal(false)}>
            Cancel
          </Button>
          <Button variant="primary" onClick={confirmStatusUpdate}>
            Yes, Update
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default ServiceRequestsPage;
