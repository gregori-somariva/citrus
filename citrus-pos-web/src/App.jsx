import ProductCard from "./components/ProductCard";
import ComponentCarousel from "./components/ComponentCarousel";

function App() {
  const itemArray = [{
    itemName: 'aa',
    itemDescription: 'dsadsa',
    itemPrice: 'R$45,50'
  }];

  return (
    <div className="min-h-screen bg-white">
        <ProductCard item={itemArray[0]}></ProductCard>

        <ComponentCarousel itemArray={itemArray}></ComponentCarousel>
    </div>
    
  );
}

export default App;