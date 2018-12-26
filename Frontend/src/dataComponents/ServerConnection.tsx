import React from 'react';
import Settings from '../settings';
import ServerStatus from '../components/Dashboard/ServerStatus';
import Dates from '../Util/Dates';

class ServerConnection extends React.Component<{}, { status: string, timestamp: Date }> {

    intervalID: any;
    statusInterval: number = 25000;

    constructor(props: any) {
        super(props);

        // define a default status.
        this.state = {
            status: "",
            timestamp: new Date()
        };

        this.healthCheck();
    }

    /**
     * Start polling for the server status.
     */
    componentDidMount() {
        this.intervalID = setInterval(() => {
            this.healthCheck();
        }, this.statusInterval);
    }

    /**
     * Stop with polling when the user leaves the page.
     */
    componentWillUnmount() {
        clearInterval(this.intervalID);
    }

    render() {
        let timestamp = this.state.timestamp;
        let time = Dates.FormatTime(timestamp);
        let seconds = timestamp.getSeconds();

        // Prepend a 0 to make it 2 digit time.
        time = `${time}:${seconds > 9 ? seconds : '0' + seconds}`;

        return (
            <div style={{ width: '100%', height: '100%', textAlign: 'center' }} >
                <ServerStatus status={this.state.status} timestamp={this.state.timestamp} />
                <br />
                <span style={{ height: '20%' }}>{time}</span>
            </div>
        );
    }

    healthCheck() {
        fetch(`${Settings.BackendUrl}Health`)
            .then(response => response.text())
            .then(status => this.setState({
                status,
                timestamp: new Date()
            }))
            .catch(() => this.setState({ status: 'Unhealthy' }));
    }
}

export default ServerConnection;
