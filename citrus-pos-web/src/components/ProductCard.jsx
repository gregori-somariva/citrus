function ProductCard({
  item: {
    productId = '-'  ,
    name = '-',
    description = '-',
    imageUrl,
    productCategoryId = '-'  ,
    price = '-',
    stock = '-',
    createdAt = '-',
    updatedAt = '-'
  }
}) {

    return (
        <div className="
                border-1 
                border-gray-300 
                w-65 
                h-auto 
                shadow-md 
                hover:shadow-lg 
                transition-shadow 
                duration-200
                bg-white 
                rounded-sm 
                flex 
                flex-col 
                pb-3 
                flex-shrink-0"
            >
            
            {/* Image */}
            <div className="w-full h-48 flex justify-center items-center mb-2 flex-shrink-0 bg-gray-100 overflow-hidden">
            <img
                src={imageUrl && imageUrl !== 'string' ? imageUrl : '/placeholder-img.png'}
                className="w-full h-full object-cover"
                alt={name}
            />
            </div>

            {/* Text Content */}
            <div className="flex flex-col justify-between flex-1">
                <h3 className="text-black font-semibold text-lg text-center mb-1">{name}</h3>
                <p className="text-gray-500 text-sm text-center mb-2">{description}</p>
            </div>

            {/* Price + Button */}
            <div className='flex flex-col w-full items-center justify-center space-y-2'>

                {/* Price */}
                <div className="text-yellow-500 font-bold p-1 w-max">
                    {price}
                </div>

                {/* Button with absolute cart icon */}
                <button className="
                    bg-purple-700 
                    text-white 
                    text-sm 
                    px-5 
                    py-2 
                    rounded-md 
                    transition-colors 
                    duration-150 
                    relative 
                    flex 
                    justify-center 
                    items-center 
                    hover:cursor-pointer 
                    hover:scale-102 
                    transition-transform 
                    duration-100"
                >

                    Adicionar ao carrinho
                    
                    {/* Cart Icon */}
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        className="h-5 w-5 left-3"
                        fill="none"
                        viewBox="0 0 24 24"
                        stroke="currentColor"
                    >
                        <path
                            strokeLinecap="round"
                            strokeLinejoin="round"
                            strokeWidth={2}
                            d="M3 3h2l.4 2M7 13h10l4-8H5.4M7 13L5.4 5M7 13l-2 6h14l-2-6M9 21h0M15 21h0"
                        />
                    </svg>
                </button>
            </div>
        </div>
    );
}

export default ProductCard;
