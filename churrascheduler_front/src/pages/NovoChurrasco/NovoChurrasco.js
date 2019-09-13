import React, { Component } from 'react';
import './NovoChurrasco.css';
import Input from '../../components/inputtext/Input';
import Botao from '../../components/botao/Botao';

class NovoChurrasco extends Component {
    render() {
        return (
            <div className="NovoChurrasco">
                <Input
                    name="descricao"
                    type="text"
                    placeholder="descrição"
                    value=""
                    onChange={() => {}}
                    textLabel="Descrição"
                />
                <Input
                    name="data"
                    type="date"
                    placeholder="data"
                    value=""
                    onChange={() => { }}
                    textLabel="Data"
                />
                <Input
                    name="bebidaIncluida"
                    type="checkbox"
                    placeholder=""
                    value="incluido"
                    onChange={() => { }}
                    textLabel="Opções"
                    description="Bebida incluída no valor"
                />
                <Input
                    name="observacoes"
                    type="text"
                    placeholder="observações"
                    value=""
                    onChange={() => { }}
                    textLabel="Observações"
                />
                <Botao
                    texto="Criar"
                    onClick={() => { }}
                />
            </div>
        );
    }
}

export default NovoChurrasco;