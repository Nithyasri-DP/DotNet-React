import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../auth/AuthContext";

function Navbar(){
  const {user,logout} = useAuth();
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
    navigate("/");
  }

    return(
        <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
          <div className="container">
            <div className="navbar-nav">
                <Link to ="/" className="nav-link">Home</Link>
                <Link to="/departments" className="nav-link">Departments</Link>

                {/* Role based Webpage */}
                {user?.role === "doctor" && (
                  <Link to = "/doctor-dashboard" className="nav-link">Doctors Dashboard</Link>
                )}
                {user?.role === "patient" && (
                  <Link className="nav-link" to="/patient-dashboard">Patient Dashboard</Link>
                )}
                {user?.role === "owner" && (
                  <Link className="nav-link" to="/owner-dashboard">Owner Dashboard</Link>
                )}
            </div>

            <div className="navbar-nav">
              {user ? (
                <button className="btn btn-outline-light" onClick={handleLogout}>Logout</button>
              ) : (
                <Link to="/login" className="btn btn-outline-light">Login</Link>
              )}
            </div>    
          </div>        
        </nav>
    );
};

export default Navbar;


   
        