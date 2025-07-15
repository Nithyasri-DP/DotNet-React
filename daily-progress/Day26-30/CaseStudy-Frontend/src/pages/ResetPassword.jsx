import React, { useState } from 'react';
import { resetPassword } from '../services/authService';
import { useNavigate } from 'react-router-dom';
import BackgroundWrapper from '../components/BackgroundWrapper';

const ResetPassword = () => {
  const [email, setEmail] = useState('');
  const [token, setToken] = useState('');
  const [newPassword, setNewPassword] = useState('');
  const [message, setMessage] = useState('');
  const [error, setError] = useState('');
  const [showLoginBtn, setShowLoginBtn] = useState(false);
  const navigate = useNavigate();

  const validatePassword = (pwd) => {
    const pattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?#&])[A-Za-z\d@$!%*?#&]{8,}$/;
    return pattern.test(pwd);
  };

  const handleReset = async (e) => {
    e.preventDefault();
    setError('');
    setMessage('');
    setShowLoginBtn(false);

    if (!validatePassword(newPassword)) {
      setError('Password must be at least 8 characters long and include uppercase, lowercase, number, and special character.');
      return;
    }

    try {
      const result = await resetPassword({
        email: email.trim(),
        token: token.trim(),
        newPassword,
      });

      setMessage(result.message || 'Password reset successfully.');
      setShowLoginBtn(true);
    } catch (err) {
      const backendMessage = err.response?.data?.error || '';
      if (
        backendMessage.toLowerCase().includes('not found') ||
        backendMessage.toLowerCase().includes('invalid') ||
        backendMessage.toLowerCase().includes('expired')
      ) {
        setError('Invalid email or token, try again.');
      } else {
        setError('Reset failed. Try again.');
      }
    }
  };

  return (
    <BackgroundWrapper>
      <h4 className="mb-3 text-center">Reset Password</h4>

      {message && <div className="alert alert-success">{message}</div>}
      {error && <div className="alert alert-danger">{error}</div>}

      {!showLoginBtn ? (
        <form onSubmit={handleReset}>
          <div className="mb-3">
            <label className="form-label">Email</label>
            <input
              type="email"
              className="form-control"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              required
            />
          </div>

          <div className="mb-3">
            <label className="form-label">Reset Token</label>
            <input
              type="text"
              className="form-control"
              value={token}
              onChange={(e) => setToken(e.target.value)}
              required
            />
          </div>

          <div className="mb-3">
            <label className="form-label">New Password</label>
            <input
              type="password"
              className="form-control"
              value={newPassword}
              onChange={(e) => setNewPassword(e.target.value)}
              required
            />
            <small className="text-muted">
              Must include uppercase, lowercase, number, and special character.
            </small>
          </div>

          <button type="submit" className="btn btn-primary w-100">Reset Password</button>
        </form>
      ) : (
        <button className="btn btn-success w-100" onClick={() => navigate('/login')}>
          Back to Login
        </button>
      )}
    </BackgroundWrapper>
  );
};

export default ResetPassword;
