import React, { useEffect, useState } from 'react';
import { getMyAssets, requestReturnAsset, createServiceRequest } from '../../services/employeeService';
import { Modal, Button, Form } from 'react-bootstrap';

const MyAssetsPage = () => {
  const [assets, setAssets] = useState([]);
  const [error, setError] = useState('');
  const [successMsg, setSuccessMsg] = useState('');

  const [selectedAsset, setSelectedAsset] = useState(null);
  const [showReturnModal, setShowReturnModal] = useState(false);
  const [showServiceModal, setShowServiceModal] = useState(false);

  const [issueType, setIssueType] = useState('');
  const [description, setDescription] = useState('');
  const [formError, setFormError] = useState('');

  useEffect(() => {
    loadAssets();
  }, []);

  const loadAssets = async () => {
    try {
      const data = await getMyAssets();
      setAssets(data);
    } catch (err) {
      setError('Failed to load assigned assets');
    }
  };

  const handleConfirmReturn = async () => {
    if (!selectedAsset) return;
    try {
      await requestReturnAsset(selectedAsset.assignmentId);
      setSuccessMsg('Return request submitted successfully.');
      setError('');
      loadAssets();
    } catch (err) {
      setError(err.message);
      setSuccessMsg('');
    } finally {
      setShowReturnModal(false);
      setSelectedAsset(null);
    }
  };

  const handleShowReturnModal = (asset) => {
    setSelectedAsset(asset);
    setShowReturnModal(true);
  };

  const handleShowServiceModal = (asset) => {
    setSelectedAsset(asset);
    setIssueType('');
    setDescription('');
    setFormError('');
    setShowServiceModal(true);
  };

const handleSubmitServiceRequest = async () => {
  if (!issueType || !description.trim()) {
    setFormError('Please select issue type and provide a description.');
    return;
  }

  try {
    await createServiceRequest(selectedAsset.assignmentId, issueType, description);
    setSuccessMsg('Service request submitted successfully.');
    setError('');
    loadAssets();
  } catch (err) {
    const backendError = err.response?.data || 'Failed to submit service request.';
    setError(backendError); 
    setSuccessMsg('');
  } finally {
    setShowServiceModal(false);
    setSelectedAsset(null);
  }
};

const isServiceFormValid = issueType && description.trim();

return (
  <div className="container py-4">
    <h3>My Assigned Assets</h3>
    {error && <div className="alert alert-danger">{error}</div>}
    {successMsg && <div className="alert alert-success">{successMsg}</div>}

    {assets.length > 0 ? (
      <div className="row">
        {assets.map(asset => (
          <div className="col-md-4 mb-3" key={asset.assignmentId}>
            <div className="card shadow-sm">
              <div className="card-body">
                <h5 className="card-title">{asset.assetName}</h5>
                <p>Model: {asset.assetModel}</p>
                <p>Quantity: {asset.quantity}</p>
                <p>Status: <strong>{asset.status}</strong></p>

                {asset.status === 'Rejected' && (
                  <div className="text-danger fw-semibold">
                    This asset request was rejected by admin.
                  </div>
                )}

                {asset.status === 'Returned' && (
                  <div className="text-success fw-semibold">
                    This asset was successfully returned.
                  </div>
                )}

                {asset.status === 'Assigned' && (
                  <div className="d-flex justify-content-end gap-2">
                    <Button
                      variant="warning"
                      size="sm"
                      disabled={asset.status === 'ReturnRequested'}
                      onClick={() => handleShowReturnModal(asset)}
                    >
                      {asset.status === 'ReturnRequested' ? 'Return Requested' : 'Request Return'}
                    </Button>
                    <Button
                      variant="info"
                      size="sm"
                      onClick={() => handleShowServiceModal(asset)}
                    >
                      Raise Service Request
                    </Button>
                  </div>
                )}
              </div>
            </div>
          </div>
        ))}
      </div>
    ) : (
      <div className="mt-3">
        <div className="alert alert-warning">You don't have any assigned assets.</div>
      </div>
    )}

    {/* Return Confirmation Modal */}
    <Modal show={showReturnModal} onHide={() => setShowReturnModal(false)} centered>
      <Modal.Header closeButton>
        <Modal.Title>Confirm Return Request</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        Are you sure you want to return the asset{' '}
        <strong>{selectedAsset?.assetName}</strong>?
      </Modal.Body>
      <Modal.Footer className="d-flex justify-content-end">
        <Button variant="secondary" onClick={() => setShowReturnModal(false)}>
          Cancel
        </Button>
        <Button variant="warning" onClick={handleConfirmReturn}>
          Yes, Request Return
        </Button>
      </Modal.Footer>
    </Modal>

    {/* Service Request Modal */}
    <Modal show={showServiceModal} onHide={() => setShowServiceModal(false)} centered>
      <Modal.Header closeButton>
        <Modal.Title>Raise Service Request</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group controlId="issueType" className="mb-3">
            <Form.Label>Issue Type</Form.Label>
            <Form.Select
              value={issueType}
              onChange={(e) => setIssueType(e.target.value)}
            >
              <option value="">-- Select Issue Type --</option>
              <option value="Malfunction">Malfunction</option>
              <option value="Repair">Repair</option>
            </Form.Select>
          </Form.Group>

          <Form.Group controlId="description">
            <Form.Label>Description</Form.Label>
            <Form.Control
              as="textarea"
              rows={3}
              value={description}
              onChange={(e) => setDescription(e.target.value)}
            />
          </Form.Group>

          {formError && (
            <div className="text-danger mt-2">{formError}</div>
          )}
        </Form>
      </Modal.Body>
      <Modal.Footer className="d-flex justify-content-end">
        <Button variant="secondary" onClick={() => setShowServiceModal(false)}>
          Cancel
        </Button>
        <Button
          variant="primary"
          onClick={handleSubmitServiceRequest}
          disabled={!isServiceFormValid}
        >
          Raise Service Request
        </Button>
      </Modal.Footer>
    </Modal>
  </div>
);

};

export default MyAssetsPage;
