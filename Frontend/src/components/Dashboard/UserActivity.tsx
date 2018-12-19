import React from 'react';
import DateTimeValueChart from '../charts/DateTimeValueChart';
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
            <DateTimeValueChart data={this.state.data} />
        )
    }

}

export default UserActivity;
