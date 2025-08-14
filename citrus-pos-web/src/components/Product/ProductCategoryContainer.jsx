import ProductCard from './ProductCard'

function ProductCategoryContainer({ productArray = [], openProductModal  }) {

  const groupedProductsByCategory = productArray.reduce((accumulator, product) => {
    const categoryName = product.productCategory.name;

    if (!accumulator[categoryName]) {   
      accumulator[categoryName] = [];
    }

    accumulator[categoryName].push(product);
    return accumulator;
  }, {}); 

  return (
      <div className="space-y-8 w-full p-6 overflow-auto">
        {Object.entries(groupedProductsByCategory).map(([categoryName, products]) => (
          <div key={categoryName} className='flex flex-col items-start w-full'>
            <h2 className="text-xl text-gray-700 font-bold mb-4">{categoryName}</h2>
            <div className="flex flex-wrap gap-4">
              {
                products.map(product => (

                  <ProductCard 
                    key={product.productId} 
                    product={product} 
                    openProductModal={openProductModal}
                  />
                  
                ))
              }
            </div>
          </div>
        ))}
      </div>
    );
  }

export default ProductCategoryContainer;
