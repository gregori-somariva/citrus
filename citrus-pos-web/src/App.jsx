  import { useEffect, useState } from 'react';

  import CartNavBar from './components/Cart/CartNavBar'
  import ProductCategoryContainer from './components/Product/ProductCategoryContainer'
  import ClientHomePage from './pages/ClientHomePage';

function App() {
  const [cartProducts, setCartProducts] = useState([]);

  const addToCart = (product) => {
    setCartProducts((prev) => [...prev, product]); 
  };

  return (
    <div className="min-h-screen bg-gray-50 flex">

      <ClientHomePage addToCart={addToCart} />
      
      <CartNavBar cartProducts={cartProducts}/>
    </div>
  );
}

export default App;
