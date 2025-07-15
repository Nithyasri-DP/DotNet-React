import React, { useEffect, useState } from 'react';
import axiosInstance from '../../services/axiosInstance';
import { Table, Spinner, Alert, Badge, Form, Row, Col, Button } from 'react-bootstrap';

const AuditRequestsPage = () => {
  const [auditRequests, setAuditRequests] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  const [searchEmployee, setSearchEmployee] = useState('');
  const [searchAsset, setSearchAsset] = useState('');
  const [statusFilter, setStatusFilter] = useState('All');

  const [currentPage, setCurrentPage] = useState(1);
  const itemsPerPage = 8;

  useEffect(() => {
    const fetchAuditRequests = async () => {
      try {
        const response = await axiosInstance.get('/AuditRequest/all');
        setAuditRequests(response.data);
      } catch (err) {
        setError('Failed to load audit requests');
      } finally {
        setLoading(false);
      }
    };

    fetchAuditRequests();
  }, []);

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

  const filteredAudits = auditRequests.filter((item) => {
    const matchEmployee = item.user?.fullName?.toLowerCase().includes(searchEmployee.toLowerCase());
    const matchAsset = item.asset?.assetName?.toLowerCase().includes(searchAsset.toLowerCase());
    const matchStatus =
      statusFilter === 'All' || item.status?.toLowerCase() === statusFilter.toLowerCase();

    return matchEmployee && matchAsset && matchStatus;
  });

  const indexOfLast = currentPage * itemsPerPage;
  const indexOfFirst = indexOfLast - itemsPerPage;
  const currentItems = filteredAudits.slice(indexOfFirst, indexOfLast);
  const totalPages = Math.ceil(filteredAudits.length / itemsPerPage);

  const handlePrevious = () => {
    if (currentPage > 1) setCurrentPage((prev) => prev - 1);
  };

  const handleNext = () => {
    if (currentPage < totalPages) setCurrentPage((prev) => prev + 1);
  };

  if (loading) return <Spinner animation="border" className="mt-4" />;
  if (error) return <Alert variant="danger" className="mt-4">{error}</Alert>;

  return (
    <div className="container mt-4">
      <h4 className="mb-4">Audit Request History</h4>

      <Row className="mb-3">
        <Col md={4}>
          <Form.Control
            type="text"
            placeholder="Search by Employee Name"
            value={searchEmployee}
            onChange={(e) => {
              setSearchEmployee(e.target.value);
              setCurrentPage(1);
            }}
          />
        </Col>
        <Col md={4}>
          <Form.Control
            type="text"
            placeholder="Search by Asset Name"
            value={searchAsset}
            onChange={(e) => {
              setSearchAsset(e.target.value);
              setCurrentPage(1);
            }}
          />
        </Col>
        <Col md={4}>
          <Form.Select
            value={statusFilter}
            onChange={(e) => {
              setStatusFilter(e.target.value);
              setCurrentPage(1);
            }}
          >
            <option value="All">All Statuses</option>
            <option value="Pending">Pending</option>
            <option value="Verified">Verified</option>
            <option value="Rejected">Rejected</option>
          </Form.Select>
        </Col>
      </Row>

      {filteredAudits.length === 0 ? (
        <Alert variant="info">No audit requests found.</Alert>
      ) : (
        <>
          <Table striped bordered hover responsive>
            <thead className="table-dark">
              <tr>
                <th>Employee</th>
                <th>Asset</th>
                <th>Model</th>
                <th>Category</th>
                <th>Requested Date</th>
                <th>Responded Date</th>
                <th>Status</th>
                <th>Remarks</th>
              </tr>
            </thead>
            <tbody>
              {currentItems.map((item) => (
                <tr key={item.auditId}>
                  <td>{item.user?.fullName || '—'}</td>
                  <td>{item.asset?.assetName || '—'}</td>
                  <td>{item.asset?.assetModel || '—'}</td>
                  <td>{item.asset?.assetCategory?.categoryName || '—'}</td>
                  <td>{item.auditRequestDate?.split('T')[0]}</td>
                  <td>{item.auditResponseDate ? item.auditResponseDate.split('T')[0] : '—'}</td>
                  <td>
                    <Badge bg={getStatusVariant(item.status)}>{item.status}</Badge>
                  </td>
                  <td>{item.remarks || '—'}</td>
                </tr>
              ))}
            </tbody>
          </Table>

          {/* Pagination Controls */}
          {totalPages > 1 && (
            <div className="d-flex justify-content-center align-items-center mt-3 gap-2">
              <Button
                variant="secondary"
                size="sm"
                disabled={currentPage === 1}
                onClick={handlePrevious}
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
                onClick={handleNext}
              >
                Next »
              </Button>
            </div>
          )}
        </>
      )}
    </div>
  );
};

export default AuditRequestsPage;
