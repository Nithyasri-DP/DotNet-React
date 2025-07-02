import api from "./api";

export default async function getAllProducts() {
  try {
    const res = await api.get("/products");
    console.log("Result", res.data);
    return res.data;
  } catch (error) {
    throw new Error("Failed to load the products");
  }
}
