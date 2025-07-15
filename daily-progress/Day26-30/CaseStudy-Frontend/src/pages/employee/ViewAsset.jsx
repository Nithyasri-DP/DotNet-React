import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import axiosInstance from '../../services/axiosInstance';
import { Card, Button, Alert, Modal, Row, Col } from 'react-bootstrap';

const ViewAsset = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [asset, setAsset] = useState(null);
  const [error, setError] = useState('');
  const [successMessage, setSuccessMessage] = useState('');
  const [requesting, setRequesting] = useState(false);
  const [showModal, setShowModal] = useState(false);

  useEffect(() => {
    const fetchAsset = async () => {
      try {
        const response = await axiosInstance.get(`/Asset/employee-view/${id}`);
        setAsset(response.data);
        setError('');
      } catch (err) {
        setError('Failed to load asset details');
        console.error(err);
      }
    };

    fetchAsset();
  }, [id]);

  const handleRequest = async () => {
    setRequesting(true);
    setError('');
    setSuccessMessage('');

    try {
      const response = await axiosInstance.post(`/AssetAssignment/request`, {
        assetId: asset.assetId,
        quantity: 1
      });
      setSuccessMessage(response.data.message || 'Request submitted.');
    } catch (err) {
      const msg = err.response?.data?.error || 'Failed to request asset.';
      setError(msg);
    } finally {
      setRequesting(false);
      setShowModal(false); 
    }
  };

  const handleShowModal = () => setShowModal(true);
  const handleCloseModal = () => setShowModal(false);

  if (error && !asset) {
    return <div className="alert alert-danger mt-4">{error}</div>;
  }

  if (!asset) return <p className="mt-4">Loading asset details...</p>;

  return (
    <div className="container mt-4">
      {error && <Alert variant="danger">{error}</Alert>}
      {successMessage && <Alert variant="success">{successMessage}</Alert>}

      <Card className="shadow-sm p-3">
        <Row>
          <Col md={5} className="d-flex align-items-center justify-content-center">
            <img
              src={asset.imageUrl || '/default-image.jpg'}
              alt={asset.assetName}
              style={{
                maxWidth: '100%',
                maxHeight: '350px',
                objectFit: 'contain',
                borderRadius: '10px',
                boxShadow: '0 4px 8px rgba(0,0,0,0.1)',
              }}
            />
          </Col>
          <Col md={7}>
            <Card.Body>
              <Card.Title>{asset.assetName}</Card.Title>
              <Card.Text><strong>Category:</strong> {asset.categoryName}</Card.Text>
              <Card.Text><strong>Model:</strong> {asset.assetModel}</Card.Text>
              <Card.Text><strong>Quantity:</strong> {asset.quantity}</Card.Text>
              <Card.Text><strong>Status:</strong> {asset.quantity > 0 ? 'Available' : 'Out of Stock'}</Card.Text>
              <Card.Text><strong>Manufacturing Date:</strong> {asset.manufacturingDate.split('T')[0]}</Card.Text>
              <Card.Text><strong>Expiry Date:</strong> {asset.expiryDate.split('T')[0]}</Card.Text>

              <div className="d-flex justify-content-end gap-2">
                <Button variant="secondary" onClick={() => navigate('/employee/available-assets')}>
                  Back
                </Button>
                <Button
                  variant="success"
                  onClick={handleShowModal}
                  disabled={requesting || asset.quantity === 0}
                >
                  {requesting ? 'Requesting...' : 'Request Asset'}
                </Button>
              </div>
            </Card.Body>
          </Col>
        </Row>
      </Card>

      {/* Request Confirmation Modal */}
      <Modal show={showModal} onHide={handleCloseModal} centered>
        <Modal.Header closeButton>
          <Modal.Title>Confirm Asset Request</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Are you sure you want to request the asset{' '}
          <strong>{asset?.assetName}</strong>?
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleCloseModal}>
            Cancel
          </Button>
          <Button variant="success" onClick={handleRequest}>
            Yes, Request
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default ViewAsset;
