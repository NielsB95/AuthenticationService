import React from 'react';
import Settings from '../settings';
import ApplicationList from '../components/ApplicationList';
import { GetJson } from '../Util/Requests';

class Applications extends React.Component<{}, { applications: [] }> {


    constructor(props: object) {
        super(props);
        this.state = {
            applications: []
        }
    }

    componentDidMount() {
        GetJson(`${Settings.BackendUrl}Applications`)
            .then(applications => {
                this.setState({ applications });
            })
            .catch(error => console.log(error));;
    }

    render() {
        return (
            <ApplicationList applications={this.state.applications} />
        );
    }

}

export default Applications
