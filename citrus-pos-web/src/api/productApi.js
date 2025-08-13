import axios from "axios";

const api = axios.create({
    baseURL: 'https://localhost:6445/api',
    headers: { "Content-Type": "application/json" }
});

export async function getProducts() {
  try {
    const response = await api.get("/product");
    const data = response.data;

    if (data.success) {
      return data.data;
    } else {
      console.error("API returned success = false");
      return [];
    }
  } catch (error) {
    console.error("Error fetching products:", error);
    return [];
  }
}