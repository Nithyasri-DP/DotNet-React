import React from 'react';
import { Link } from 'react-router-dom';

const NotFound = () => {
  return (
    <div className="d-flex flex-column align-items-center justify-content-center vh-100 bg-light">
      <h1 className="display-1 fw-bold text-danger">404</h1>
      <p className="fs-3">Oops! Page not found.</p>
      <p className="lead">The page you're looking for doesn't exist.</p>
      <Link to="/" className="btn btn-primary mt-3">
        Go Home
      </Link>
    </div>
  );
};

export default NotFound;
