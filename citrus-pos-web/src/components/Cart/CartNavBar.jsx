function CartNavBar({ cartProducts = [] }) {
  return (
    <aside className="w-150 h-auto bg-white shadow-lg p-6 overflow-y-auto transition-all duration-300">

      {/*COMPANY LOGO CONTAINER*/}
      <div className="w-full flex items-center justify-center border-b border-gray-200">
        <img 
        src="/LogomarcaOficial.png" 
        alt="" 
        className="h-full w-full object-fit max-w-[50%] py-3"
        />
      </div>

      {cartProducts.length === 0 ? (
        <p className="text-gray-500">Your cart is empty.</p>
      ) : (
        <ul className="space-y-4">
          {
            cartProducts.map((product) => (
              <div>asdasddsa</div> 
            ))
          }
        </ul>
      )}
    </aside>
  );
}
export default CartNavBar;
