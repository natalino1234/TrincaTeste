import React, { Component } from 'react';
import './ListaChurras.css';
import ItemChurras from '../../components/itemchurras/ItemChurras';
import ItemCriarChurras from '../../components/itemcriarchurras/ItemCriarChurras';

class ListaChurras extends Component {
    render() {
        return (
            <div className="ListaChurras">
                <ItemChurras
                    dataChurras="01/12"
                    motivo={"Niver do Gui"}
                    quantidadePessoas="1234"
                    valorTotal="280" />
                <ItemChurras
                    dataChurras="01/12"
                    motivo={"Niver do Gui"}
                    quantidadePessoas="1234"
                    valorTotal="280" />
                <ItemChurras
                    dataChurras="01/12"
                    motivo={"Niver do Gui"}
                    quantidadePessoas="1234"
                    valorTotal="280" />
                <ItemChurras
                    dataChurras="01/12"
                    motivo={"Niver do Gui"}
                    quantidadePessoas="1234"
                    valorTotal="280" />
                <ItemChurras
                    dataChurras="01/12"
                    motivo={"Niver do Gui"}
                    quantidadePessoas="1234"
                    valorTotal="280" />
                <ItemChurras
                    dataChurras="01/12"
                    motivo={"Niver do Gui"}
                    quantidadePessoas="1234"
                    valorTotal="280" />
                <ItemChurras
                    dataChurras="01/12"
                    motivo={"Niver do Gui"}
                    quantidadePessoas="1234"
                    valorTotal="280" />
                <ItemCriarChurras onClick={() => { }} />
            </div>
        );
    }
}

export default ListaChurras;