import React from "react";
import ProductCard from "../components/ProductCard";

export default function ProductList() {
  // const products = [
  //   { id: 1, name: "Laptop", price: "76000" },
  //   { id: 2, name: "Mouse", price: "3000" },
  //   { id: 3, name: "Tablet", price: "72000" },
  // ];

  return (
    <div>
      <h2>Product List</h2>
      {products.map((p) => (
        <ProductCard key={p.id} product={p} />
      ))}
    </div>
  );
}
