import { useEffect, useState } from "react";
import { getProducts } from "./api/productApi";
import ProductCategoryContainer from "./components/ProductCategoryContainer";
import ProductCategoryNavBar from "./components/ProductCategoryNavBar";

function App() {
  const [products, setProducts] = useState([]);
  const [filteredProducts, setFilteredProducts] = useState([]);
  const [searchTerm, setSearchTerm] = useState(""); // new

  useEffect(() => {
    const fetchProducts = async () => {
      const data = await getProducts();
      setProducts(data);
      setFilteredProducts(data);
    };
    fetchProducts();
  }, []);

  const handleCategorySelect = (categoryId) => {
    filterProducts(categoryId, searchTerm);
  };

  const handleSearch = (term) => {
    setSearchTerm(term);
    filterProducts(null, term);
  };

  const filterProducts = (categoryId, term) => {
    let result = [...products];

    if (categoryId) {
      result = result.filter(p => p.productCategoryId === categoryId);
    }

    if (term) {
      const lowerTerm = term.toLowerCase();
      result = result.filter(
        p =>
          p.name.toLowerCase().includes(lowerTerm) ||
          p.description.toLowerCase().includes(lowerTerm)
      );
    }

    setFilteredProducts(result);
  };

  return (
    <div className="min-h-screen bg-white">
      <ProductCategoryNavBar
        onSelectCategory={handleCategorySelect}
        onSearch={handleSearch} // new
      />
      <ProductCategoryContainer products={filteredProducts} />
    </div>
  );
}

export default App;
