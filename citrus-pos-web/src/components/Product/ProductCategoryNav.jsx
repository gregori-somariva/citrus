function ProductCategoryNav({ productArray = [], onSelectCategory, selectedCategoryId }) {

  const uniqueCategoriesMap = new Map();

  productArray.forEach(p => {
    const cat = p.productCategory;
    if (!uniqueCategoriesMap.has(cat.productCategoryId)) {
      uniqueCategoriesMap.set(cat.productCategoryId, cat.name);
    }
  });

  const categories = Array.from(uniqueCategoriesMap, ([id, name]) => ({ id, name }));

    return (
        <div className="flex gap-3 overflow-x-auto py-2 px-1">
            
        {/* All Button */}
        <button
            className={`px-4 py-2 rounded-md font-medium transition ${
            selectedCategoryId === null
                ? 'bg-blue-500 text-white'
                : 'bg-gray-200 text-gray-700 hover:bg-gray-300'
            }`}
            onClick={() => onSelectCategory(null)}
        >
            All
        </button>

        {/* Category Buttons */}
        {categories.map(category => (
            <button
            key={category.id}
            className={`px-4 py-2 rounded-md font-medium transition ${
                selectedCategoryId === category.id
                ? 'bg-blue-500 text-white'
                : 'bg-gray-200 text-gray-700 hover:bg-gray-300'
            }`}
            onClick={() => onSelectCategory(category.id)}
            >
            {category.name}
            </button>
        ))}
        </div>
    );
    }

export default ProductCategoryNav;
