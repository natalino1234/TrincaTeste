import React, { Component } from 'react';
import './ItemCriarChurras.css';
import iconPeople from '../../assets/images/icons/icon_bbq.svg';

class ItemCriarChurras extends Component {
    render() {
        return (
            <div className="item-criar-churras item-churras" onClick={this.props.onClick} >
                <div className="elipse">
                    <img src={iconPeople} />
                </div>
                <h3>Adicionar Churras</h3>
            </div>
        );
    }
}

export default ItemCriarChurras;