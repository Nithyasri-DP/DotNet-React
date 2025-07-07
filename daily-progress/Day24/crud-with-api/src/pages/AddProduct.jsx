import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { addProduct } from "../services/productService";

export default function AddProduct() {
  const [product, setProduct] = useState({
    name: "",
    sku: "",
    category: "",
    manufacturingCost: 0,
    sellingPrice: 0,
    stockQuantity: 0,
    productImageUrl: "",
  });

  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleChange = (e) => {
    setProduct({ ...product, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await addProduct(product);
      navigate("/product-list");
    } catch (err) {
      setError("Failed to add product. Please try again.");
    }
  };

  return (
    <div className="container mt-4">
      <h2 className="text-center mb-4">Add Product</h2>
      {error && <p className="text-danger">{error}</p>}

      <form onSubmit={handleSubmit}>
        <div className="row mb-3">
          <div className="col">
            <label>Name</label>
            <input type="text" name="name" className="form-control" onChange={handleChange} required />
          </div>
          <div className="col">
            <label>SKU</label>
            <input type="text" name="sku" className="form-control" onChange={handleChange} />
          </div>
        </div>

        <div className="row mb-3">
          <div className="col">
            <label>Category</label>
            <input type="text" name="category" className="form-control" onChange={handleChange} />
          </div>
          <div className="col">
            <label>Manufacturing Cost</label>
            <input type="number" name="manufacturingCost" className="form-control" onChange={handleChange} />
          </div>
        </div>

        <div className="row mb-3">
          <div className="col">
            <label>Selling Price</label>
            <input type="number" name="sellingPrice" className="form-control" onChange={handleChange} />
          </div>
          <div className="col">
            <label>Stock Quantity</label>
            <input type="number" name="quantity" className="form-control" onChange={handleChange} />
          </div>
        </div>

        <div className="mb-3">
          <label>Image URL</label>
          <input type="text" name="productImageUrl" className="form-control" onChange={handleChange} />
        </div>

        <button type="submit" className="btn btn-primary w-100">Add Product</button>
      </form>
    </div>
  );
}
