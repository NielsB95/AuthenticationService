import React from 'react';
import Dates from '../../Util/Dates';
import CheckIcon from '@material-ui/icons/CheckCircleOutline';
import ErrorIcon from '@material-ui/icons/HighlightOff';
import { Icon } from '@material-ui/core';

class ServerStatus extends React.Component<{ status: string, timestamp: Date }> {
    render() {
        const styles: React.CSSProperties = {
            height: '80%',
            width: '45%',
            display: 'inline-block'
        };

        switch (this.props.status.toLowerCase()) {
            case "healthy":
                return <CheckIcon style={styles} />
            case "unhealthy":
                return <ErrorIcon style={styles} color='error' />
            default:
                // An empty div with the right dimensions.
                return <div style={styles}></div>
        }
    }
}

export default ServerStatus;
