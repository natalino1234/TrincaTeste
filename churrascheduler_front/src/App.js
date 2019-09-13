import React, { Component } from 'react';
import bbqpattern from './assets/images/bbq-pattern.svg';
import trincaLogo from './assets/images/trinca-logo.svg';
import './App.css';
import Login from './pages/Login/Login';
import Cadastro from './pages/Cadastro/Cadastro';
import ListaChurras from './pages/ListaChurras/ListaChurras';

class App extends Component {

    constructor(props){
        super(props);
        this.getFundoLogado = this.getFundoLogado.bind(this);
    }

    getFundoLogado() {
        let auth = window.localStorage.getItem("authToken");
        auth = true;
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
                        <ListaChurras />
                    </div>
                    <img src={trincaLogo} className="trinca-logo" />
                </div>
            </div>
        );
    }
}

export default App;
