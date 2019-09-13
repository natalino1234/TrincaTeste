import React, { Component } from 'react';
import './DetalharChurras.css';
import Input from '../../components/inputtext/Input';
import Botao from '../../components/botao/Botao';
import iconPeople from '../../assets/images/icons/icon_people.svg';
import iconMoney from '../../assets/images/icons/icon_money.svg';
import iconRadio from '../../assets/images/icons/icon_radio.svg';
import iconRadioSelected from '../../assets/images/icons/icon_radio_selected.svg';
import ListaPessoas from '../../components/listapessoas/ListaPessoas';
import ItemListaPessoas from '../../components/itemlistapessoas/ItemListaPessoas';

class DetalharChurras extends Component {
    render() {
        return (
            <div className="DetalharChurras">
                <h2>12/01</h2>
                <h3>Niver do Gui</h3>
                <div className="people">
                    <img src={iconPeople} />
                    <span>1234</span>
                </div>
                <div className="money">
                    <img src={iconMoney} />
                    <span>R$ 280</span>
                </div>
                <ListaPessoas>
                    <ItemListaPessoas nome="Alícia" valor="20" checked={true} />
                </ListaPessoas>
            </div>
        );
    }
}

export default DetalharChurras;