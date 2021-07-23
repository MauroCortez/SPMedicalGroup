import { Link } from 'react-router-dom';
import './App.css';

function App() {
  return (
    <div className="App">
      <h1>Pagina Home</h1>
      <Link className="botao" to="login">Faça Login</Link> 
   </div>
  );
}

export default App;
