import { useEffect, useState } from 'react';
import ProductCard from './components/Product/ProductCard';
import ProductCategoryContainer from './components/Product/ProductCategoryContainer';

function App() {
  const [productArray, setProductArray] = useState([]);

  useEffect(() => {
    async function fetchProductArray() {
      const response = await fetch('https://localhost:6445/api/product');
      const jsonResponse = await response.json();

      if (jsonResponse.success) {
        setProductArray(jsonResponse.data);
      } else {
        setProductArray([]);
      }
    }

    fetchProductArray();
  }, []);

  return (
    <div className="min-h-screen bg-gray-50 flex items-center justify-center">
      <ProductCategoryContainer productArray={productArray} />
    </div>
  );
}

export default App;
