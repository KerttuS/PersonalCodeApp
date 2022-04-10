import React from "react";
import { FetchPersonalCodes } from './components/FetchPersonalCodes';
import { PersonalCodeValidator } from "./components/PersonalCodeValidator";


function App() {
    
   
    return (
        <div className="container">
            <div className="row min-vh-100">
                <div className="col d-flex-column justify-content-center align-items-center">
                    <PersonalCodeValidator />
                  
                    <FetchPersonalCodes />
                  
                </div>
            </div>
        </div>
    );

    
}
export default App;

