import React from 'react';
import Dates from '../../Util/Dates';

class ServerStatus extends React.Component<{ status: string, timestamp: Date }> {

    render() {
        return (
            <div>
                <span>
                    This service has a {this.props.status.toLowerCase()} connection.
                </span>
                <br />
                <span>
                    {Dates.FormatDate(this.props.timestamp)}
                    &nbsp;
                    {Dates.FormatTime(this.props.timestamp)}
                </span>
            </div>
        );
    }
}

export default ServerStatus;
