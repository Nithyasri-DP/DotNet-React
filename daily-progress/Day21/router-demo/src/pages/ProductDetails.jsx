// import React from "react";
// import { useParams, useNavigate } from "react-router-dom";

// export default function ProductDetails() {
//   const { id } = useParams();
//   const navigate = useNavigate();

//   const products = [
//     { id: 1, name: "Laptop", price: "76000" },
//     { id: 2, name: "Mouse", price: "3000" },
//     { id: 3, name: "Tablet", price: "72000" },
//   ];

//   const product = products.find((p) => p.id === parseInt(id));

//   if (!product) {
//     return <h3>Product not found</h3>;
//   }

//   return (
//     <div>
//       <h2>Product Details</h2>
//       <p><strong>ID:</strong> {product.id}</p>
//       <p><strong>Name:</strong> {product.name}</p>
//       <p><strong>Price:</strong> Rs.{product.price}</p>

//       <button onClick={() => navigate("/products")} style={{ marginTop: "10px" }}>
//         Back to Product List
//       </button>
//     </div>
//   );
// }


import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import api from "../services/api";

export default function ProductDetails() {
  const { id } = useParams();
  const [product, setProduct] = useState(null);
  const [error, setError] = useState("");

  useEffect(() => {
    api
      .get(`/products/${id}`)
      .then((res) => setProduct(res.data))
      .catch((err) => setError("Failed to load product details"));
  }, [id]);

  if (error) return <p>{error}</p>;
  if (!product) return <p>Loading...</p>;

  return (
    <div style={{ padding: "20px", maxWidth: "600px" }}>
      <h2>{product.title}</h2>
      <img src={product.image} alt={product.title} height={150} style={{ marginBottom: "10px" }} />
      <p><strong>Price:</strong> Rs.{product.price}</p>
      <p><strong>Category:</strong> {product.category}</p>
      <p><strong>Description:</strong> {product.description}</p>
      <p><strong>Rating:</strong> {product.rating?.rate} ({product.rating?.count} reviews)</p>
    </div>
  );
}


