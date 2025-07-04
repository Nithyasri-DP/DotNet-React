import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
// import EmployeeCrud from './EmployeeCrud';
import EmployeeDashboard from './components/EmployeeDashboard';

function App() {
  return (
    <div className="App">
      <EmployeeDashboard/>
      {/* <EmployeeCrud/> */}
    </div>
  );
}

export default App;
