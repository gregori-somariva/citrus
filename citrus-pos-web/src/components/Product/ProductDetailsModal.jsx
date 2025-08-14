function ProductDetailsModal({ product, onClose }) {
  if (!product) return null;

  return (
    <div className="fixed inset-0 bg-black/30 backdrop-blur-xs flex items-center justify-center z-50">
      <div className="bg-white rounded-lg shadow-lg max-w-lg w-full p-6">

        {/* Header */}
        <div className="flex justify-between items-center border-b pb-3">

          {/*CLOSE MODAL BUTTON*/}
          <button
            onClick={onClose}
            className="text-gray-400 text-[20px]"
          >
            x
          </button>
        </div>

        {/*PRODUCT IMAGE CONTAINER*/}
        <div className="w-full h-70 overflow-hidden">
          <img
            src={product.imageUrl}
            alt={product.name}
            className="h-full w-full object-cover border-b border-gray-300"
          />
        </div>

        {/* Info */}
        <div className="mt-4">
          <h2 className="text-xl font-bold py-4">{product.name}</h2>
          <p className="text-gray-700">{product.description}</p>
          <p className="mt-2 font-semibold">
            R${product.price?.toFixed(2)}
          </p>
        </div>

        {/* Add-ons */}
        {product.productAddons?.length > 0 && (
          <div className="mt-4">
            <h3 className="font-semibold mb-2">Available Add-ons:</h3>
            {product.productAddons.map((addon) => (
              <label
                key={addon.productAddonId}
                className="flex items-center gap-2 mb-1"
              >
                {addon.name}
              </label>
            ))}
          </div>
        )}
      </div>
    </div>
  );
}


export default ProductDetailsModal;