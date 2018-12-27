import React from 'react';
import { CircularProgress } from '@material-ui/core';


class LoadingIcon extends React.Component {

    render() {
        return (
            <div style={{ display: 'flex', justifyContent: 'center', paddingTop: '50px' }}>
                <CircularProgress />
            </div>
        );
    }
}

export default LoadingIcon;
