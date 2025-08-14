function ProductCard({ 
    product = {
        productId: '-', 
        name: '-', 
        description: '-', 
        imageUrl: '-', 
        productCategoryId: '-', 
        price: '-', 
        stock: '-', 
        createdAt: '-', 
        updatedAt: '-'
    },
    variant = 'vertical',
    addToCart
}) {
    
    // Default: vertical variant
    return (
        <div className="bg-white h-80 w-60 border border-gray-300 rounded-md shadow-sm overflow-hidden flex flex-col">
            <div className="w-full h-[60%] overflow-hidden">
                <img
                    src={product.imageUrl}
                    alt={product.name}
                    className="h-full w-full object-cover border-b border-gray-300"
                />
            </div>

            <div className="text-center py-1 px-2">
                <h1 className="text-gray-800 text-lg font-semibold truncate">{product.name}</h1>
            </div>

            <div className="text-center px-3 flex-1">
                <p className="text-gray-500 text-xs line-clamp-2">
                    {product.description || 'No description available'}
                </p>
            </div>

            <div className="flex justify-between products-center px-3 py-2 border-t border-gray-200">
                <span className="text-gray-600 font-medium">{product.price ? `R$${product.price}` : '-'}</span>
                <button 
                className="bg-blue-500 text-white text-sm px-3 py-1 rounded hover:bg-blue-600 transition"
                onClick={() => addToCart(product)}>
                    Add
                </button>
            </div>
        </div>
    );
}

export default ProductCard;
