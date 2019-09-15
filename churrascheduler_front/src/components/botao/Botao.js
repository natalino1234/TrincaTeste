import React, { Component } from 'react';
import './Botao.css';

class Botao extends Component {
    render() {
        return (
            <div className={"botao " + this.props.className} onClick={this.props.onClick} >
                <span>{this.props.texto}</span>
            </div>
        );
    }
}

export default Botao;