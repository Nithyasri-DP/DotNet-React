import React, { useState } from 'react';
import { forgotPassword } from '../services/authService';
import { Link } from 'react-router-dom';
import BackgroundWrapper from '../components/BackgroundWrapper';

const ForgotPassword = () => {
  const [email, setEmail] = useState('');
  const [token, setToken] = useState('');
  const [message, setMessage] = useState('');
  const [error, setError] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    setMessage('');
    setToken('');

    try {
      const result = await forgotPassword(email);
      setToken(result.token);
      setMessage(result.message || 'Reset token received.');
    } catch (err) {
      setError(err.response?.data?.error || 'Something went wrong');
    }
  };

  return (
  <BackgroundWrapper>
    <h4 className="mb-3 text-center">Forgot Password</h4>

    {message && (
      <p className="text-success small text-center mb-3">
        {message}
      </p>
    )}

    {error && <div className="alert alert-danger">{error}</div>}

    <form onSubmit={handleSubmit}>
      <div className="mb-3">
        <label className="form-label">Registered Email</label>
        <input
          type="email"
          className="form-control"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />
      </div>

      <button type="submit" className="btn btn-primary w-100">Get Reset Token</button>
    </form>

    {token && (
      <div className="mt-4">
        <label className="form-label">Copy this Token</label>
        <div
          className="form-control mb-2"
          style={{
            backgroundColor: '#f8f9fa',
            fontSize: '0.9rem',
            wordBreak: 'break-word',
          }}
        >
          {token}
        </div>
        <Link to="/reset-password" className="btn btn-success w-100">
          Go to Reset Password
        </Link>
      </div>
    )}
  </BackgroundWrapper>
);

};

export default ForgotPassword;
