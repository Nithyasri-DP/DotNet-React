import axiosInstance from './axiosInstance';

// PROFILE 

export const getMyProfile = async () => {
  const response = await axiosInstance.get('/User/my-profile');
  return response.data;
};

// ASSETS 

export const getAvailableAssets = async () => {
  const response = await axiosInstance.get('/Asset/OnlyAvailableAssets');
  return response.data;
};

export const getAssetById = async (id) => {
  const response = await axiosInstance.get(`/Asset/${id}`);
  return response.data;
};

export const requestAsset = async (assetId, quantity = 1) => {
  const response = await axiosInstance.post('/AssetAssignment/request', {
    assetId,
    quantity,
  });
  return response.data;
};

export const requestReturnAsset = async (assignmentId) => {
  try {
    const response = await axiosInstance.post(`/AssetAssignment/request-return/${assignmentId}`);
    return response.data;
  } catch (error) {
    const message = error.response?.data?.message || 'Failed to request return.';
    throw new Error(message);
  }
};

export const getMyAssets = async () => {
  const response = await axiosInstance.get('/AssetAssignment/my-assets');
  return response.data;
};

// SERVICE REQUESTS 

export const getMyServiceRequests = async () => {
  const response = await axiosInstance.get('/ServiceRequest/my');
  return response.data;
};

export const createServiceRequest = async (assignmentId, issueType, description) => {
  const payload = {
    assignmentId,
    issueType,
    description,
  };
  const res = await axiosInstance.post('/ServiceRequest', payload);
  return res.data;
};

// AUDIT REQUESTS

export const getMyAuditRequests = async () => {
  const response = await axiosInstance.get('/AuditRequest/my');
  return response.data;
};

export const respondToAuditRequest = async (auditId, status, remarks) => {
  const payload = {
    auditId,
    status,
    remarks,
  };
  const response = await axiosInstance.put('/AuditRequest/respond', payload);
  return response.data;
};
