import PropTypes from 'prop-types'


const Header = ({ title }) => {
  

    return (
        <header className='header'>

            <h1>{title}</h1>
            {/*<Button color='blue' text='Kontrolli' />*/}
            

        </header>

    )
}

Header.defaultProps = {
    title: 'EE APP',
}
Header.propTypes = {
    title: PropTypes.string.isRequired,
}

export default Header