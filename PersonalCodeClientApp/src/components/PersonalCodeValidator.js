import React, { Component } from 'react';
import { FetchPersonalCodes } from './FetchPersonalCodes';
import { useState } from "react";



export class PersonalCodeValidator extends Component {
    static displayName;
    constructor(props) {
        super(props);

        this.state = { value: '' };
        this.state = { isValid: false };
        this.state = { errorMsg: '' };


        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        const re = /^[0-9\b]+$/;

        if (event.target.value === '' || re.test(event.target.value)) {
            this.setState({ value: event.target.value });

        }


    }
    handleSubmit(props) {


        if (this.state.value.length === 11) {
            alert('isikukood: ' + this.state.value);
            this.setState({ isValid: true });
        }
        else {

            alert('Isikukoodi pikkus peab olema 11 numbrit');

            this.setState({ isValid: true });
            this.setState({ errorMsg: 'Isikukoodi pikkus peab olema 11 numbrit' });
            console.log(this.state.value.length);
            console.log(this.state.errorMsg);
        }

    }

    render() {
        return (
            <>
                <form onSubmit={this.handleSubmit}>
                    <div>
                        <h1>Isikukood</h1>
                        <p><input type="text" ref="" value={this.state.value} onChange={this.handleChange}></input></p>
                        <button className="bn btn-primary" onClick={this.handleSubmit}>Kontrolli</button>
                    </div>
                </form>
                <br></br>

               


            </>
        );

    }

}