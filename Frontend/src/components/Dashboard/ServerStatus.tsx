import React from 'react';
import Dates from '../../Util/Dates';

class ServerStatus extends React.Component<{ status: string, timestamp: Date }> {

    render() {
        return (
            <div>
                <p>
                    This service has a {this.props.status.toLowerCase()} connection.
                </p>
                <p>
                    {Dates.FormatDate(this.props.timestamp)}
                    &nbsp;
                    {Dates.FormatTime(this.props.timestamp)}
                </p>
            </div>
        );
    }
}

export default ServerStatus;
