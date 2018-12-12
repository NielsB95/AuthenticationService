import React from 'react';
import PropTypes from 'prop-types';

class Header extends React.Component {
    render() {
        return (
            <div>
                <span>{this.props.headerText}</span>
            </div>
        );
    }
}


Header.propTypes = {
    headerText: PropTypes.string.isRequired
}

export default Header;