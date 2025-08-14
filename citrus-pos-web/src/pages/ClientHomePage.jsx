import { useEffect, useState } from 'react';

import ProductCategoryNav from '../components/Product/ProductCategoryNav';
import ProductCategoryContainer from '../components/Product/ProductCategoryContainer';

function ClientHomePage({addToCart}) {
  const [productArray, setProductArray] = useState([]);
  const [selectedCategoryId, setSelectedCategoryId] = useState(null);

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

  const filteredProducts = selectedCategoryId
    ? productArray.filter(p => p.productCategory.productCategoryId === selectedCategoryId)
    : productArray;

  return (
    <div className="flex flex-col w-full items-center">
      
      <ProductCategoryNav
        productArray={productArray}
        onSelectCategory={setSelectedCategoryId}
        selectedCategoryId={selectedCategoryId}
      />

      <ProductCategoryContainer 
        productArray={filteredProducts} 
        addToCart={addToCart}
      />
    </div>
  );
}

export default ClientHomePage;
