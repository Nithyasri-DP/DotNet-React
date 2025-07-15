import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { getAvailableAssets, requestAsset } from '../../services/employeeService';
import { Modal, Button, Form, Row, Col } from 'react-bootstrap';

const AvailableAssets = () => {
  const [assets, setAssets] = useState([]);
  const [error, setError] = useState('');
  const [requestingId, setRequestingId] = useState(null);
  const [successMessage, setSuccessMessage] = useState('');
  const [searchTerm, setSearchTerm] = useState('');
  const [selectedCategory, setSelectedCategory] = useState('All');
  const [categories, setCategories] = useState([]);
  const [selectedAsset, setSelectedAsset] = useState(null);
  const [showModal, setShowModal] = useState(false);
  const [assetsPerPage, setAssetsPerPage] = useState(6);
  const [currentPage, setCurrentPage] = useState(1);

  const navigate = useNavigate();

  useEffect(() => {
    const fetchAssets = async () => {
      try {
        const data = await getAvailableAssets();
        setAssets(data);
        const uniqueCategories = [...new Set(data.map(a => a.categoryName))];
        setCategories(uniqueCategories);
        setError('');
      } catch (err) {
        setError('Failed to load available assets');
      }
    };

    fetchAssets();
  }, []);

  const handleRequest = async (assetId) => {
    setRequestingId(assetId);
    setError('');
    setSuccessMessage('');

    try {
      const response = await requestAsset(assetId, 1);
      setSuccessMessage(response.message || 'Asset request submitted successfully.');
    } catch (err) {
      const errorMessage = err.response?.data?.error || 'Failed to request asset';
      setError(errorMessage);
    } finally {
      setRequestingId(null);
    }
  };

  const handleShowModal = (asset) => {
    setSelectedAsset(asset);
    setShowModal(true);
  };

  const handleCloseModal = () => {
    setSelectedAsset(null);
    setShowModal(false);
  };

  const handleConfirmRequest = () => {
    if (selectedAsset) {
      handleRequest(selectedAsset.assetId);
      handleCloseModal();
    }
  };

  const filteredAssets = assets.filter(asset => {
    const matchesName = asset.assetName.toLowerCase().includes(searchTerm.toLowerCase());
    const matchesCategory = selectedCategory === 'All' || asset.categoryName === selectedCategory;
    return matchesName && matchesCategory;
  });

  const indexOfLast = currentPage * assetsPerPage;
  const indexOfFirst = indexOfLast - assetsPerPage;
  const currentAssets = filteredAssets.slice(indexOfFirst, indexOfLast);
  const totalPages = Math.ceil(filteredAssets.length / assetsPerPage);

  return (
    <div className="container py-4">
      <h2 className="mb-4">Available Assets</h2>

      {error && <div className="alert alert-danger">{error}</div>}
      {successMessage && <div className="alert alert-success">{successMessage}</div>}

      <Row className="mb-3">
        <Col md={4} className="mb-2">
          <Form.Control
            type="text"
            placeholder="Search by Asset Name"
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
        </Col>
        <Col md={4} className="mb-2">
          <Form.Select
            value={selectedCategory}
            onChange={(e) => setSelectedCategory(e.target.value)}
          >
            <option value="All">All Categories</option>
            {categories.map((cat, idx) => (
              <option key={idx} value={cat}>{cat}</option>
            ))}
          </Form.Select>
        </Col>
        <Col md={4} className="mb-2">
          <Form.Select
            value={assetsPerPage}
            onChange={(e) => {
              setAssetsPerPage(Number(e.target.value));
              setCurrentPage(1);
            }}
          >
            <option value={3}>Show 3</option>
            <option value={6}>Show 6</option>
            <option value={12}>Show 12</option>
          </Form.Select>
        </Col>
      </Row>

      <div className="row">
        {currentAssets.length > 0 ? (
          currentAssets.map((asset, index) => (
            <div className="col-md-4 mb-4" key={index}>
              <div className="card shadow-sm h-100 d-flex flex-column">
                {asset.imageUrl && (
                  <img
                    src={asset.imageUrl}
                    alt={asset.assetName}
                    className="card-img-top"
                    style={{ height: '280px', objectFit: 'cover' }}
                  />
                )}

                <div className="card-body d-flex flex-column justify-content-between flex-grow-1">
                  <div>
                    <h5 className="card-title">{asset.assetName}</h5>
                    <p className="card-text">
                      <strong>Category:</strong> {asset.categoryName} <br />
                      <strong>Model:</strong> {asset.assetModel} <br />
                      <strong>Quantity:</strong> {asset.quantity} <br />
                      <strong>Status:</strong> {asset.quantity > 0 ? 'Available' : 'Out of Stock'}
                    </p>
                  </div>

                  <div className="mt-auto d-flex justify-content-end gap-2">
                    <button
                      className="btn btn-warning btn-sm"
                      onClick={() => navigate(`/employee/view-asset/${asset.assetId}`)}
                    >
                      View
                    </button>

                    <button
                      className="btn btn-success btn-sm"
                      onClick={() => handleShowModal(asset)}
                      disabled={requestingId === asset.assetId || asset.quantity === 0}
                    >
                      {requestingId === asset.assetId ? 'Requesting...' : 'Request Asset'}
                    </button>
                  </div>
                </div>
              </div>
            </div>
          ))
        ) : (
          <p>No available assets found.</p>
        )}
      </div>

      {totalPages > 1 && (
        <div className="d-flex justify-content-center align-items-center mt-3 gap-2">
          <Button
            variant="secondary"
            size="sm"
            disabled={currentPage === 1}
            onClick={() => setCurrentPage(prev => prev - 1)}
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
            onClick={() => setCurrentPage(prev => prev + 1)}
          >
            Next »
          </Button>
        </div>
      )}

      <Modal show={showModal} onHide={handleCloseModal} centered>
        <Modal.Header closeButton>
          <Modal.Title>Confirm Asset Request</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Are you sure you want to request the asset{' '}
          <strong>{selectedAsset?.assetName}</strong>?
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleCloseModal}>
            Cancel
          </Button>
          <Button variant="success" onClick={handleConfirmRequest}>
            Yes, Request
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default AvailableAssets;
