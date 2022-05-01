import { useState, useEffect } from 'react'
import ValidationList from './components/ValidationList'
import UserInput from './components/UserInput'


const App = () => {
    const [list, setList] = useState([])
    const [message, setMessage] = useState('')

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
        console.log("See on serverist Get info", data)
        return data
      
    }

    //Validate personal code 
    const checkCode = async (code) => {

        const res = await fetch('https://localhost:7090/api/personalcode', {
            method: "POST", //post
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(code),
        });
        const data = await res.text()
        setMessage(data)
        
    }


    return (
        
        <div className="container">
            <UserInput onAdd={checkCode} message={message} />
            <ValidationList list={list} />
        </div>
          
       )
}

export default App
