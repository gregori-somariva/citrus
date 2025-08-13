import ProductCard from "./ProductCard";

function ProductCategoryContainer({ products }) {

  // Group products by category
  const categoriesMap = products.reduce((acc, product) => {
    const categoryId = product.productCategoryId;
    const categoryName = product.productCategory?.name || "Uncategorized";

    if (!acc[categoryId]) {
      acc[categoryId] = {
        name: categoryName,
        items: [],
      };
    }

    acc[categoryId].items.push(product);
    return acc;
  }, {});

  const categories = Object.values(categoriesMap);

  return (
    <div className="p-4 space-y-8">
      {categories.map((category) => (

        <div key={category.name}>

          {/* Category name with line */}
          <div className="flex items-center mb-4">
            <h2 className="text-2xl text-gray-700">{category.name}</h2>
            <div className="flex-grow h-px bg-gray-100 ml-4"></div>
          </div>

          {/* Products */}
          <div className="flex flex-wrap gap-4">
            {category.items.map((product) => (
              <ProductCard key={product.productId} item={product} />
            ))}
          </div>
        </div>
      ))}
    </div>
  );
}

export default ProductCategoryContainer;
