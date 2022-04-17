

const ValidateList = ({ list }) => {
    
    return (
        <ul>
        
            {list.map(item => (
                <li key={item.code}>
                    <p>{item.code}</p>
                    <p>{item.errorMessage}</p>
                </li>
            ))}
        </ul>
    )
}
export default ValidateList

