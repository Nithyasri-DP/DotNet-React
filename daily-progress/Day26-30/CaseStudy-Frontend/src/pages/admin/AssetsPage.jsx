import React, { useEffect, useState } from 'react';
import { getAllAssets, deleteAsset, updateAsset, getAllCategories } from '../../services/adminService';
import { useNavigate } from 'react-router-dom';
import { Modal, Button, Form } from 'react-bootstrap';

const AssetsPage = () => {
  const navigate = useNavigate();
  const [assets, setAssets] = useState([]);
  const [filteredAssets, setFilteredAssets] = useState([]);
  const [categories, setCategories] = useState([]);
  const [searchName, setSearchName] = useState('');
  const [searchCategory, setSearchCategory] = useState('');
  const [showEditModal, setShowEditModal] = useState(false);
  const [selectedAsset, setSelectedAsset] = useState(null);
  const [editFormData, setEditFormData] = useState({});
  const [originalData, setOriginalData] = useState({});
  const [formChanged, setFormChanged] = useState(false);
  const [nameError, setNameError] = useState('');
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [assetToDelete, setAssetToDelete] = useState(null);
  const [error, setError] = useState('');
  const [assetsPerPage, setAssetsPerPage] = useState(6);
  const [currentPage, setCurrentPage] = useState(1);
  const [editErrors, setEditErrors] = useState({}); 

  useEffect(() => {
    fetchAssets();
    fetchCategories();
  }, []);

  const fetchAssets = async () => {
    try {
      const data = await getAllAssets();
      setAssets(data);
      setFilteredAssets(data);
    } catch {
      setError('Failed to load assets');
    }
  };

  const fetchCategories = async () => {
    try {
      const data = await getAllCategories();
      setCategories(data);
    } catch {
      setCategories([]);
    }
  };

  const handleEditClick = (asset) => {
    const matchedCategory = categories.find(c => c.categoryName === asset.categoryName);
    const formData = {
      assetName: asset.assetName,
      assetModel: asset.assetModel,
      assetValue: asset.assetValue,
      quantity: asset.quantity,
      manufacturingDate: asset.manufacturingDate?.substring(0, 10),
      expiryDate: asset.expiryDate?.substring(0, 10),
      categoryId: matchedCategory?.categoryId ?? null,
      imageUrl: asset.imageUrl
    };

    setSelectedAsset(asset);
    setEditFormData(formData);
    setOriginalData(formData);
    setFormChanged(false);
    setNameError('');
    setEditErrors({});
    setShowEditModal(true);
  };

  const handleEditChange = (e) => {
    const { name, value } = e.target;
       if (name === 'assetValue') {
        const regex = /^\d*\.?\d{0,2}$/;
        if (!regex.test(value)) return; 
      }

    const updatedForm = { ...editFormData, [name]: value };
    setEditFormData(updatedForm);
    setFormChanged(JSON.stringify(updatedForm) !== JSON.stringify(originalData));

    if (name === 'assetName') {
      const isDuplicate = assets.some(a => a.assetName === value && a.assetId !== selectedAsset.assetId);
      setNameError(isDuplicate ? 'Asset name already exists' : '');
    }

    if (name === 'assetValue') {
      const valueStr = value.trim();
      const valueNum = parseFloat(valueStr);
      const isValidFormat = /^\d+(\.\d{1,2})?$/.test(valueStr);

      if (!valueStr) {
        newErrors.assetValue = 'Asset value is required';
      } else if (!isValidFormat) {
        newErrors.assetValue = 'Only up to 2 decimal places are allowed';
      } else if (valueNum <= 0) {
        newErrors.assetValue = 'Value must be greater than 0';
      } else {
        delete newErrors.assetValue;
      }
    }

    const today = new Date();
    const mfg = new Date(name === 'manufacturingDate' ? value : updatedForm.manufacturingDate);
    const exp = new Date(name === 'expiryDate' ? value : updatedForm.expiryDate);
    const newErrors = { ...editErrors };

    if (name === 'manufacturingDate') {
      if (!value) newErrors.manufacturingDate = 'Manufacturing date is required';
      else if (mfg > today || mfg.getFullYear() < 2000)
        newErrors.manufacturingDate = 'Manufacturing date must be between 2000 and today';
      else delete newErrors.manufacturingDate;
    }

    if (name === 'expiryDate') {
      if (!value) newErrors.expiryDate = 'Expiry date is required';
      else if (exp <= today)
        newErrors.expiryDate = 'Expiry date must be in the future';
      else delete newErrors.expiryDate;
    }

    setEditErrors(newErrors);
  };

  const handleEditSubmit = async (e) => {
    e.preventDefault();
    if (nameError) return;

    const today = new Date();
    const mfg = new Date(editFormData.manufacturingDate);
    const exp = new Date(editFormData.expiryDate);
    const finalErrors = {};

    if (!editFormData.manufacturingDate || mfg > today || mfg.getFullYear() < 2000) {
      finalErrors.manufacturingDate = 'Manufacturing date must be between 2000 and today';
    }
    if (!editFormData.expiryDate || exp <= today) {
      finalErrors.expiryDate = 'Expiry date must be in the future';
    }

    setEditErrors(finalErrors);
    if (Object.keys(finalErrors).length > 0) return;

    try {
      await updateAsset(selectedAsset.assetId, editFormData);
      setShowEditModal(false);
      fetchAssets();
    } catch {
      alert('Failed to update asset.');
    }
  };

  const handleDeleteClick = (asset) => {
    setAssetToDelete(asset);
    setShowDeleteModal(true);
  };

  const confirmDelete = async () => {
    try {
      await deleteAsset(assetToDelete.assetId);
      setShowDeleteModal(false);
      fetchAssets();
    } catch {
      alert('Failed to delete asset');
    }
  };

  const handleSearch = () => {
    const filtered = assets.filter(asset =>
      asset.assetName?.toLowerCase().includes(searchName.toLowerCase()) &&
      asset.categoryName?.toLowerCase().includes(searchCategory.toLowerCase())
    );
    setFilteredAssets(filtered);
    setCurrentPage(1);
  };

  useEffect(() => {
    handleSearch();
  }, [searchName, searchCategory, assets]);

  const indexOfLast = currentPage * assetsPerPage;
  const indexOfFirst = indexOfLast - assetsPerPage;
  const currentAssets = filteredAssets.slice(indexOfFirst, indexOfLast);
  const totalPages = Math.ceil(filteredAssets.length / assetsPerPage);

  return (
    <div className="container py-4">
      <div className="d-flex justify-content-between align-items-center mb-3">
        <h2>Manage Assets</h2>
        <button className="btn btn-success" onClick={() => navigate('/admin/add-asset')}>+ Add Asset</button>
      </div>

      <div className="row mb-3">
        <div className="col-md-4 mb-2">
          <input className="form-control" placeholder="Search by asset name" value={searchName} onChange={e => setSearchName(e.target.value)} />
        </div>
        <div className="col-md-4 mb-2">
          <Form.Select value={searchCategory} onChange={(e) => setSearchCategory(e.target.value)}>
            <option value="">All Categories</option>
            {categories.map((category) => (
              <option key={category.categoryId} value={category.categoryName}>
                {category.categoryName}
              </option>
            ))}
          </Form.Select>
        </div>
        <div className="col-md-4 mb-2">
          <Form.Select value={assetsPerPage} onChange={(e) => { setAssetsPerPage(Number(e.target.value)); setCurrentPage(1); }}>
            <option value={3}>Show 3</option>
            <option value={6}>Show 6</option>
            <option value={12}>Show 12</option>
          </Form.Select>
        </div>
      </div>

      {error && <div className="alert alert-danger">{error}</div>}

      <div className="row">
        {currentAssets.map(asset => (
          <div className="col-md-4 mb-4" key={asset.assetId}>
            <div className="card shadow-sm h-100">
              {asset.imageUrl && (
                <img src={asset.imageUrl} alt={asset.assetName} className="card-img-top" style={{ height: '270px', objectFit: 'cover' }} />
              )}
              <div className="card-body d-flex flex-column justify-content-between">
                <div>
                  <h5>{asset.assetName}</h5>
                  <p><strong>Category:</strong> {asset.categoryName}</p>
                  <p><strong>Model:</strong> {asset.assetModel}</p>
                  <p><strong>Qty:</strong> {asset.quantity} | <strong>Value:</strong> Rs.{asset.assetValue}</p>
                </div>
                <div className="d-flex justify-content-end gap-2 mt-2">
                  <button className="btn btn-info btn-sm" onClick={() => navigate(`/admin/assets/view/${asset.assetId}`)}>View</button>
                  <button className="btn btn-warning btn-sm" onClick={() => handleEditClick(asset)}>Edit</button>
                  <button className="btn btn-danger btn-sm" onClick={() => handleDeleteClick(asset)}>Delete</button>
                </div>
              </div>
            </div>
          </div>
        ))}
      </div>

      {totalPages > 1 && (
        <div className="d-flex justify-content-center align-items-center mt-3 gap-2">
          <Button variant="secondary" size="sm" disabled={currentPage === 1} onClick={() => setCurrentPage(prev => prev - 1)}>« Prev</Button>
          {[...Array(totalPages)].map((_, i) => (
            <Button key={i} size="sm" variant={i + 1 === currentPage ? 'primary' : 'outline-primary'} onClick={() => setCurrentPage(i + 1)}>
              {i + 1}
            </Button>
          ))}
          <Button variant="secondary" size="sm" disabled={currentPage === totalPages} onClick={() => setCurrentPage(prev => prev + 1)}>Next »</Button>
        </div>
      )}

       <Modal show={showEditModal} onHide={() => setShowEditModal(false)} centered>
        <Modal.Header closeButton>
          <Modal.Title>Edit Asset</Modal.Title>
        </Modal.Header>
        <Form onSubmit={handleEditSubmit}>
          <Modal.Body>
            <Form.Group className="mb-2">
              <Form.Label>Asset Name</Form.Label>
              <Form.Control name="assetName" value={editFormData.assetName} onChange={handleEditChange} required />
              {nameError && <small className="text-danger">{nameError}</small>}
            </Form.Group>
            <Form.Group className="mb-2">
              <Form.Label>Model</Form.Label>
              <Form.Control name="assetModel" value={editFormData.assetModel} onChange={handleEditChange} required />
            </Form.Group>
            <Form.Group className="mb-2">
              <Form.Label>Value</Form.Label>              
              <Form.Control type="number" step="0.01" name="assetValue" value={editFormData.assetValue} onChange={handleEditChange} required />
            </Form.Group>
            <Form.Group className="mb-2">
              <Form.Label>Quantity</Form.Label>
              <Form.Control type="number" name="quantity" value={editFormData.quantity} onChange={handleEditChange} required />
            </Form.Group>
            <Form.Group className="mb-2">
              <Form.Label>Manufacturing Date</Form.Label>
              <Form.Control
                type="date"
                name="manufacturingDate"
                value={editFormData.manufacturingDate}
                onChange={handleEditChange}
                isInvalid={!!editErrors.manufacturingDate}
              />
              <Form.Control.Feedback type="invalid">{editErrors.manufacturingDate}</Form.Control.Feedback>
            </Form.Group>
            <Form.Group className="mb-2">
              <Form.Label>Expiry Date</Form.Label>
              <Form.Control
                type="date"
                name="expiryDate"
                value={editFormData.expiryDate}
                onChange={handleEditChange}
                isInvalid={!!editErrors.expiryDate}
              />
              <Form.Control.Feedback type="invalid">{editErrors.expiryDate}</Form.Control.Feedback>
            </Form.Group>
            <Form.Group className="mb-2">
              <Form.Label>Category</Form.Label>
              <Form.Select name="categoryId" value={editFormData.categoryId} onChange={handleEditChange} required>
                <option value="">Select Category</option>
                {categories.map(c => (
                  <option key={c.categoryId} value={c.categoryId}>{c.categoryName}</option>
                ))}
              </Form.Select>
            </Form.Group>
            <Form.Group className="mb-2">
              <Form.Label>Image URL</Form.Label>
              <Form.Control name="imageUrl" value={editFormData.imageUrl} onChange={handleEditChange} />
            </Form.Group>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={() => setShowEditModal(false)}>Cancel</Button>
            <Button type="submit" variant="primary" disabled={!formChanged || nameError}>Save Changes</Button>
          </Modal.Footer>
        </Form>
      </Modal>

      <Modal show={showDeleteModal} onHide={() => setShowDeleteModal(false)} centered>
        <Modal.Header closeButton>
          <Modal.Title>Confirm Delete</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Are you sure you want to delete asset: <strong>{assetToDelete?.assetName}</strong>?
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setShowDeleteModal(false)}>Cancel</Button>
          <Button variant="danger" onClick={confirmDelete}>Delete</Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default AssetsPage;
