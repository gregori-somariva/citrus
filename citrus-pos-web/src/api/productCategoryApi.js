import axios from "axios";

const api = axios.create({
    baseURL: 'https://localhost:6445/api',
    headers: { "Content-Type": "application/json" } 
});

export async function getProductCategories() {
    try {
        const response = await api.get('/productcategory');
        const data = response.data;

        if (data.success) {
            return data.data;
        } else {
            console.error('Error fetching product categories /api/productcategory');
            return [];
        }
    } catch (error) {
        console.error('Error fetching product categories:', error);
        return [];
    }
}
