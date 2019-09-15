import React, { Component } from 'react';
import trincaLogo from './assets/images/trinca-logo.svg';
import './App.css';
import { routes } from './assets/js/routesConfig';
import { Route, Link } from 'react-router-dom/cjs/react-router-dom';
import { ToastsContainerPosition, ToastsStore, ToastsContainer } from 'react-toasts';

class App extends Component {

    constructor(props){
        super(props);
        this.state = {
            redirect: false,
            logado: window.localStorage.getItem("authToken") !== null
        }
        this.getFundoLogado = this.getFundoLogado.bind(this);
        this.logout = this.logout.bind(this);
        this.getBotaoSair = this.getBotaoSair.bind(this);
        this.getBotaoMenu = this.getBotaoMenu.bind(this);

    }

    getFundoLogado() {
        let auth = window.localStorage.getItem("authToken");
        if (auth !== null) {
            document.getElementsByTagName("html")[0].style.background = "white";
            return <div className="background-branco" />;
        } else {
            document.getElementsByTagName("html")[0].style.background = "#FFD836";
        }
        return "";
    }

    getBotaoSair() {
        if (this.state.logado) {
            return <div className="logout" onClick={this.logout}>Sair</div>
        } else {
            return "";
        }
    }

    getBotaoMenu() {
        if (this.state.logado) {
            return <Link to="/"><i className="fas fa-list func list" /></Link>
        } else {
            return "";
        }
    }

    logout() {
        window.localStorage.removeItem("authToken");
        window.location.href = "/";
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
                    {this.getBotaoSair()}
                    {this.getBotaoMenu()}
                    <img src={trincaLogo} className="trinca-logo" />
                </div>
                <ToastsContainer store={ToastsStore} position={ToastsContainerPosition.BOTTOM_CENTER} />
            </div>
        );
    }
}

export default App;
