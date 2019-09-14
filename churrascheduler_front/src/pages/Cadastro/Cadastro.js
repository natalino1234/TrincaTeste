import React, { Component } from 'react';
import './Cadastro.css';
import { Link } from 'react-router-dom';
import Input from '../../components/inputtext/Input';
import Botao from '../../components/botao/Botao';
import { alert } from '../../assets/js/Notifications';
import { SignUp } from '../../functions/RestClient';

class Cadastro extends Component {

    constructor(props) {
        super(props);

        this.state = {
            nome: "",
            login: "",
            senha: ""
        }

        this.cadastrarClick = this.cadastrarClick.bind(this);
    }

    cadastrarClick() {
        if (this.state.nome === "") {
            alert.error("O campo NOME não pode ficar vazio.");
            return;
        } else if (this.state.login === "") {
            alert.error("O campo LOGIN não pode ficar vazio.");
            return;
        } else if (this.state.senha === "") {
            alert.error("O campo SENHA não pode ficar vazio.");
            return;
        }

        let callback = (result) => {
            console.log(result);
            if (result === null) {
                alert.error("Houve algum erro no processamento, tente novamente.");
            } else {
                if (result[0]) {
                    window.localStorage.setItem("authToken", result[1]);
                    window.location.href = "/";
                } else {
                    alert.error(result[1]);
                }
            }
        };

        SignUp(this.state.nome, this.state.login, this.state.senha, callback);
    }

    render() {
        return (
            <div className="Cadastro">
                <Input
                    name="nome"
                    type="text"
                    placeholder="nome"
                    value={this.state.nome}
                    onChange={(evt) => { this.setState({ nome: evt.target.value}); }}
                    textLabel="Nome"
                />
                <Input
                    name="login"
                    type="text"
                    placeholder="login"
                    value={this.state.login}
                    onChange={(evt) => { this.setState({ login: evt.target.login }); }}
                    textLabel="Login"
                />
                <Input
                    name="senha"
                    type="password"
                    placeholder="senha"
                    value={this.state.senha}
                    onChange={(evt) => { this.setState({ senha: evt.target.value }); }}
                    textLabel="Senha"
                />
                <Botao
                    texto="Cadastrar"
                    onClick={this.cadastrarClick}
                />
                <Link className="botao" to="/">
                    <span>Login</span>
                </Link>
            </div>
        );
    }
}

export default Cadastro;