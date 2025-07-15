import React, { useState, useEffect } from 'react';
import { Form, Button, Alert } from 'react-bootstrap';
import { createAsset, getAllAssets, getAllCategories } from '../../services/adminService';
import { useNavigate } from 'react-router-dom';

const AddAssetForm = () => {
  const navigate = useNavigate();

  const [formData, setFormData] = useState({
    assetName: '',
    assetModel: '',
    assetValue: '',
    quantity: '',
    manufacturingDate: '',
    expiryDate: '',
    categoryId: '',
    imageUrl: ''
  });

  const [categories, setCategories] = useState([]);
  const [allAssetNames, setAllAssetNames] = useState([]);
  const [errors, setErrors] = useState({});
  const [successMessage, setSuccessMessage] = useState('');
  const [errorMessage, setErrorMessage] = useState('');

  useEffect(() => {
    const fetchData = async () => {
      try {
        const categories = await getAllCategories();
        const assets = await getAllAssets();
        setCategories(categories);
        setAllAssetNames(assets.map(a => a.assetName.toLowerCase()));
      } catch {
        setErrorMessage('Failed to load data');
      }
    };
    fetchData();
  }, []);

  const validateField = (name, value) => {
    const today = new Date();
    const mfg = new Date(formData.manufacturingDate);
    const exp = new Date(formData.expiryDate);
    let error = '';

    switch (name) {
      case 'assetName':
        if (!value.trim()) error = 'Asset name is required';
        break;
      case 'assetModel':
        if (!value.trim()) error = 'Asset model is required';
        break;
      case 'assetValue':
        if (!value) error = 'Asset value is required';
        else if (!/^\d+(\.\d{1,2})?$/.test(value)) error = 'Only numeric values with up to 2 decimal places are allowed';
        else if (parseFloat(value) <= 0) error = 'Value must be greater than 0';
        break;
      case 'quantity':
        if (!value.trim()) error = 'Quantity is required';
        else if (!/^\d+$/.test(value)) error = 'Only numbers are allowed';
        else if (parseInt(value) <= 0) error = 'Quantity must be at least 1';
        break;
      case 'manufacturingDate':
        if (!value) error = 'Manufacturing date is required';
        else if (new Date(value) > today || new Date(value).getFullYear() < 2000)
          error = 'Manufacturing date must be between 2000 and today';
        break;
      case 'expiryDate':
        if (!value) error = 'Expiry date is required';
        else if (new Date(value) <= today) error = 'Expiry date must be in the future';
        break;
      case 'categoryId':
        if (!value) error = 'Category is required';
        break;
      case 'imageUrl':
        if (!value.trim()) error = 'Image URL is required';
        break;
      default:
        break;
    }

    setErrors(prev => ({ ...prev, [name]: error }));
  };

  const handleBlur = (e) => {
    const { name, value } = e.target;
    if (name === 'assetName' && value.trim()) {
      const isDuplicate = allAssetNames.includes(value.trim().toLowerCase());
      setErrors(prev => ({
        ...prev,
        assetName: isDuplicate ? 'Asset with this name already exists' : ''
      }));
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
    validateField(name, value);
  };

  const validateForm = () => {
    const fields = Object.keys(formData);
    fields.forEach(field => validateField(field, formData[field]));

    const hasError = Object.values(errors).some(err => err);
    return !hasError && fields.every(field => formData[field] !== '');
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setSuccessMessage('');
    setErrorMessage('');

    if (!validateForm()) return;

    const assetData = {
      ...formData,
      categoryId: parseInt(formData.categoryId),
      assetValue: parseFloat(formData.assetValue),
      quantity: parseInt(formData.quantity)
    };

    try {
      await createAsset(assetData);
      setSuccessMessage('Asset created successfully');
      setFormData({
        assetName: '',
        assetModel: '',
        assetValue: '',
        quantity: '',
        manufacturingDate: '',
        expiryDate: '',
        categoryId: '',
        imageUrl: ''
      });
      setErrors({});
    } catch (err) {
      setErrorMessage(err?.response?.data?.error || 'Failed to create asset');
    }
  };

  return (
    <div className="container py-4">
      <h3 className="mb-4">Add New Asset</h3>

      {successMessage && <Alert variant="success">{successMessage}</Alert>}
      {errorMessage && <Alert variant="danger">{errorMessage}</Alert>}

      <Form onSubmit={handleSubmit}>
        <Form.Group className="mb-3">
          <Form.Label>Asset Name</Form.Label>
          <Form.Control
            type="text"
            name="assetName"
            value={formData.assetName}
            onChange={handleChange}
            onBlur={handleBlur}
            isInvalid={!!errors.assetName}
          />
          <Form.Control.Feedback type="invalid">{errors.assetName}</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Asset Model</Form.Label>
          <Form.Control
            type="text"
            name="assetModel"
            value={formData.assetModel}
            onChange={handleChange}
            isInvalid={!!errors.assetModel}
          />
          <Form.Control.Feedback type="invalid">{errors.assetModel}</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Asset Value</Form.Label>
          <Form.Control
            type="number"
            name="assetValue"
            step="0.01"
            value={formData.assetValue}
            onChange={handleChange}
            isInvalid={!!errors.assetValue}
          />
          <Form.Control.Feedback type="invalid">{errors.assetValue}</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Quantity</Form.Label>
          <Form.Control
            type="number"
            name="quantity"
            value={formData.quantity}
            onChange={handleChange}
            isInvalid={!!errors.quantity}
          />
          <Form.Control.Feedback type="invalid">{errors.quantity}</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Manufacturing Date</Form.Label>
          <Form.Control
            type="date"
            name="manufacturingDate"
            value={formData.manufacturingDate}
            onChange={handleChange}
            isInvalid={!!errors.manufacturingDate}
          />
          <Form.Control.Feedback type="invalid">{errors.manufacturingDate}</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Expiry Date</Form.Label>
          <Form.Control
            type="date"
            name="expiryDate"
            value={formData.expiryDate}
            onChange={handleChange}
            isInvalid={!!errors.expiryDate}
          />
          <Form.Control.Feedback type="invalid">{errors.expiryDate}</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Category</Form.Label>
          <Form.Select
            name="categoryId"
            value={formData.categoryId}
            onChange={handleChange}
            isInvalid={!!errors.categoryId}
          >
            <option value="">Select Category</option>
            {categories.map(cat => (
              <option key={cat.categoryId} value={cat.categoryId}>
                {cat.categoryName}
              </option>
            ))}
          </Form.Select>
          <Form.Control.Feedback type="invalid">{errors.categoryId}</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Image URL</Form.Label>
          <Form.Control
            type="text"
            name="imageUrl"
            value={formData.imageUrl}
            onChange={handleChange}
            isInvalid={!!errors.imageUrl}
          />
          <Form.Control.Feedback type="invalid">{errors.imageUrl}</Form.Control.Feedback>
        </Form.Group>

        <Button type="submit" variant="success">Create Asset</Button>
        <Button variant="secondary" className="ms-2" onClick={() => navigate('/admin/assets')}>
          Back
        </Button>
      </Form>
    </div>
  );
};

export default AddAssetForm;
