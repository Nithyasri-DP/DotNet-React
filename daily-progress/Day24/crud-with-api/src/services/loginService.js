import axios from "axios";
const API_URL = "https://localhost:7120/api";

export const login = async (username, password) => {
    try{
        // const response = await axios.post("/Auth/login", {username, password});
        const response = await axios.post(`${API_URL}/Auth/login`, { username, password });
        const {token} = response.data;
        localStorage.setItem("token",token);
        localStorage.setItem("username",username);
        return response.data;   
    } 
    catch(err){
        throw new Error(err.response?.data?.message || "Login failed");
    }
};

export const logout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("username");
};

export const isAuthenticated = () => {
    return !!localStorage.getItem("token");
};