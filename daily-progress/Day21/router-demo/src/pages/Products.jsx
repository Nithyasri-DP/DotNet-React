import React, { useEffect, useState } from "react";
import ProductCard from "../components/ProductCard";
import getAllProducts from "../services/ProductService";

export default function Products() {
  const [products, setProducts] = useState([]);
  const [error, setError] = useState("");

  useEffect(() => {
    getAllProducts()
      .then(setProducts)
      .catch((err) => setError(err.message));
  }, []);

  return (
    <div>
      <h2>Products List</h2>
      {error && <p style={{ color: "red" }}>{error}</p>}
      {products.map((p) => (
        <ProductCard key={p.id} product={p} />
      ))}
    </div>
  );
}
