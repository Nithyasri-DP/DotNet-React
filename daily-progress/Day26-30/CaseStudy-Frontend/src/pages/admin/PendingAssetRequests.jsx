import React, { useEffect, useState } from 'react';
import {getPendingAssetRequests, approveAssetRequest, rejectAssetRequest} from '../../services/adminService';
import { Modal, Button, Alert } from 'react-bootstrap';

const PendingAssetRequests = () => {
  const [requests, setRequests] = useState([]);
  const [error, setError] = useState('');
  const [successMessage, setSuccessMessage] = useState('');
  const [processingId, setProcessingId] = useState(null);

  const [selectedRequest, setSelectedRequest] = useState(null);
  const [modalType, setModalType] = useState(''); 
  const [showModal, setShowModal] = useState(false);

  const fetchRequests = async () => {
    try {
      const data = await getPendingAssetRequests();
      setRequests(data);
    } catch (err) {
      setError('Failed to load pending requests.');
    }
  };

  useEffect(() => {
    fetchRequests();
  }, []);

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

  const handleConfirm = async () => {
    if (!selectedRequest) return;
    const { assignmentId } = selectedRequest;

    setProcessingId(assignmentId);
    setSuccessMessage('');
    setError('');

    try {
      if (modalType === 'approve') {
        const res = await approveAssetRequest(assignmentId);
        setSuccessMessage(res.message || 'Request approved successfully.');
      } else if (modalType === 'reject') {
        const res = await rejectAssetRequest(assignmentId);
        setSuccessMessage(res.message || 'Request rejected successfully.');
      }

      await fetchRequests();
    } catch (err) {
      const errorMsg =
        err?.response?.data?.error ||
        err?.response?.data?.message ||
        err.message ||
        `Failed to ${modalType} request.`;
      setError(errorMsg);
    } finally {
      setProcessingId(null);
      handleCloseModal();
    }
  };

  return (
    <div className="container py-4">
      <h2 className="mb-4">Pending Asset Requests</h2>

      {error && <div className="alert alert-danger">{error}</div>}
      {successMessage && <div className="alert alert-success">{successMessage}</div>}

      {requests.length === 0 ? (
        <div>
          <Alert variant="warning">No pending asset requests found.</Alert>
        </div>
      ) : (
        <div className="table-responsive">
          <table className="table table-bordered align-middle">
            <thead className="table-light">
              <tr>
                <th>#</th>
                <th>Employee</th>
                <th>Asset</th>
                <th>Quantity</th>
                <th>Requested On</th>
                <th>Status</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              {requests.map((req, index) => (
                <tr key={req.assignmentId}>
                  <td>{index + 1}</td>
                  <td>{req.userName}</td>
                  <td>{req.assetName}</td>
                  <td>{req.quantity}</td>
                  <td>{new Date(req.assignedDate).toLocaleDateString()}</td>
                  <td>{req.status}</td>
                  <td>
                    <button
                      className="btn btn-success btn-sm me-2"
                      onClick={() => handleShowModal(req, 'approve')}
                      disabled={processingId === req.assignmentId}
                    >
                      Approve
                    </button>

                    <button
                      className="btn btn-danger btn-sm"
                      onClick={() => handleShowModal(req, 'reject')}
                      disabled={processingId === req.assignmentId}
                    >
                      Reject
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
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
          <strong>{modalType === 'approve' ? 'approve' : 'reject'}</strong> this asset request?
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

export default PendingAssetRequests;
