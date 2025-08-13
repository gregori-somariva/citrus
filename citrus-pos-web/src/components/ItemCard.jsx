import placeholderImg from '/placeholder-img.png';

function ItemCard() {
    const itemTitle = 'TESTE 1';
    const itemDescription = 'This is a short description of the item.';
    const itemPrice = 'R$35,90';

    return (
        <div className="border-1 border-gray-800 w-65 h-auto bg-gray-900 rounded-sm flex flex-col p-3">

            {/* Image */}
            <div className="flex justify-center mb-2 flex-shrink-0">
                <img src={placeholderImg} className="w-[60%] object-contain" alt={itemTitle} />
            </div>

            {/* Text Content */}
            <div className="flex flex-col justify-between flex-1">
                <h3 className="text-white font-semibold text-lg text-center mb-1">{itemTitle}</h3>
                <p className="text-gray-300 text-sm text-center mb-2">{itemDescription}</p>
            </div>

            {/* Price + Button */}
            <div className='flex flex-col w-full items-center justify-center space-y-2'>
                
                {/* Price */}
                <div className="text-yellow-500 font-bold p-1 w-max">
                    {itemPrice}
                </div>

                {/* Button with absolute cart icon */}
                <button className="bg-purple-700 text-white text-sm px-5 py-1 rounded-md transition-colors duration-150 relative flex justify-center items-center hover:cursor-pointer hover:scale-102 transition-transform duration-100">
                    
                    Adicionar ao carrinho
                    
                    {/* Cart Icon absolute on the left */}
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

export default ItemCard;
