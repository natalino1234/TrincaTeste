import React, { Component } from 'react';
import './ItemCriarChurras.css';
import iconPeople from '../../assets/images/icons/icon_bbq.svg';
import { Link } from 'react-router-dom';

class ItemCriarChurras extends Component {
    render() {
        return (
            <Link className="item-criar-churras item-churras" to={this.props.to} >
                <div className="elipse">
                    <img src={iconPeople} />
                </div>
                <h3>Adicionar Churras</h3>
            </Link>
        );
    }
}

export default ItemCriarChurras;