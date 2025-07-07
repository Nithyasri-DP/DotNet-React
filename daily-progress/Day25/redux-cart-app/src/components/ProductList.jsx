import React from "react";
import { useDispatch } from "react-redux";
import { addToCart } from "../redux/cartSlice";

const products = [
  { id: 1, name: "T-Shirt", price: 499 },
  { id: 2, name: "Jeans", price: 999 },
  { id: 3, name: "Shoes", price: 1499 },
];

export default function ProductList() {
  const dispatch = useDispatch();

  return (
    <>
      <h2 className="mb-4">Products</h2>
      {products.map((p) => (
        <div className="card mb-3 shadow-sm" key={p.id}>
          <div className="card-body">
            <h5 className="card-title">{p.name}</h5>
            <p className="card-text">Rs.{p.price}</p>
            <button className="btn btn-success" onClick={() => dispatch(addToCart(p))}>Add to Cart</button>
          </div>
        </div>
      ))}
    </>
  );
}
