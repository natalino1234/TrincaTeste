import React, { Component } from 'react';
import './ListaPessoas.css';
import iconPeople from '../../assets/images/icons/icon_people.svg';
import iconMoney from '../../assets/images/icons/icon_money.svg';

class ListaPessoas extends Component {
    render() {
        return (
            <div className="lista-pessoas" >
                {this.props.children}
            </div>
        );
    }
}

export default ListaPessoas;