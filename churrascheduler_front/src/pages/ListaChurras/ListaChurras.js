import React, { Component } from 'react';
import './Cadastro.css';
import Input from '../../components/inputtext/Input';
import Botao from '../../components/botao/Botao';

class Cadastro extends Component {
    render() {
        return (
            <div className="Cadastro">
                <Input
                    name="nome"
                    type="text"
                    placeholder="nome"
                    value=""
                    onClick={() => {}}
                    textLabel="Nome"
                />
                <Input
                    name="login"
                    type="text"
                    placeholder="login"
                    value=""
                    onClick={() => { }}
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
                    texto="Cadastrar"
                    onClick={() => { }}
                />
            </div>
        );
    }
}

export default Cadastro;