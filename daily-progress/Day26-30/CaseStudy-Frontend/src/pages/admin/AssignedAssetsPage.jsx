import React, { useEffect, useState } from 'react';
import axiosInstance from '../../services/axiosInstance';
import { Table, Spinner, Alert, Form, Row, Col, Button, Modal, Card } from 'react-bootstrap';

const AssignedAssetsPage = () => {
  const [assignedAssets, setAssignedAssets] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');
  const [statusFilter, setStatusFilter] = useState('All');
  const [searchEmployee, setSearchEmployee] = useState('');
  const [searchAsset, setSearchAsset] = useState('');
  const [currentPage, setCurrentPage] = useState(1);
  const [notification, setNotification] = useState(null);
  const itemsPerPage = 8;

  const [showConfirm, setShowConfirm] = useState(false);
  const [selectedAssignmentId, setSelectedAssignmentId] = useState(null);

  useEffect(() => {
    const fetchAssignedAssets = async () => {
      try {
        const response = await axiosInstance.get('/AssetAssignment/all-assigned-assets');
        setAssignedAssets(response.data);
      } catch (err) {
        setError('Failed to load assigned assets');
      } finally {
        setLoading(false);
      }
    };

    fetchAssignedAssets();
  }, []);

  const filteredAssets = assignedAssets.filter(item => {
    const matchStatus = statusFilter === 'All' || item.status === statusFilter;
    const matchEmployee = item.userName.toLowerCase().includes(searchEmployee.toLowerCase());
    const matchAsset = item.assetName.toLowerCase().includes(searchAsset.toLowerCase());
    return matchStatus && matchEmployee && matchAsset;
  });

  const indexOfLastItem = currentPage * itemsPerPage;
  const indexOfFirstItem = indexOfLastItem - itemsPerPage;
  const currentItems = filteredAssets.slice(indexOfFirstItem, indexOfLastItem);
  const totalPages = Math.ceil(filteredAssets.length / itemsPerPage);

  const handleNext = () => {
    if (currentPage < totalPages) setCurrentPage(prev => prev + 1);
  };

  const handlePrevious = () => {
    if (currentPage > 1) setCurrentPage(prev => prev - 1);
  };

  const openConfirmModal = (assignmentId) => {
    setSelectedAssignmentId(assignmentId);
    setShowConfirm(true);
  };

  const confirmAuditRequest = async () => {
    try {
      await axiosInstance.post(`/AuditRequest?assignmentId=${selectedAssignmentId}`);
      setNotification({ type: 'success', message: 'Audit request sent successfully.' });
    } catch (error) {
      setNotification({ type: 'danger', message: 'Audit already requested or failed to send.' });
    } finally {
      setShowConfirm(false);
      setSelectedAssignmentId(null);
    }
  };

  if (loading) return <Spinner animation="border" className="mt-4" />;
  if (error) return <Alert variant="danger" className="mt-4">{error}</Alert>;

  return (
    <div className="container mt-4">
      <h4 className="mb-4">Assets Allocation List</h4>

      {notification && (
        <Card className={`mb-3 border-${notification.type}`}>
          <Card.Body className={`text-${notification.type}`}>{notification.message}</Card.Body>
        </Card>
      )}

      <Row className="mb-3">
        <Col md={4}>
          <Form.Control
            type="text"
            placeholder="Search by Employee Name"
            value={searchEmployee}
            onChange={(e) => {
              setSearchEmployee(e.target.value);
              setCurrentPage(1);
            }}
          />
        </Col>
        <Col md={4}>
          <Form.Control
            type="text"
            placeholder="Search by Asset Name"
            value={searchAsset}
            onChange={(e) => {
              setSearchAsset(e.target.value);
              setCurrentPage(1);
            }}
          />
        </Col>
        <Col md={4}>
          <Form.Select
            value={statusFilter}
            onChange={(e) => {
              setStatusFilter(e.target.value);
              setCurrentPage(1);
            }}
          >
            <option value="All">All</option>
            <option value="Assigned">Assigned</option>
            <option value="Returned">Returned</option>
            <option value="Rejected">Rejected</option>
          </Form.Select>
        </Col>
      </Row>

      <Table striped bordered hover>
        <thead className="table-dark">
          <tr>
            <th>Employee</th>
            <th>Asset</th>
            <th>Model</th>
            <th>Category</th>
            <th>Quantity</th>
            <th>Status</th>
            <th>Assigned Date</th>
            <th>Return Date</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {currentItems.map((item) => (
            <tr key={item.assignmentId}>
              <td>{item.userName}</td>
              <td>{item.assetName}</td>
              <td>{item.assetModel}</td>
              <td>{item.categoryName}</td>
              <td>{item.quantity}</td>
              <td>{item.status}</td>
              <td>{item.assignedDate?.split('T')[0]}</td>
              <td>{item.returnDate ? item.returnDate.split('T')[0] : 'Not Returned'}</td>
              <td>           
                {item.status === 'Returned' ? (
                  <Button variant="secondary" size="sm" disabled>
                    Already Returned
                  </Button>
                ) : item.status === 'Rejected' ? (
                  <Button variant="danger" size="sm" disabled>
                    Rejected
                  </Button>
                ) : (
                  <Button
                    variant="success"
                    size="sm"
                    onClick={() => openConfirmModal(item.assignmentId)}
                  >
                    Request Audit
                  </Button>
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </Table>

      {totalPages > 1 && (
        <div className="d-flex justify-content-center align-items-center mt-3 gap-2">
          <Button
            variant="secondary"
            size="sm"
            disabled={currentPage === 1}
            onClick={handlePrevious}
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
            onClick={handleNext}
          >
            Next »
          </Button>
        </div>
      )}

      <Modal show={showConfirm} onHide={() => setShowConfirm(false)} centered>
        <Modal.Header closeButton>
          <Modal.Title>Confirm Audit Request</Modal.Title>
        </Modal.Header>
        <Modal.Body>Are you sure you want to request an audit for this asset?</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setShowConfirm(false)}>
            Cancel
          </Button>
          <Button variant="primary" onClick={confirmAuditRequest}>
            Confirm
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default AssignedAssetsPage;
