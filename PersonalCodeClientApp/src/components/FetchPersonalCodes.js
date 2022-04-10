import React, { Component } from 'react';
import ReactDOM from "react-dom";


export class FetchPersonalCodes extends Component {
    static displayName = FetchPersonalCodes.name;

    constructor(props) {
        super(props);
        this.state = { codes: [], loading: true };
    }

    componentDidMount() {
        this.populatePersonalCodes();
    }

    static renderTable(codes) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Isikukood</th>
                        <th>Veateade</th>
                        
                    </tr>
                </thead>
                <tbody>
                    {codes.map(code =>
                        <tr key={codes.code}>
                            <td>{codes.code}</td>
                            <td>{codes.errormessage}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchPersonalCodes.renderTable(this.state.codes);

        return (
            <div>
                <h1 id="tabelLabel" >Tulemused</h1>
                <p>Isikukoodi kontrolli list.</p>
                {contents}
            </div>
        );
    }

    async populatePersonalCodes() {
        const response = await fetch('https://localhost:7090/api/personalcode');
        const data = await response.json();
        this.setState({ codes: data, loading: false });
    }
}