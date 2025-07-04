import {Navigate, Outlet} from "react-router-dom";
import {useAuth} from "./AuthContext";

export default function ProtectedRoute ({allowedRoles})
{
    const{user} = useAuth();
    if(!user) {
        return <Navigate to = "/login" replace />;
    }

    if(!allowedRoles.includes(user.role)) {
        return <Navigate to = "/unauthorized-access" replace />;
    }

    return <Outlet/>;
}