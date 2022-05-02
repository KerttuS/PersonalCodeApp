

const ValidateList = ({ list }) => {
    
    return (
        <ul>
        
            {list.map(item => (
                <li key={item.code}>
                    <p>{item.code}</p>
                    <p>{item.message}</p>
                </li>
            ))}
        </ul>
    )
}
export default ValidateList

