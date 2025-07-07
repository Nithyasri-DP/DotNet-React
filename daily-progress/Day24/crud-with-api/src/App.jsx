import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import {AuthProvider} from "./auth/AuthContext";
import PrivateRoute from "./auth/PrivateRoute";
import Login from "./components/Login";
import ProductList from "./components/ProductList"; 
import ProductDetails from "./pages/ProductDetails";
import AddProduct from "./pages/AddProduct";

export default function App()
{
  return (
    <AuthProvider>
      <BrowserRouter>
      <Routes>
        <Route path = "/" element={<Login/>}/>
        <Route path = "/login" element={<Login/>}/>
        <Route path = "/product-list" element={<PrivateRoute> <ProductList/> </PrivateRoute>}/>  
        <Route path="/product/:id" element={<ProductDetails />} />
        <Route path="/add-product" element={<AddProduct />} />
        <Route path = "/unauthorized" element={<h2>Access Denied</h2>}/>
      </Routes>
      </BrowserRouter>
    </AuthProvider>
  );
}

// import React,{useState} from "react";
// import ClickCounterClass from "./classcomponentdemo/ClickCounterClass";
// import LifeCycleDemo from "./classcomponentdemo/LifeCycleDemo";
// import LifeCycleFunctional from "./classcomponentdemo/LifeCycleFunctional";

// function App() {

//   const [showComponent, setShowComponent] = useState(true);
//   return (
//     <div>
//       <ClickCounterClass />

//       <button onClick={() => setShowComponent(!showComponent)}>
//         {showComponent ? "Hide" : "Show"} LifeCycleDemo
//       </button>
//       {showComponent && <LifeCycleDemo />}

//       <button onClick={() => setShowComponent(!showComponent)}>
//         {showComponent ? "Hide" : "Show"} LifeCycleFunctional
//       </button>

//       {showComponent && <LifeCycleFunctional />}
//     </div>   
//   );
// }

// export default App;

