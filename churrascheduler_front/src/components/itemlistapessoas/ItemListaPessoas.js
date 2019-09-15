import React, { Component } from 'react';
import './ItemListaPessoas.css';
import iconRadio from '../../assets/images/icons/icon_radio.svg';
import iconRadioSelected from '../../assets/images/icons/icon_radio_selected.svg';

class ItemListaPessoas extends Component {
    render() {
        return (
            <div className="item-lista-pessoas" onClick={this.props.onClick}>
                <input hidden="true" value={this.props.idPessoa} />
                <div className="icone"><img src={(this.props.checked) ?iconRadioSelected:iconRadio} /></div>
                <div className="nome">{this.props.nome}</div>
                <div className={"valor " + (this.props.checked ? "pago" : "")}>R$ {this.props.valor}</div>
            </div>
        );
    }
}

export default ItemListaPessoas;