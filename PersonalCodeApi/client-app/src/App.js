import { useState, useEffect } from 'react'
import Header from './components/Header'
import ValidationList from './components/ValidationList'
import UserInput from './components/UserInput'


const App = () => {
    const [list, setList] = useState([])

    useEffect(() => {
        const getCodes = async () => {
            const codesFromServer = await fetchCodes()
            setList(codesFromServer)
        }
        getCodes()

    }, [])


    // fetch data
    const fetchCodes = async () => {
        const res = await fetch('https://localhost:7090/api/personalcode')
        const data = await res.json()

        return data
    }

    //CheckCode function
    const checkCode = async (list) => {
        const res = await fetch('https://localhost:7090/api/personalcode', {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(list),
        })

        const data = await res.json()

        setList([...list, data])

        }
    return (
       
        <div className="container">
            <Header />
            <UserInput onAdd={checkCode} />
            <ValidationList list={list} />
        </div>
          
       
    )
 }

    



export default App;
