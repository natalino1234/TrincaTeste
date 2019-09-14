import React, { Component } from 'react';
import './NovoChurrasco.css';
import { Redirect } from 'react-router-dom';
import Input from '../../components/inputtext/Input';
import Botao from '../../components/botao/Botao';
import { alert } from '../../assets/js/Notifications';
import { SalvarChurrasco } from '../../functions/RestClient';

class NovoChurrasco extends Component {

    constructor(props) {
        super(props);

        let data = new Date();

        let dia = data.getDate();
        if (dia < 10) {
            dia = "0" + dia;
        }

        let mes = data.getMonth() + 1;
        if (mes < 10) {
            mes = "0" + mes;
        }

        let dt = data.getFullYear() + "-" + mes + "-" + dia;

        this.state = {
            id: 0,
            descricao: "Sem Motivo",
            data: dt,
            bebidaIncluida: false,
            observacoes: "",
            valorPessoa: 0.0,
            redirect: false
        }

        this.novoChurrasco = this.novoChurrasco.bind(this);
        this.renderRedirect = this.renderRedirect.bind(this);
    }

    novoChurrasco() {
        
        let authToken = window.localStorage.getItem("authToken");

        if (this.state.descricao === "") {
            alert.error("O campo DESCRIÇÃO não pode ficar vazio.");
            return;
        } else if (this.state.data === "") {
            alert.error("Informe a DATA que irá ocorrer o churras.");
            return;
        } else if (this.state.valor < 0) {
            alert.error("Informe a DATA que irá ocorrer o churras.");
            return;
        }

        let callback = (result) => {
            if (result) {
                console.log(result);
                if (result[0]) {
                    this.setState({
                        id: result[1].id,
                        redirect: true
                    });
                } else {
                    alert.error(result[1]);
                }
            }
        };

        SalvarChurrasco(authToken, this.state.descricao, this.state.data, this.state.bebidaIncluida, this.state.observacoes, this.state.valorPessoa, callback);
    }

    renderRedirect() {
        if (this.state.redirect) {
            return <Redirect to={"/Detalhar?"+this.state.id} />;
        }
        return "";
    }

    render() {
        return (
            <div className="NovoChurrasco">
                <Input
                    name="descricao"
                    type="text"
                    placeholder="descrição"
                    value={this.state.descricao}
                    onChange={(evt) => { this.setState({descricao: evt.target.value}) }}
                    textLabel="Descrição"
                />
                <Input
                    name="data"
                    type="date"
                    placeholder="data"
                    value={this.state.data}
                    onChange={(evt) => { this.setState({ data: evt.target.value }) }}
                    textLabel="Data"
                />
                <Input
                    name="bebidaIncluida"
                    type="checkbox"
                    placeholder=""
                    value={this.state.bebidaIncluida}
                    onChange={(evt) => { this.setState({ bebidaIncluida: evt.target.checked }) }}
                    textLabel="Opções"
                    description="Bebida incluída no valor"
                />
                <Input
                    name="observacoes"
                    type="text"
                    placeholder="observações"
                    value={this.state.observacoes}
                    onChange={(evt) => { this.setState({ observacoes: evt.target.value }) }}
                    textLabel="Observações"
                />
                <Input
                    name="valor"
                    type="number"
                    placeholder="valor/pessoa"
                    value={this.state.valorPessoa}
                    onChange={(evt) => { this.setState({ valorPessoa: parseFloat(evt.target.value).toFixed(2) }) }}
                    textLabel="Valor Individual (R$)"
                    min="0"
                    step=".50"
                />
                <Botao
                    texto="Criar"
                    onClick={this.novoChurrasco}
                />
                {this.renderRedirect()}
            </div>
        );
    }
}

export default NovoChurrasco;