const ValidateList = ({list}) => {

    return (
    <>
        {list.map((list) => (
        <h3 key={list.id}>{list.code}</h3>

        ))}
     </>
    )
}

export default ValidateList

