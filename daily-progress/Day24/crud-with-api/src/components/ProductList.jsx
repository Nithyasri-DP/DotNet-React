import React, { useEffect, useState } from "react";
import { getAllProducts } from "../services/productService";
import { Link } from "react-router-dom";
import EditProductModal from "../components/EditProductModal";
import { deleteProduct } from "../services/productService";


export default function ProductList() {
  const [product, setProduct] = useState([]);
  const [error, setError] = useState("");

  const [showModal, setShowModal] = useState(false);
  const [selectedProduct, setSelectedProduct] = useState(null);

  const handleEditClick = (product) => {
    setSelectedProduct(product);
    setShowModal(true);
  };

  const handleDeleteClick = async (id) => {
  const confirmDelete = window.confirm("Are you sure you want to delete this product?");
  if (!confirmDelete) return;

  try {
    await deleteProduct(id);
    fetchProducts();  
  } catch (err) {
    alert("Failed to delete product.");
  }
};

  const fetchProducts = async () => {
    try {
      const data = await getAllProducts();
      setProduct(data);
    } catch (err) {
      setError("Failed to load products");
    }
  };

  useEffect(() => {
    fetchProducts();
  }, []);

  return (
    <div className="container-fluid py-4 px-5">
      <div className="d-flex justify-content-between align-items-center mb-3">
        <h2 className="text-center my-3">Product List</h2>
        <a href="/add-product" className="btn btn-success">Add Product</a>
      </div>

      {error && <p className="text-danger text-center">{error}</p>}

      <div className="row row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-4 g-3">
        {product.length === 0 ? (
          <p className="text-center">No products available.</p>
        ) : (
          product.map((p) => (
            <div className="col" key={p.id}>
              <div className="card h-100 shadow-sm">
                <img 
                  src={p.productImageUrl} 
                  alt={p.name} 
                  className="product-image"
                />
                <div className="card-body d-flex flex-column">
                  <h5 className="card-title">{p.name}</h5>
                  <p className="card-text">Category: {p.category}</p>
                  <p className="card-text">Price: Rs.{p.sellingPrice}</p>
                  <p className="card-text">Stock: {p.quantity}</p>

                  <div className="d-flex justify-content-between mt-auto">
                    <Link to={`/product/${p.id}`} className="btn btn-outline-primary">View Details</Link>
                    <button className="btn btn-warning" onClick={() => handleEditClick(p)}>Edit</button>
                    <button className="btn btn-danger ms-2" onClick={() => handleDeleteClick(p.id)}>Delete</button>
                  </div>
                </div>
              </div>
            </div>
          ))
        )}
      </div>
      {showModal && (
        <EditProductModal
          product={selectedProduct}
          onClose={() => setShowModal(false)}
          onUpdateSuccess={fetchProducts} 
        />
      )}
    </div>
  );
}

