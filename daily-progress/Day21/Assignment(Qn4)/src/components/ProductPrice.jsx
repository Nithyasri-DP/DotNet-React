import React from "react";

function ProductPrice({ name, price, quantity }) {
  const total = price * quantity;

  return (
    <div style={styles.card}>
      <h2>{name}</h2>
      <p>Price per item: ₹{price}</p>
      <p>Quantity: {quantity}</p>
      <h3>Total Price: ₹{total}</h3>
    </div>
  );
}

const styles = {
  card: {
    border: "1px solid #ddd",
    padding: "15px",
    borderRadius: "8px",
    marginBottom: "20px",
    maxWidth: "300px",
    boxShadow: "0 0 10px rgba(0,0,0,0.1)",
  }
};

export default ProductPrice;
