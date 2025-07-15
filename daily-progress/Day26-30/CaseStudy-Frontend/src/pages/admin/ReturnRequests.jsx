import React, { useEffect, useState } from 'react';
import { getReturnRequests, approveReturnRequest, rejectReturnRequest,} from '../../services/adminService';
import { Button, Table, Modal } from 'react-bootstrap';

const ReturnRequests = () => {
  const [requests, setRequests] = useState([]);
  const [loading, setLoading] = useState(true);

  const [selectedRequest, setSelectedRequest] = useState(null);
  const [modalType, setModalType] = useState(''); 
  const [showModal, setShowModal] = useState(false);

  const fetchRequests = async () => {
    try {
      setLoading(true);
      const data = await getReturnRequests();
      setRequests(data);
    } catch (error) {
      console.error('Failed to load return requests:', error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchRequests();
  }, []);

  const handleConfirm = async () => {
    if (!selectedRequest) return;
    try {
      if (modalType === 'approve') {
        await approveReturnRequest(selectedRequest.assignmentId);
      } else if (modalType === 'reject') {
        await rejectReturnRequest(selectedRequest.assignmentId);
      }
      setShowModal(false);
      setSelectedRequest(null);
      setModalType('');
      fetchRequests();
    } catch (err) {
      console.error(`Error on ${modalType}:`, err);
    }
  };

  const handleShowModal = (request, type) => {
    setSelectedRequest(request);
    setModalType(type);
    setShowModal(true);
  };

  const handleCloseModal = () => {
    setSelectedRequest(null);
    setModalType('');
    setShowModal(false);
  };

  return (
    <div className="container mt-4">
      <h3>Return Requests</h3>
      {loading ? (
        <p>Loading...</p>
      ) : requests.length === 0 ? (
        <div className="mt-3">
          <div className="alert alert-warning">No return requests found.</div>
        </div>
      ) : (
        <Table striped bordered hover responsive>
          <thead>
            <tr>
              <th>Employee</th>
              <th>Asset</th>
              <th>Quantity</th>
              <th>Assigned Date</th>
              <th>Return Date</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {requests.map((req) => (
              <tr key={req.assignmentId}>
                <td>{req.userName}</td>
                <td>{req.assetName}</td>
                <td>{req.quantity}</td>
                <td>{new Date(req.assignedDate).toLocaleDateString()}</td>
                <td>{req.returnDate ? new Date(req.returnDate).toLocaleDateString() : '—'}</td>
                <td>
                  <Button
                    variant="success"
                    size="sm"
                    className="me-2"
                    onClick={() => handleShowModal(req, 'approve')}
                  >
                    Approve
                  </Button>
                  <Button
                    variant="danger"
                    size="sm"
                    onClick={() => handleShowModal(req, 'reject')}
                  >
                    Reject
                  </Button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      )}

      {/* Confirmation Modal */}
      <Modal show={showModal} onHide={handleCloseModal} centered>
        <Modal.Header closeButton>
          <Modal.Title>
            {modalType === 'approve' ? 'Confirm Approval' : 'Confirm Rejection'}
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Are you sure you want to{' '}
          <strong>{modalType === 'approve' ? 'approve' : 'reject'}</strong> this return request?
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleCloseModal}>
            Cancel
          </Button>
          <Button
            variant={modalType === 'approve' ? 'success' : 'danger'}
            onClick={handleConfirm}
          >
            Yes, {modalType === 'approve' ? 'Approve' : 'Reject'}
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default ReturnRequests;
