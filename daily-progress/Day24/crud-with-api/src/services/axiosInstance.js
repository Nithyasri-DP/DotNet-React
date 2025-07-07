import axios from "axios";
import instance from "./axios";

const instance = axios.create ({
    baseURL : "https://localhost:7120/api",
    headers : {"Context-type" : "application/json"},
});

instance.interceptors.request.use((config)=>
{
    const token = localStorage.getItem("token");
    if (token) { 
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
}); 