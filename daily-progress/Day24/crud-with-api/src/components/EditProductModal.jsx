import React, { useState } from "react";
import { updateProduct } from "../services/productService";

export default function EditProductModal({ product, onClose, onUpdateSuccess }) {
  // isActive: true to avoid being set to false after update
  const [formData, setFormData] = useState({ 
    ...product, 
    isActive: product.isActive !== undefined ? product.isActive : true 
  });

  const [error, setError] = useState("");

  const handleChange = (e) => {
    setFormData({ 
      ...formData, 
      [e.target.name]: e.target.value 
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");

    try {
      await updateProduct(product.id, formData); 
      onUpdateSuccess();     
      onClose();             
    } catch (err) {
      setError("Failed to update product");
    }
  };

  return (
    <div className="modal fade show d-block" tabIndex="-1" style={{ backgroundColor: "rgba(0,0,0,0.5)" }}>
      <div className="modal-dialog">
        <div className="modal-content">
          <form onSubmit={handleSubmit}>
            <div className="modal-header">
              <h5 className="modal-title">Edit Product</h5>
              <button type="button" className="btn-close" onClick={onClose}></button>
            </div>
            <div className="modal-body">
              {error && <p className="text-danger">{error}</p>}

              <div className="mb-3">
                <label className="form-label">Product Name</label>
                <input type="text" name="name" value={formData.name} onChange={handleChange} className="form-control" required />
              </div>

              <div className="mb-3">
                <label className="form-label">Category</label>
                <input type="text" name="category" value={formData.category} onChange={handleChange} className="form-control" />
              </div>

              <div className="mb-3">
                <label className="form-label">Selling Price</label>
                <input type="number" name="sellingPrice" value={formData.sellingPrice} onChange={handleChange} className="form-control" required />
              </div>

              <div className="mb-3">
                <label className="form-label">Stock Quantity</label>
                <input type="number" name="quantity" value={formData.quantity} onChange={handleChange} className="form-control" required />
              </div>

              <div className="mb-3">
                <label className="form-label">Image URL</label>
                <input type="text" name="productImageUrl" value={formData.productImageUrl} onChange={handleChange} className="form-control" />
              </div>

              <input type="hidden" name="isActive" value={formData.isActive} />
            </div>
            <div className="modal-footer">
              <button type="submit" className="btn btn-primary">Save Changes</button>
              <button type="button" className="btn btn-secondary" onClick={onClose}>Cancel</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}
