import React, { Component } from 'react';
import bbqpattern from './assets/images/bbq-pattern.svg';
import trincaLogo from './assets/images/trinca-logo.svg';
import './App.css';
import Login from './pages/Login/Login';
import Cadastro from './pages/Cadastro/Cadastro';
import ListaChurras from './pages/ListaChurras/ListaChurras';
import DetalharChurras from './pages/DetalharChurras/DetalharChurras';
import NovoChurrasco from './pages/NovoChurrasco/NovoChurrasco';
import { routes } from './assets/js/routesConfig';
import { Route } from 'react-router-dom/cjs/react-router-dom';

class App extends Component {

    constructor(props){
        super(props);
        this.getFundoLogado = this.getFundoLogado.bind(this);
    }

    getFundoLogado() {
        let auth = window.localStorage.getItem("authToken");
        if (auth !== null) {
            return <div className="background-branco" />;
        }
        return "";
    }

    render() {
        return (
            <div>
                <div className="background">
                </div>
                {this.getFundoLogado()}
                <div className="App">
                    <h1 className="titulo">Agenda de Churras</h1>
                    <div className="content">
                        {routes.map((value, key) => {
                            let auth = window.localStorage.getItem("authToken");
                            if (auth === null && !value.needLogin) {
                                return <Route key={key} path={value.path} component={value.component} exact={value.exact}></Route>
                            } else if (auth !== null && value.needLogin) {
                                return <Route key={key} path={value.path} component={value.component} exact={value.exact}></Route>
                            } else {
                                return "";
                            }
                        })}
                    </div>
                    <img src={trincaLogo} className="trinca-logo" />
                </div>
            </div>
        );
    }
}

export default App;
