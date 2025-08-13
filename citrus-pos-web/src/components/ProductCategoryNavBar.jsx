import { useEffect, useState } from "react";
import { getProductCategories } from "../api/productCategoryApi";

function ProductCategoryNavBar({ onSelectCategory, onSearch }) {
  const [categories, setCategories] = useState([]);
  const [activeCategory, setActiveCategory] = useState(null);

  useEffect(() => {
    const fetchCategories = async () => {
      const data = await getProductCategories();
      setCategories(data);
    };
    fetchCategories();
  }, []);

  const handleSelect = (categoryId) => {
    setActiveCategory(categoryId);
    onSelectCategory(categoryId);
  };

  return (
    <nav className="flex flex-col md:flex-row md:items-center md:justify-between p-4 bg-white shadow-md rounded-sm">
      
      {/* Category buttons */}
      <div className="flex space-x-4 overflow-x-auto mb-2 md:mb-0">
        <button
          className={`px-4 py-2 rounded-sm font-semibold flex-shrink-0 transition-shadow duration-200 ${
            activeCategory === null
              ? "bg-purple-700 text-white shadow-lg"
              : "bg-gray-100 text-gray-700 hover:shadow-md"
          }`}
          onClick={() => handleSelect(null)}
        >
          All
        </button>

        {categories.map((category) => (
          <button
            key={category.productCategoryId}
            className={`px-4 py-2 rounded-sm font-semibold flex-shrink-0 transition-shadow duration-200 ${
              activeCategory === category.productCategoryId
                ? "bg-purple-700 text-white shadow-lg"
                : "bg-gray-100 text-gray-700 hover:shadow-md"
            }`}
            onClick={() => handleSelect(category.productCategoryId)}
          >
            {category.name}
          </button>
        ))}
      </div>

      {/* Search input + Cart button */}
      <div className="flex items-center space-x-2">
        <input
          type="text"
          placeholder="Search products..."
          onChange={(e) => onSearch(e.target.value)}
          className="border border-gray-300 rounded-md p-2 w-full md:w-64"
        />
      </div>
    </nav>
  );
}

export default ProductCategoryNavBar;
