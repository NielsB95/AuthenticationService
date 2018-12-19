import React from 'react';
import DashboardLine from '../charts/DashboardLine';
import Settings from '../../settings';

class UserActivity extends React.Component<{}, { data: any[] }> {

    constructor(props: any) {
        super(props);

        this.state = {
            data: []
        }
    }

    componentDidMount() {
        fetch(`${Settings.BackendUrl}Dashboard/UserActivityFromLastDays`)
            .then(response => response.json())
            .then(data => this.setState({ data }));
    }

    render() {
        return (
            <DashboardLine data={this.state.data} />
        )
    }

}

export default UserActivity;
