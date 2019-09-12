import React, { Component } from 'react';
import './Login.css';
import Input from '../../components/inputtext/Input';
import Botao from '../../components/botao/Botao';

class Login extends Component {
    render() {
        return (
            <div className="Login">
                <Input
                    name="email"
                    type="email"
                    placeholder="e-mail"
                    value=""
                    onClick={() => {}}
                    textLabel="Login"
                />
                <Input
                    name="senha"
                    type="password"
                    placeholder="senha"
                    value=""
                    onClick={() => { }}
                    textLabel="Senha"
                />
                <Botao
                    texto="Entrar"
                    onClick={() => { }}
                />
            </div>
        );
    }
}

export default Login;