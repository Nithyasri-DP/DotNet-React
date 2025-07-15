import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import ProtectedRoute from './routes/ProtectedRoute';

// Public Pages
import Login from './auth/Login';
import ForgotPassword from './pages/ForgotPassword';
import ResetPassword from './pages/ResetPassword';

// Admin Layout + Pages
import AdminLayout from './components/AdminLayout';
import AdminDashboard from './pages/AdminDashboard';
import EmployeePage from './pages/admin/EmployeePage';
import AssetsPage from './pages/admin/AssetsPage';
import AddAssetForm from './pages/admin/AddAssetForm';
import CategoriesPage from './pages/admin/CategoriesPage';
import AuditRequestsPage from './pages/admin/AuditRequestsPage';
import PendingAssetRequests from './pages/admin/PendingAssetRequests';
import ReturnRequests from './pages/admin/ReturnRequests';
import AddEmployeeForm from './pages/admin/AddEmployeeForm';
import IndividualEmployee from './pages/admin/IndividualEmployee';
import IndividualAsset from './pages/admin/IndividualAsset';
import AddCategoryForm from './pages/admin/AddCategoryForm';
import AssignedAssetsPage from './pages/admin/AssignedAssetsPage';
import ServiceRequestsPage from './pages/admin/ServiceRequestsPage';

// Employee Layout + Pages
import EmployeeLayout from './components/EmployeeLayout';
import EmployeeDashboard from './pages/EmployeeDashboard';
import EmployeeProfile from './pages/employee/EmployeeProfile';
import MyAssets from './pages/employee/MyAssetsPage';
import AvailableAssets from './pages/employee/AvailableAssets';
import ViewAsset from './pages/employee/ViewAsset';
import MyServiceRequests from './pages/employee/MyServiceRequests';
import AuditResponsePage from './pages/employee/AuditResponsePage';

// Not Found
import NotFound from './pages/NotFound';

function App() {
  return (
    <Router>
      <Routes>

        {/* Public Routes */}
        <Route path="/" element={<Login />} />
        <Route path="/login" element={<Login />} />
        <Route path="/forgot-password" element={<ForgotPassword />} />
        <Route path="/reset-password" element={<ResetPassword />} />

        {/* Admin Protected Routes with Layout */}
        <Route
          path="/admin"
          element={
            <ProtectedRoute>
              <AdminLayout />
            </ProtectedRoute>
          }
        >
          <Route path="dashboard" element={<AdminDashboard />} />
          <Route path="employees" element={<EmployeePage />} />
          <Route path="assets" element={<AssetsPage />} />
          <Route path="add-asset" element={<AddAssetForm />} />
          <Route path="categories" element={<CategoriesPage />} />
          <Route path="pending-requests" element={<PendingAssetRequests />} />
          <Route path="return-requests" element={<ReturnRequests />} />
          <Route path="add-employee" element={<AddEmployeeForm />} />
          <Route path="employee/:id" element={<IndividualEmployee />} />
          <Route path="assets/view/:id" element={<IndividualAsset />} />
          <Route path="categories/add" element={<AddCategoryForm />} />
          <Route path="assigned-assets" element={<AssignedAssetsPage />} />
          <Route path="service-requests" element={<ServiceRequestsPage />} />
          <Route path="audit-requests" element={<AuditRequestsPage />} />
        </Route>

        {/* Employee Protected Routes with Layout */}
        <Route
          path="/employee"
          element={
            <ProtectedRoute>
              <EmployeeLayout />
            </ProtectedRoute>
          }
        >
          <Route path="dashboard" element={<EmployeeDashboard />} />
          <Route path="my-profile" element={<EmployeeProfile />} />
          <Route path="my-assets" element={<MyAssets />} />
          <Route path="available-assets" element={<AvailableAssets />} />
          <Route path="view-asset/:id" element={<ViewAsset />} />
          <Route path="my-service-requests" element={<MyServiceRequests />} />
          <Route path="audit-responses" element={<AuditResponsePage />} />

        </Route>

        {/* 404 Route */}
        <Route path="*" element={<NotFound />} />
      </Routes>
    </Router>
  );
}

export default App;
