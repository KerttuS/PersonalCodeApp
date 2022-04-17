import { useState } from 'react'

const UserInput = ({ onAdd }) => {
    const [code, setCode] = useState('')
   
    const handleSubmit = (e) => {
        console.log(code)
        e.preventDefault()
        if (!code) {
            alert("Midagi juhtus")
            return
        }
        onAdd({ code })
        setCode('')
    }
    
    return (
        <>
            <form className='add-form' onSubmit={handleSubmit} >
            <div className='form-control' >
                <label>Isikukood</label>
                <input
                    type='text'
                    placeholder='Sisesta isikukood'
                    value={code}
                    pattern='[0-9]*'
                    maxLength='11'
                    onChange={(e) => {
                        setCode((v) => (e.target.validity.valid ? e.target.value : v))
                    }} />
           
                </div>
                <button disabled={code.length < 11} type='submit' className='btn btn-block' value='Kontrolli'>Kontrolli</button>
        </form>

            <div>
                <span className='span' text='Vaata valideerimisi'>Isikukoodi kontrolli tulemused</span>
            </div>
            </>
        )
}

export default UserInput