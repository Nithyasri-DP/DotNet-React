import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { createCategory } from '../../services/adminService';
import { Button, Form, Container, Row, Col, Alert } from 'react-bootstrap';

const AddCategoryForm = () => {
  const [categoryName, setCategoryName] = useState('');
  const [error, setError] = useState('');
  const [success, setSuccess] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    setSuccess('');

    try {
      await createCategory({ categoryName });
      setSuccess('Category created successfully!');

      setTimeout(() => {
        navigate('/admin/categories');
      }, 1500);
    } catch (err) {
      setError(err.response?.data || 'Failed to create category');
    }
  };

  return (
    <Container className="mt-4">
      <Row className="mb-3">
        <Col><h3>Add New Category</h3></Col>
      </Row>

      {error && <Alert variant="danger">{error}</Alert>}
      {success && <Alert variant="success">{success}</Alert>}

      <Form onSubmit={handleSubmit}>
        <Form.Group className="mb-3" controlId="categoryName">
          <Form.Label>Category Name</Form.Label>
          <Form.Control
            type="text"
            value={categoryName}
            onChange={(e) => setCategoryName(e.target.value)}
            required
          />
        </Form.Group>

        <Button variant="primary" type="submit">
          Create
        </Button>{' '}
        <Button variant="secondary" onClick={() => navigate('/admin/categories')}>
          Back
        </Button>
      </Form>
    </Container>
  );
};

export default AddCategoryForm;
