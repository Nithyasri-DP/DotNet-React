import React, { useEffect, useState } from 'react';
import {getAllCategories, createCategory, updateCategory, deleteCategory, getCategoryById,} from '../../services/adminService';
import { Button, Container, Table, Modal, Form, Row, Col, Alert } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

const CategoriesPage = () => {
  const navigate = useNavigate();
  const [categories, setCategories] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [editModal, setEditModal] = useState(false);
  const [deleteModal, setDeleteModal] = useState(false);
  const [selectedCategory, setSelectedCategory] = useState(null);
  const [editName, setEditName] = useState('');
  const [statusMessage, setStatusMessage] = useState('');
  const [statusType, setStatusType] = useState(''); // 'success' or 'danger'

  const fetchCategories = async () => {
    const data = await getAllCategories();
    setCategories(data);
  };

  useEffect(() => {
    fetchCategories();
  }, []);

  const filtered = categories.filter((c) =>
    c.categoryName.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const handleEdit = (category) => {
    setSelectedCategory(category);
    setEditName(category.categoryName);
    setEditModal(true);
  };

  const handleEditSubmit = async () => {
    try {
      await updateCategory(selectedCategory.categoryId, { categoryName: editName });
      setEditModal(false);
      setStatusMessage('Category updated successfully.');
      setStatusType('success');
      fetchCategories();
    } catch (err) {
      setStatusMessage(err.response?.data || 'Failed to update category');
      setStatusType('danger');
    }
  };

  const handleDelete = (category) => {
    setSelectedCategory(category);
    setDeleteModal(true);
  };

  const confirmDelete = async () => {
    try {
      await deleteCategory(selectedCategory.categoryId);
      setDeleteModal(false);
      setStatusMessage('Category deleted successfully.');
      setStatusType('success');
      fetchCategories();
    } catch (err) {
      setStatusMessage(err.response?.data || 'Failed to delete category');
      setStatusType('danger');
    }
  };

  return (
    <Container className="mt-4">
      <Row className="mb-3">
        <Col><h3>Categories</h3></Col>
        <Col className="text-end">
          <Button variant="success" onClick={() => navigate('/admin/categories/add')}>
            + Add Category
          </Button>
        </Col>
      </Row>

      {statusMessage && (
        <Alert variant={statusType} onClose={() => setStatusMessage('')} dismissible>
          {statusMessage}
        </Alert>
      )}

      <Form.Control
        type="text"
        placeholder="Search by category name"
        className="mb-3"
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
      />

      <Table striped bordered hover responsive>
        <thead className="table-dark">
          <tr>
            <th>S.No</th>
            <th>Category ID</th>
            <th>Category Name</th>
            <th style={{ width: '180px' }}>Actions</th>
          </tr>
        </thead>
        <tbody>
          {filtered.map((category, index) => (
            <tr key={category.categoryId}>
              <td>{index + 1}</td>
              <td>{category.categoryId}</td>
              <td>{category.categoryName}</td>
              <td>
                <Button
                  size="sm"
                  variant="warning"
                  className="me-2"
                  onClick={() => handleEdit(category)}
                >
                  Edit
                </Button>
                <Button
                  size="sm"
                  variant="danger"
                  onClick={() => handleDelete(category)}
                >
                  Delete
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>

      {/* Edit Modal */}
      <Modal show={editModal} onHide={() => setEditModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>Edit Category</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form.Group controlId="editCategoryName">
            <Form.Label>Category Name</Form.Label>
            <Form.Control
              type="text"
              value={editName}
              onChange={(e) => setEditName(e.target.value)}
              required
            />
          </Form.Group>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setEditModal(false)}>
            Cancel
          </Button>
          <Button
            variant="primary"
            onClick={handleEditSubmit}
            disabled={editName.trim() === selectedCategory?.categoryName.trim()}
          >
            Save Changes
          </Button>
        </Modal.Footer>
      </Modal>

      {/* Delete Modal */}
      <Modal show={deleteModal} onHide={() => setDeleteModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>Delete Category</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Are you sure you want to delete "<strong>{selectedCategory?.categoryName}</strong>"?
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setDeleteModal(false)}>
            Cancel
          </Button>
          <Button variant="danger" onClick={confirmDelete}>
            Delete
          </Button>
        </Modal.Footer>
      </Modal>
    </Container>
  );
};

export default CategoriesPage;
