import axiosInstance from './axiosInstance';

export const login = async ({ email, password }) => {
  const response = await axiosInstance.post('/Auth/login', {
    Email: email,
    Password: password,
  });
  return response.data;
};

export const forgotPassword = async (email) => {
  const response = await axiosInstance.post('/Auth/forgot-password', { email });
  return response.data;
};

export const resetPassword = async (data) => {
  const response = await axiosInstance.post('/Auth/reset-password', data);
  return response.data;
};
