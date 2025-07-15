import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { login } from '../services/authService';
import logo from '../assets/logoimage.avif';
import BackgroundWrapper from '../components/BackgroundWrapper';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    setError('');

    try {
      const result = await login({ email, password });

      sessionStorage.setItem('token', result.token);
      sessionStorage.setItem('role', result.role);
      sessionStorage.setItem('email', result.email);
      sessionStorage.setItem('fullName', result.fullName);

      if (result.role === 'Admin') {
        navigate('/admin/dashboard');
      } else {
        navigate('/employee/dashboard');
      }

    } catch (err) {
      console.error('Login failed:', err);
      setError(err.response?.data?.message || 'Invalid email or password');
    }
  };

  return (
    <BackgroundWrapper>
      <div className="text-center">
        <img src={logo} alt="Logo" style={{ width: '120px', height: 'auto' }} />
      </div>

      <h4 className="mb-2 text-center">Asset Portal Login</h4>
      {error && <div className="alert alert-danger">{error}</div>}

      <form onSubmit={handleLogin}>
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
          <label className="form-label">Password</label>
          <input
            type="password"
            className="form-control"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>

        <button type="submit" className="btn btn-primary w-100">
          Login
        </button>

        <div className="text-center mt-2">
          <a href="/forgot-password" className="text-decoration-none">Forgot Password?</a>
        </div>
      </form>
    </BackgroundWrapper>
  );
};

export default Login;
