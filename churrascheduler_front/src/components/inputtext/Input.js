import React, { Component } from 'react';
import './Input.css';

class Input extends Component {
    render() {
        return (
            <div className="input" onClick={this.props.onClick} >
                <label htmlFor={this.props.name}>{this.props.textLabel}</label>
                <input
                    id={this.props.name}
                    name={this.props.name}
                    type={this.props.type}
                    value={this.props.value}
                    onChange={this.props.onChange}
                    placeholder={this.props.placeholder}
                />
            </div>
        );
    }
}

export default Input;