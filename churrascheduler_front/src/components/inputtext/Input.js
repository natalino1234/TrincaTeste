import React, { Component } from 'react';
import './Input.css';

class Input extends Component {
    render() {
        return (
            <div className={"input" + ((this.props.type === "checkbox" || this.props.type === "radio")?" selectable":"") }>
                <label htmlFor={this.props.name}>{this.props.textLabel}</label>
                <input
                    id={this.props.name}
                    name={this.props.name}
                    type={this.props.type}
                    value={this.props.value}
                    onChange={this.props.onChange}
                    placeholder={this.props.placeholder}
                    required={(this.props.required)?"required":""}
                />
                <span>{(this.props.type === "checkbox" || this.props.type === "radio") ? this.props.description : ""}</span>
            </div>
        );
    }
}

export default Input;