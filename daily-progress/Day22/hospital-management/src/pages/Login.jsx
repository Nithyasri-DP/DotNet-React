import { useState } from "react";
import { useAuth } from "../auth/AuthContext";
import { useNavigate } from "react-router-dom";

function Login(){
    const [formData,setFormData] = useState(
        {
            username : '',
            password : '',
        }
    );

    //getting logging in fun & altering handleSubmit to restrict login

    const {login} = useAuth();
    const navigate = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();
        const result = login(formData);

        if(!result.ok){
            alert(result.message);
        }
        else{
            if(result.role === "doctor"){
                navigate("/doctor-dashboard");
            }
        }

    };
    
    return(
        <div className="container mt-4">
        <h3 className="mb-3 text-center">Login Details</h3>
        <div className="d-flex justify-content-center">
            <form onSubmit={handleSubmit}>
                <div className="mb-3">
                    <label>Username</label>
                    <input 
                    type="text"
                    className="form-control"
                    value={formData.username}
                    onChange={(e)=>setFormData({...formData,username:e.target.value})}
                    />
                </div>

                  <div className="mb-3">
                    <label>Password</label>
                    <input 
                    type="password"
                    className="form-control"
                    value={formData.password}
                    onChange={(e)=>setFormData({...formData,password:e.target.value})}
                    />
                </div>
                <button type = "submit" className="btn btn-primary">Login</button>
            </form>
        </div>
        
        </div>

    );
}

export default Login;