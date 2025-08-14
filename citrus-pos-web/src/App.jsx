import { useState } from 'react';
import CartNavBar from './components/Cart/CartNavBar';
import ClientHomePage from './pages/ClientHomePage';
import ProductDetailsModal from './components/Product/ProductDetailsModal';

function App() {
  const [cartProducts, setCartProducts] = useState([]);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [selectedProduct, setSelectedProduct] = useState(null);

  const addToCart = (productWithExtras) => {
    setCartProducts((prev) => [...prev, productWithExtras]);
  };

  //Changes the state of the isModalOpen state so
  //that the ProductDetailModal is rendered
  const openModal = (product) => {
    setSelectedProduct(product);
    setIsModalOpen(true);
  };

  //Set isModalOpen to false so do not render it when triggered
  const closeModal = () => {
    setSelectedProduct(null);
    setIsModalOpen(false);
  };

  return (
    <div className="min-h-screen bg-gray-50 flex">
      <ClientHomePage openProductModal={openModal} />

      {isModalOpen && (
        <ProductDetailsModal
          product={selectedProduct}
          onClose={closeModal}
          addToCart={addToCart}
        />
      )}

    </div>
  );
}

export default App;
