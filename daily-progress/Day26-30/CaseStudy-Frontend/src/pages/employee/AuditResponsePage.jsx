import React, { useEffect, useState } from 'react';
import { Table, Spinner, Alert, Badge, Modal, Button, Form } from 'react-bootstrap';
import { getMyAuditRequests, respondToAuditRequest } from '../../services/employeeService';

const AuditResponsePage = () => {
  const [auditRequests, setAuditRequests] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  const [selectedAudit, setSelectedAudit] = useState(null);
  const [showModal, setShowModal] = useState(false);
  const [responseStatus, setResponseStatus] = useState('');
  const [remarks, setRemarks] = useState('');

  const fetchAudits = async () => {
    try {
      const res = await getMyAuditRequests();
      setAuditRequests(res);
    } catch (err) {
      setError('Failed to fetch audit requests.');
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchAudits();
  }, []);

  const openModal = (audit) => {
    setSelectedAudit(audit);
    setResponseStatus('');
    setRemarks('');
    setShowModal(true);
  };

  const handleSubmit = async () => {
    try {
      await respondToAuditRequest(selectedAudit.auditId, responseStatus, remarks);
      setShowModal(false);
      fetchAudits();
    } catch (err) {
      alert(err.message || 'Failed to submit audit response.');
    }
  };

  const getStatusVariant = (status) => {
    switch (status.toLowerCase()) {
      case 'verified':
        return 'success';
      case 'rejected':
        return 'danger';
      default:
        return 'warning';
    }
  };

  if (loading) return <Spinner animation="border" className="mt-4" />;
  if (error) return <Alert variant="danger">{error}</Alert>;

  return (
    <div className="container mt-4">
      <h4 className="mb-4">My Audit Requests</h4>

      {auditRequests.length === 0 ? (
        <Alert variant="info">No audit requests available.</Alert>
      ) : (
        <Table striped bordered hover responsive>
          <thead className="table-dark">
            <tr>
              <th>Asset</th>
              <th>Model</th>
              <th>Category</th>
              <th>Requested Date</th>
              <th>Responded Date</th>
              <th>Status</th>
              <th>Remarks</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {auditRequests.map((item) => (
              <tr key={item.auditId}>
                <td>{item.asset?.assetName || '—'}</td>
                <td>{item.asset?.assetModel || '—'}</td>
                <td>{item.asset?.assetCategory?.categoryName || '—'}</td>
                <td>{item.auditRequestDate?.split('T')[0]}</td>
                <td>{item.auditResponseDate?.split('T')[0] || '—'}</td>
                <td>
                <Badge bg={getStatusVariant(item.status)} className="uppercase-badge">{item.status}</Badge>
                </td>
                <td>{item.remarks || '—'}</td>
                <td>
                  {item.status.toLowerCase() === 'pending' ? (
                    <Button size="sm" onClick={() => openModal(item)}>
                      Respond
                    </Button>
                  ) : (
                    <span className="text-muted">—</span>
                  )}
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      )}

      <Modal show={showModal} onHide={() => setShowModal(false)} centered>
        <Modal.Header closeButton>
          <Modal.Title>Submit Audit Response</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form.Group className="mb-3">
            <Form.Label>Status</Form.Label>
            <Form.Select
              value={responseStatus}
              onChange={(e) => setResponseStatus(e.target.value)}
            >
              <option value="">Select status</option>
              <option value="Verified">Verified</option>
              <option value="Rejected">Rejected</option>
            </Form.Select>
          </Form.Group>
          <Form.Group>
            <Form.Label>Remarks</Form.Label>
            <Form.Control
              as="textarea"
              rows={3}
              value={remarks}
              onChange={(e) => setRemarks(e.target.value)}
              placeholder="Optional remarks"
            />
          </Form.Group>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setShowModal(false)}>
            Cancel
          </Button>
          <Button
            variant="primary"
            onClick={handleSubmit}
            disabled={!responseStatus}
          >
            Submit
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default AuditResponsePage;
