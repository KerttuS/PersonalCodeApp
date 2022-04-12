import { useState } from 'react'

const UserInput = ({onAdd}) => {
    const [code, setCode] = useState('')
    const [errorMsg, setErrorMsg] = useState('')

    const onSubmit = (e) => {
        e.preventDefault()

        if (!code) {
            alert('Palun sisesta kood')
            return
        }
     
        onAdd({ code })
        setCode('')
    }
    //Ära sisesta muud kui täisarvu
    const onChange = (e) => {
        e.preventDefault()
        const re = /^[0-9\b]+$/;

        if (e.target.value === '' || re.test(e.target.value)) {
            setCode({ code: e.target.value });

        }
    }
    return (
        <form className='add-form' onSubmit={onSubmit}>
            <div className='form-control'>
                <label>Isikukood</label>
                <input type='text' placeholder='Sisesta isikukood' value={code} onChange={onChange} />
            </div>
            <input type='submit' value='Kontrolli' className='btn btn-block' />
        </form>
        )
}

export default UserInput