import { useState, useEffect } from 'react'
import ValidationList from './components/ValidationList'
import UserInput from './components/UserInput'



const App = () => {
    const [list, setList] = useState([])
    const [code, setCode] = useState(null)
    const [enabled, setEnabled] = useState(false)

    useEffect(() => {
        const getCodes = async () => {
            const codesFromServer = await fetchCodes()
            setList(codesFromServer)
        }
        getCodes()

    }, [])


     //fetch data from Server
    const fetchCodes = async () => {
        const res = await fetch('https://localhost:7090/api/personalcode')
        const data = await res.json()
        console.log("See on serverist info", data)
        return data
    }

    //Validate personal code 
    const checkCode = async (code) => {
        console.log("Kood checkCode seest", code)
        const res = await fetch('https://localhost:7090/api/personalcode', {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(code),
        })

        const data = await res.json()
       
        setCode(code, data)
        console.log("data on meil", data)
    }

    return (
       
        <div className="container">
          
            <UserInput onAdd={checkCode} />
            <ValidationList list={list} />
        </div>
          
       )
}

export default App
