import axios from "axios";

export const getAllProducts = async () => {
  try {
    const response = await axios.get("https://localhost:7120/api/Products/all");
    return response.data;
  } catch (err) {
    console.error("Error fetching products", err);
    throw err;
  }
};

export const addProduct = async (productData) => {
  try {
    const response = await axios.post("https://localhost:7120/api/Products/create", productData);
    return response.data;
  } catch (err) {
    console.error("Error adding product:", err);
    throw err;
  }
};

export const updateProduct = async (id, productData) => {
  try {
    const response = await axios.put(`https://localhost:7120/api/Products/update/${id}`, productData);
    return response.data;
  } catch (err) {
    console.error("Error updating product", err);
    throw err;
  }
};

export const deleteProduct = async (id) => {
  try {
    const response = await axios.delete(`https://localhost:7120/api/Products/delete/${id}`);
    return response.data;
  } catch (err) {
    console.error("Error deleting product", err);
    throw err;
  }
};

