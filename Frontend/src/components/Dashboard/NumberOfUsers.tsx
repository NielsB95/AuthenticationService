import React from 'react'
import DashboardLine from '../charts/DashboardLine';
import Settings from '../../settings';

class NumberOfUsers extends React.Component<{}, { data: [] }> {
    constructor(props: object) {
        super(props);
        this.state = {
            data: []
        }
    }

    componentDidMount() {
        fetch(`${Settings.BackendUrl}Dashboard/UsersFromLastDays`)
            .then(response => response.json())
            .then(data => this.setState({ data }));
    }

    render() {
        return (
            <DashboardLine data={this.state.data} />
        )
    }
}

export default NumberOfUsers
