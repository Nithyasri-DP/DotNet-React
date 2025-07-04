import './App.css';
import {BrowserRouter, Route, Routes} from "react-router-dom";
import Home from "./pages/Home";
import Departments from "./pages/Departments";
import Navbar from './components/Navbar';
import Doctors from './pages/Doctors';
import BookAppointment from './pages/BookAppointment';
import NotFound from './pages/NotFound';
import { AuthProvider } from './auth/AuthContext';
import Login from './pages/Login';
import ProtectedRoute from './auth/ProtectedRoute';
import DoctorDashboard from './pages/DoctorDashboard';
import PatientDashboard from './pages/PatientDashboard';
import OwnerDashboard from './pages/OwnerDashboard';

function App() {
  return (
    <div className="App">
    <BrowserRouter>
    <AuthProvider>
      <Navbar />
      <Routes>
        <Route path = "/" element = {<Home/>} />
        <Route path = "/departments" element= {<Departments/>} />
        <Route path = "/doctors/:department" element={<Doctors/>}/>
        <Route path = "/book/:doctorId" element={<BookAppointment/>}/>
        <Route path = "/login" element={<Login/>}/>

        <Route element={<ProtectedRoute allowedRoles={["doctor"]} />}>
          <Route path="/doctor-dashboard" element={<DoctorDashboard />} />
        </Route>
        
        <Route element={<ProtectedRoute allowedRoles={["patient"]} />}>
          <Route path="/patient-dashboard" element={<PatientDashboard />} />
        </Route>

        <Route element={<ProtectedRoute allowedRoles={["owner"]} />}>
          <Route path="/owner-dashboard" element={<OwnerDashboard />} />
        </Route>

        <Route path = "*" element={<NotFound/>}/>
        
      </Routes>    
      </AuthProvider>
    </BrowserRouter>
    </div>
  );
}

export default App;
