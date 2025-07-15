import React, { useEffect, useState } from 'react';
import { getMyServiceRequests } from '../../services/employeeService';
import { Card, Alert, Badge } from 'react-bootstrap';

const MyServiceRequests = () => {
  const [requests, setRequests] = useState([]);
  const [error, setError] = useState('');

  useEffect(() => {
    loadServiceRequests();
  }, []);

  const loadServiceRequests = async () => {
    try {
      const data = await getMyServiceRequests();
      setRequests(data);
    } catch (err) {
      setError('Failed to load service requests.');
    }
  };

  const getStatusVariant = (status) => {
    switch (status.toLowerCase()) {
      case 'pending':
        return 'warning';
      case 'inprogress':
        return 'info';
      case 'completed':
        return 'success';
      case 'rejected':
        return 'danger';
      default:
        return 'secondary';
    }
  };

  return (
    <div className="container py-4">
      <h3 className="mb-4">My Service Requests</h3>

      {error && <Alert variant="danger">{error}</Alert>}

      {requests.length === 0 ? (
        <Alert variant="warning">You have not raised any service requests yet.</Alert>
      ) : (
        <div className="row">
          {requests.map((req) => (
            <div className="col-md-6 mb-4" key={req.requestId}>
              <Card className="shadow-sm">
                <Card.Body>
                  <Card.Title>{req.asset.assetName}</Card.Title>
                  <Card.Subtitle className="mb-2 text-muted">
                    Issue Type: {req.issueType.charAt(0).toUpperCase() + req.issueType.slice(1)}
                  </Card.Subtitle>
                  <Card.Text>
                    <strong>Description:</strong> {req.description}
                  </Card.Text>
                  <Card.Text>
                    <strong>Requested On:</strong> {new Date(req.requestDate).toLocaleDateString()}
                  </Card.Text>
                  <Badge bg={getStatusVariant(req.status)}>
                    {req.status.charAt(0).toUpperCase() + req.status.slice(1)}
                  </Badge>
                </Card.Body>
              </Card>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default MyServiceRequests;

