import React from 'react';
import PropTypes from 'prop-types';
import Button from '../UIElements/Button.tsx';


class Block extends React.Component {
    render() {
        return (
            <div style={{
                width: this.props.width + "%",
                backgroundColor: this.props.bgColor,
                padding: '25px'
            }} >
            </ div >
        );
    }
}

Block.proptTypes = {
    width: PropTypes.number.isRequired
}

export default Block;