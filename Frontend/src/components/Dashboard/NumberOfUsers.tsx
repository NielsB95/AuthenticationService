import React from 'react'
import DateTimeValueChart from '../charts/DateTimeValueChart';
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
            <DateTimeValueChart data={this.state.data} />
        )
    }
}

export default NumberOfUsers
