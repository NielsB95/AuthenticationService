import React from 'react';
import Settings from '../settings';
import ApplicationList from '../components/ApplicationList';

class Applications extends React.Component<{}, { applications: [] }> {


    constructor(props: object) {
        super(props);
        this.state = {
            applications: []
        }
    }

    componentDidMount() {
        fetch(`${Settings.BackendUrl}Applications`)
            .then(response => response.json())
            .then(applications => {
                this.setState({ applications });
            });
    }

    render() {
        return (
            <ApplicationList applications={this.state.applications} />
        );
    }

}

export default Applications
