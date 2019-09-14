import React, { Component } from 'react';
import './ListaChurras.css';
import ItemChurras from '../../components/itemchurras/ItemChurras';
import ItemCriarChurras from '../../components/itemcriarchurras/ItemCriarChurras';
import { ListChurras } from '../../functions/RestClient';
import { alert } from '../../assets/js/Notifications';

class ListaChurras extends Component {

    constructor(props) {
        super(props);

        this.state = {
            listaChurras: []
        }

        this.carregarLista = this.carregarLista.bind(this);
        this.exibirLista = this.exibirLista.bind(this);

        this.carregarLista();
    }

    carregarLista() {

        let authToken = window.localStorage.getItem("authToken");

        let callback = (result) => {
            console.log(result);
            if (result[0]) {
                this.setState({ listaChurras: result[1] });
            } else {
                alert.error("Houve um problema ao carregar a lista de churrascos, tente novamente.");
            }
        };

        ListChurras(authToken, callback);
    }

    exibirLista() {
        console.log(this.state.listaChurras);
        return this.state.listaChurras.map((value) => {
            let data = new Date(value.dataChurras);

            let dia = data.getDate();
            if (dia < 10) {
                dia = "0" + dia;
            }

            let mes = data.getMonth() + 1;
            if (mes < 10) {
                mes = "0" + mes;
            }

            return <ItemChurras
                dataChurras={dia + "/" + mes}
                motivo={value.Nome}
                quantidadePessoas={value.qtdParticipantes}
                valorTotal={value.valorTotal}
            />
        });
    }

    render() {

        return (
            <div className="ListaChurras">
                {this.exibirLista()}
                <ItemCriarChurras to="/Novo" />
            </div>
        );
    }
}

export default ListaChurras;