import React from 'react';
import bbqpattern from './assets/images/bbq-pattern.svg';
import trincaLogo from './assets/images/trinca-logo.svg';
import './App.css';
import Login from './pages/Login/Login';

function App() {
    return (
        <div className="App">
            <div className="background">
                <div className="shadowBox">
                    <img src={bbqpattern} className="top-background" alt="Top-Background" />
                    <div className="shadow"></div>
                </div>
                <h1>Agenda de Churras</h1>
                <img src={trincaLogo} className="trinca-logo" />
            </div>
            <div className="content">
                <Login />
            </div>
        </div>
    );
}

export default App;
