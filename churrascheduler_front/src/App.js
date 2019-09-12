import React, { Component } from 'react';
import bbqpattern from './assets/images/bbq-pattern.svg';
import trincaLogo from './assets/images/trinca-logo.svg';
import './App.css';
import Login from './pages/Login/Login';
import Cadastro from './pages/Cadastro/Cadastro';
import { isTSConstructorType } from '@babel/types';

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
            <div className="App">
                <div className="background">
                    <div className="shadowBox">
                        <img src={bbqpattern} className="top-background" alt="Top-Background" />
                        <div className="shadow"></div>
                    </div>
                    {this.getFundoLogado()}
                    <h1>Agenda de Churras</h1>
                    <img src={trincaLogo} className="trinca-logo" />
                </div>
                <div className="content">
                    <Cadastro />
                </div>
            </div>
        );
    }
}

export default App;
