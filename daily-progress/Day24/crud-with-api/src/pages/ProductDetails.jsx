import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";

export default function ProductDetails() {
  const { id } = useParams();
  const [product, setProduct] = useState(null);
  const [error, setError] = useState("");

  useEffect(() => {
    const fetchProduct = async () => {
      try {
        const response = await axios.get(`https://localhost:7120/api/Products/id/${id}`);
        setProduct(response.data);
      } catch (err) {
        setError("Failed to load product details");
      }
    };
    fetchProduct();
  }, [id]);

  if (error) return <p className="text-danger">{error}</p>;
  if (!product) return <p>Loading...</p>;

  return (
    <div className="container py-4">
      <h2>{product.name}</h2>
      <img src={product.productImageUrl || "https://via.placeholder.com/300"} alt={product.name} style={{ width: "300px" }} />
      <p>Category: {product.category}</p>
      <p>Price: ₹{product.sellingPrice}</p>
      <p>Stock: {product.quantity}</p>
      <p>SKU: {product.sku}</p>
    </div>
  );
}
