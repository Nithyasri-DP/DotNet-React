import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getAssetById } from '../../services/adminService';
import { Card, Button, Row, Col } from 'react-bootstrap';

const IndividualAsset = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [asset, setAsset] = useState(null);

  useEffect(() => {
    const fetchAsset = async () => {
      try {
        const data = await getAssetById(id);
        setAsset(data);
      } catch (error) {
        console.error('Failed to fetch asset details:', error);
      }
    };
    fetchAsset();
  }, [id]);

  if (!asset) return <p className="text-center mt-5">Loading asset details...</p>;

  return (
    <div className="container mt-5">
      <Card className="shadow-lg p-4">
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
            <h3 className="mb-3">{asset.assetName}</h3>
            <p><strong>ID:</strong> {asset.assetId}</p>
            <p><strong>Category:</strong> {asset.categoryName}</p>
            <p><strong>Model:</strong> {asset.assetModel}</p>
            <p><strong>Manufactured:</strong> {asset.manufacturingDate.split('T')[0]}</p>
            <p><strong>Expiry:</strong> {asset.expiryDate.split('T')[0]}</p>
            <p><strong>Quantity:</strong> {asset.quantity}</p>
            <p><strong>Value:</strong> Rs.{asset.assetValue}</p>
            <p><strong>Status:</strong> {asset.status}</p>

            <Button variant="secondary" className="mt-3" onClick={() => navigate('/admin/assets')}>
              Back to Assets
            </Button>
          </Col>
        </Row>
      </Card>
    </div>
  );
};

export default IndividualAsset;
