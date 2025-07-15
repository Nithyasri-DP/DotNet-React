import axiosInstance from '../services/axiosInstance';
import axios from 'axios'; 

// EMPLOYEES 

export const getAllEmployees = async () => {
  const response = await axiosInstance.get('/User/employees');
  return response.data;
};

export const getEmployeeById = async (id) => {
  const response = await axiosInstance.get(`/User/employee/${id}`);
  return response.data;
};

export const createEmployee = async (employeeData) => {
  const response = await axiosInstance.post('/User/create-employee', employeeData);
  return response.data;
};

export const updateEmployee = async (updateDto) => {
  const res = await axiosInstance.put('/User/update-employee', updateDto);
  return res.data;
};

export const deleteEmployee = async (id) => {
  const res = await axiosInstance.delete(`/User/employee/${id}`);
  return res.data;
};

// ASSETS 

export const getAllAssets = async () => {
  const response = await axiosInstance.get('/Asset');
  return response.data;
};

export const getAssetById = async (assetId) => {
  const response = await axiosInstance.get(`/Asset/${assetId}`);
  return response.data;
};

export const createAsset = async (assetData) => {
  const response = await axiosInstance.post('/Asset', assetData);
  return response.data;
};

export const updateAsset = async (assetId, assetData) => {
  const response = await axiosInstance.put(`/Asset/${assetId}`, assetData);
  return response.data;
};

export const deleteAsset = async (assetId) => {
  const response = await axiosInstance.delete(`/Asset/${assetId}`);
  return response.data;
};

// CATEGORIES 
export const getAllCategories = async () => {
  const response = await axiosInstance.get('/Category');
  return response.data;
};

export const getCategoryById = async (categoryId) => {
  const response = await axiosInstance.get(`/Category/${categoryId}`);
  return response.data;
};

export const createCategory = async (categoryData) => {
  const response = await axiosInstance.post('/Category', categoryData);
  return response.data;
};

export const updateCategory = async (categoryId, categoryData) => {
  const response = await axiosInstance.put(`/Category/${categoryId}`, categoryData);
  return response.data;
};

export const deleteCategory = async (categoryId) => {
  const response = await axiosInstance.delete(`/Category/${categoryId}`);
  return response.data;
};

// SERVICE REQUESTS

export const getAllServiceRequests = async () => {
  const response = await axiosInstance.get('/ServiceRequest/all');
  return response.data;
};

export const updateServiceStatus = async (requestId, status) => {
  const response = await axiosInstance.put(`/ServiceRequest/status`, {
    serviceRequestId: requestId,
    status,
  });
  return response.data;
};

// AUDIT REQUESTS 

export const getAllAuditRequests = async () => {
  const response = await axiosInstance.get('/AuditRequest/all');
  return response.data;
};

// ASSET ASSIGNMENT & RETURN 

export const getPendingAssetRequests = async () => {
  const response = await axiosInstance.get('/AssetAssignment/PendingRequests');
  return response.data;
};

export const approveAssetRequest = async (assignmentId) => {
  const payload = {
    assignmentId,
    assignedDate: new Date().toISOString(),
  };
  const response = await axiosInstance.post('/AssetAssignment/assign', payload);
  return response.data;
};

export const rejectAssetRequest = async (assignmentId) => {
  const res = await axiosInstance.post(`/AssetAssignment/reject/${assignmentId}`);
  return res.data;
};

export const getReturnRequests = async () => {
  const response = await axiosInstance.get('/AssetAssignment/return-requests');
  return response.data;
};

export const approveReturnRequest = async (assignmentId) => {
  const response = await axiosInstance.post(`/AssetAssignment/approve-return/${assignmentId}`);
  return response.data;
};

export const rejectReturnRequest = async (assignmentId) => {
  const response = await axiosInstance.post(`/AssetAssignment/reject-return/${assignmentId}`);
  return response.data;
};
