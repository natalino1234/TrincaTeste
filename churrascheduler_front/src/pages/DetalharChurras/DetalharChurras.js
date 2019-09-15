import React, { Component } from 'react';
import './DetalharChurras.css';
import { Link } from 'react-router-dom';
import iconPeople from '../../assets/images/icons/icon_people.svg';
import iconMoney from '../../assets/images/icons/icon_money.svg';
import ListaPessoas from '../../components/listapessoas/ListaPessoas';
import ItemListaPessoas from '../../components/itemlistapessoas/ItemListaPessoas';
import { DetailChurras, AddParticipante, RemParticipante, EditParticipante } from '../../functions/RestClient';
import queryString from 'query-string';
import Input from '../../components/inputtext/Input';
import Botao from '../../components/botao/Botao';
import { alert } from '../../assets/js/Notifications';

class DetalharChurras extends Component {

    constructor(props) {
        super(props);

        this.state = {
            churras: { id: "", Nome: "", dataChurras: "", qtdParticipantes: 0, valorTotal: 0, valorIndividual: 0 },
            participantes: [],
            idParticipante: -1,
            nome: "",
            pagou: false,
            showModal: false,
            edit: false
        }

        this.parseData = this.parseData.bind(this);
        this.carregarListaParticipantes = this.carregarListaParticipantes.bind(this);
        this.abrirCadastro = this.abrirCadastro.bind(this);
        this.carregarDados = this.carregarDados.bind(this);
        this.cadastrarParticipante = this.cadastrarParticipante.bind(this);
        this.cancelarCadastro = this.cancelarCadastro.bind(this);
        this.editarParticipante = this.editarParticipante.bind(this);
        this.removerParticipante = this.removerParticipante.bind(this);

        this.carregarDados();
    }

    carregarDados() {
        let authToken = window.localStorage.getItem("authToken");
        const parsed = queryString.parse(window.location.search);

        let callback = (result) => {
            if (result) {
                console.log("AQUIII");
                console.log(result);
                if (result[0]) {
                    this.setState({
                        churras: result[1],
                        participantes: result[2]
                    });
                } else {
                    alert.error(result[1]);
                }
            }
        }

        DetailChurras(authToken, parsed.id, callback);
    }

    parseData() {
        let data = new Date(this.state.churras.dataChurras);

        let dia = data.getDate();
        if (dia < 10) {
            dia = "0" + dia;
        }

        let mes = data.getMonth() + 1;
        if (mes < 10) {
            mes = "0" + mes;
        }

        return dia + "/" + mes;
    }

    carregarListaParticipantes() {
        console.log(this.state.churras);
        return this.state.participantes.map((value, key) => {
            return <ItemListaPessoas idPessoa={key} onClick={this.editarParticipante} key={key} nome={value.nome_participante} valor={this.state.churras.valor_individual.toFixed(2)} checked={value.pago === 1} />
        });
    }

    abrirCadastro() {
        this.setState({ showModal: true, edit: false });
    }

    cadastrarParticipante() {
        let authToken = window.localStorage.getItem("authToken");
        const parsed = queryString.parse(window.location.search);

       

        if (this.state.edit) {
            let callback = (result) => {
                console.log(result);
                if (result) {
                    if (result[0]) {
                        alert.success("O participante foi editado com sucesso.");
                        this.setState({
                            participantes: result[1]
                        });
                    } else {
                        alert.error(result[1]);
                    }
                }
            }
            EditParticipante(authToken, this.state.idParticipante, parsed.id, this.state.nome, this.state.pagou, callback);
        } else {
            let callback = (result) => {
                console.log(result);
                if (result) {
                    if (result[0]) {
                        alert.success("O participante foi adicionado com sucesso.");
                        this.setState({
                            participantes: result[1]
                        });
                    } else {
                        alert.error(result[1]);
                    }
                }
            }
            AddParticipante(authToken, parsed.id, this.state.nome, this.state.pagou, callback);

        }
        this.setState({ showModal: false, nome: "", pagou: false, edit: false });
    }

    cancelarCadastro() {
        this.setState({ showModal: false, edit: false, nome:"", pagou: false });
    }

    editarParticipante(evt) {
        let posParticipante = evt.target.parentElement.children[0].value;
        let p = this.state.participantes[posParticipante];
        this.setState({ idParticipante: p.id, nome: p.nome_participante, pagou: p.pago === 1, showModal: true, edit: true });
    }

    renderRemover() {
        if (this.state.edit) {
            return <Botao
                texto="Remover"
                onClick={this.removerParticipante}
                className="vermelho"
            />
        }
    }

    removerParticipante() {
        let authToken = window.localStorage.getItem("authToken");
        const parsed = queryString.parse(window.location.search);

        let callback = (result) => {
            if (result) {
                if (result[0]) {
                    alert.success("O participante foi removido com sucesso.");
                    this.setState({
                        participantes: result[1]
                    });
                } else {
                    alert.error(result[1]);
                }
            }
        }

        RemParticipante(authToken, parsed.id, this.state.idParticipante, callback);

        this.setState({ showModal: false, nome: "", pagou: false, edit: false });
    }

    render() {
        return (
            <div className="DetalharChurras">
                <h2>{this.parseData()}</h2>
                <h3>{this.state.churras.Nome}</h3>
                <div className="people">
                    <img src={iconPeople} />
                    <span>{this.state.churras.qtdParticipantes}</span>
                </div>
                <div className="money">
                    <img src={iconMoney} />
                    <span>R$ {this.state.churras.valorTotal.toFixed(2)}</span>
                </div>
                <ListaPessoas>
                    {this.carregarListaParticipantes()}
                </ListaPessoas>
                <i onClick={this.abrirCadastro} className="fas fa-user-plus func add" />
                <div className={"modal " + ((this.state.showModal)?"show":"")}>
                    <div className="contentModal">
                        <h5>{this.state.edit?"Edição":"Cadastro"} de Participante</h5>
                        <Input
                            name="nome"
                            type="text"
                            placeholder="nome"
                            value={this.state.nome}
                            onChange={(evt) => { this.setState({ nome: evt.target.value }) }}
                            textLabel="Participante"
                        />
                        <Input
                            name="pago"
                            type="checkbox"
                            placeholder=""
                            value={this.state.pagou}
                            onChange={(evt) => { this.setState({ pagou: evt.target.checked }) }}
                            textLabel="Participante Pagou?"
                            description="Sim"
                        />

                        <Botao
                            className="verde"
                            texto={this.state.edit?"Salvar":"Cadastrar"}
                            onClick={this.cadastrarParticipante}
                        />

                        <Botao
                            className={this.state.edit ? "azul":"vermelho"}
                            texto="Cancelar"
                            onClick={this.cancelarCadastro}
                        />

                        {this.renderRemover()}
                    </div>
                </div>
            </div>
        );
    }
}

export default DetalharChurras;