import React, { Component } from 'react';
import trincaLogo from './assets/images/trinca-logo.svg';
import './App.css';
import { routes } from './assets/js/routesConfig';
import { Route, Redirect } from 'react-router-dom/cjs/react-router-dom';
import { ToastsContainerPosition, ToastsStore, ToastsContainer } from 'react-toasts';

class App extends Component {

    constructor(props){
        super(props);
        this.state = {
            redirect: false
        }
        this.getFundoLogado = this.getFundoLogado.bind(this);
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
                <ToastsContainer store={ToastsStore} position={ToastsContainerPosition.BOTTOM_CENTER} />
            </div>
        );
    }
}

export default App;
