import React from 'react';
import Settings from '../settings';
import ServerStatus from '../components/Dashboard/ServerStatus';

class ServerConnection extends React.Component<{}, { status: string, timestamp: Date }> {

    intervalID: any;
    statusInterval: number = 2000;

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
        return (
            <div>
                <ServerStatus status={this.state.status} timestamp={this.state.timestamp} />
            </div>
        );
    }

    healthCheck() {
        fetch(`${Settings.BackendUrl}Health`)
            .then(response => response.text())
            .then(status => this.setState({
                status,
                timestamp: new Date()
            }));
    }
}

export default ServerConnection;
