import { useContext, createContext, useState } from "react";
import { useNavigate } from "react-router-dom";

const AuthContext = createContext();

const dummydata = [
   {username:"Rajesh", password:"patient123", role:"patient"},
   {username:"Sharmi", password:"doctor123", role:"doctor"},
   {username:"Owner", password:"owner123", role:"owner"},
]

export function AuthProvider({children}){
    const [user, setUser] = useState(null);
    const navigate = useNavigate();

    const login = ({username,password}) => {
        const loggedUser = dummydata.find(
            (u) => u.username===username && u.password===password 
        );
        if (!loggedUser) return { ok: false, message: "Invalid Username or Password" };
        setUser(loggedUser);
        return{ok:true, role:loggedUser.role};
    };

    // const logout = () => {
    //     setUser(null);
    // };

    const logout = () => {
        setUser(null);
        navigate("/login", { replace: true });
        };


    return (
        <AuthContext.Provider value={{login,logout,user}}>
            {children}
        </AuthContext.Provider>
                
    );
}

export const useAuth = () => useContext(AuthContext);
