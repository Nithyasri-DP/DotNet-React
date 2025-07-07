import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { removeFromCart } from "../redux/cartSlice";

export default function Cart() {
  const cartItems = useSelector((state) => state.cart.items);
  const dispatch = useDispatch();

  return (
    <>
      <h2 className="mb-4">Cart</h2>
<div className="border p-3 rounded shadow-sm bg-light">
  {cartItems.length === 0 ? (
    <div className="text-muted">Cart is Empty</div>
  ) : (
    cartItems.map((item, index) => (
      <div
        className="d-flex justify-content-between align-items-center border-bottom py-2"
        key={index}
      >
        <span>{item.name} - Rs.{item.price}</span>
        <button
          className="btn btn-sm btn-outline-danger"
          onClick={() => dispatch(removeFromCart(item.id))}
        >
          Remove
        </button>
      </div>
    ))
  )}
</div>

    </>
  );
}
