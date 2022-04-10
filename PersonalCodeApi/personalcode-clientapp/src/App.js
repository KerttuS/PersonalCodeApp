import React from "react";
import { useState } from "react";



function App() {
    
    const [posts, setPosts] = useState([]);


    function getPosts() {
        const url = 'https://localhost:7090/get-all-posts';
        fetch(url, {
            method: 'GET'
        })
            .then(response => response.json())
        .then(postsFromServer => {
            console.log(postsFromServer);
            setPosts(postsFromServer);
        })
        .catch((error) => {
            console.log(error);
            alert(error);
        });
    }

    return (
        <div className="container">
            <div className="row min-vh-100">
                <div className="col d-flex-column justify-content-center align-items-center">
                    <h1>Hello</h1>
                    <button onClick={getPosts} className="brn btn-dark btn-lg w-100">GetPosts from server</button>
                    {renderPostTable()}
                  
                </div>
            </div>
        </div>
    );

    function renderPostTable() {
        return (
            <div className="table-responsive mt-5">
                <table className="table table-bordered border-dar">
                    <thead>
                        <tr>
                            <th scope="col">PostId (PK)</th>
                            
                            <th scope="col">Sõnum</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th scope="row">1</th>
                            <td>Post1 title</td>
                            <td></td>
                            <td>
                                <button className="btn btn-dark btn-lg mx-3 my-3">Button #1</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
          );
    }
}
export default App;

