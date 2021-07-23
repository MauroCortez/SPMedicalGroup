import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';
import { usuarioAutenticado, parseJwt } from './services/auth';

import './index.css';

import App from './pages/home/App';
import Consultas from './pages/consulta/consultas';
import Minhasconsultas from './pages/consulta/minhasconsultas';
import Login from './pages/login/login';
import NotFound from './pages/notFond/notFound';

import reportWebVitals from './reportWebVitals';

const PermissaoAdm = ({ component : Component }) => (
  <Route 
    render = { props => 
      usuarioAutenticado() && parseJwt().role === '1' ?
      <Component {...props} /> : 
      <Redirect to="/login" />
    }  
  />
)


const PermissaoUser = ({ component : Component }) => (
  <Route 
    render = { props => 
      usuarioAutenticado() && (parseJwt().role === '2' || parseJwt().role === '3') ?
      <Component {...props} /> : 
      <Redirect to="/login" />
    }  
  />
)



const routing = (
  <Router>
      <Switch>
        <Route exact path="/" component={App} />
        <PermissaoAdm path="/consultas" component={Consultas} />
        <Route path="/minhasconsultas" component={Minhasconsultas} />
        <Route path="/login" component={Login} />
        <Route exact path="/notfound" component={NotFound} />
        <Redirect to="/notfound" />
      </Switch>
  </Router>
)

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
