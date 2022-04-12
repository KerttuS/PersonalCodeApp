const FormErrors = (code) => {

    handleUserInput(code) {
        const code = e.target.code;
        const value = e.target.value;
        this.setState({ [name]: value },
            () => { this.validateField(name, value) });
    }

export default FormErrors