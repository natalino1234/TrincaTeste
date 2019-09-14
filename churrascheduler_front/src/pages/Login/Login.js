import React, { Component } from 'react';
import './Login.css';
import Input from '../../components/inputtext/Input';
import Botao from '../../components/botao/Botao';
import { Redirect, Link } from 'react-router-dom';
import { Authenticate } from '../../functions/RestClient';
import { alert } from '../../assets/js/Notifications';

class Login extends Component {

    constructor(props) {
        super(props);

        this.state = {
            login: "",
            senha: "",
            redirect: false
        }
        this.entrarClick = this.entrarClick.bind(this);
        this.renderRedirect = this.renderRedirect.bind(this);
    }

    entrarClick(evt) {
        if (this.state.login === "") {
            alert.info("O campo de e-mail está vazio.");
            return;
        } else if (this.state.senha === "") {
            alert.info("O campo de senha está vazio.");
            return;
        }
        let callback = (result) => {
            if (result === null) {
                alert.error("Houve algum erro no processamento, tente novamente.");
            } else {
                if (result[0]) {
                    window.localStorage.setItem("authToken", result[1]);
                    this.setState({ redirect: true });
                } else {
                    alert.error(result[1]);
                }
            }
        };
        Authenticate(this.state.login, this.state.senha, callback);
    }

    renderRedirect() {
        if (this.state.redirect) {
            window.location.reload();
        } else {
            return "";
        }
    }

    render() {
        return (
            <div className="Login">
                <Input
                    name="email"
                    type="email"
                    placeholder="e-mail"
                    value={this.state.login}
                    onChange={(evt) => { this.setState({ login: evt.target.value}) }}
                    textLabel="Login"
                />
                <Input
                    name="senha"
                    type="password"
                    placeholder="senha"
                    value={this.state.senha}
                    onChange={(evt) => { this.setState({ senha: evt.target.value }) }}
                    textLabel="Senha"
                />
                <Botao
                    texto="Entrar"
                    onClick={this.entrarClick}
                />
                <Link className="botao" to="/Cadastro">
                    <span>Cadastrar</span>
                </Link>
                {this.renderRedirect()}
            </div>
        );
    }
}

export default Login;