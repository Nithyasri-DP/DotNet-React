import ProductList from "./components/ProductList";
import Cart from "./components/Cart";
import 'bootstrap/dist/css/bootstrap.min.css';


export default function App() {
  return (
    <div className="container mt-5">
      <div className="row">
        <div className="col-md-6">
          <ProductList />
        </div>
        <div className="col-md-6">
          <Cart />
        </div>
      </div>
    </div>
  );
}
