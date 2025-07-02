import { createContext, useContext } from "react";

// useContext
export const UserContext = createContext(null);
export const useUser = () => useContext(UserContext);
