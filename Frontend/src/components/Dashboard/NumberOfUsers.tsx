import React from 'react'
import { DateTimeValueChart } from '../charts/DateTimeValueChart';
import Settings from '../../settings';
import { GetJson } from '../../Util/Requests';

class NumberOfUsers extends React.Component<{}, { data: [], loading: boolean }> {
    constructor(props: object) {
        super(props);
        this.state = {
            data: [],
            loading: false
        }
    }

    componentDidMount() {
        this.setState({ loading: true });
        GetJson(`${Settings.BackendUrl}Dashboard/UsersFromLastDays`)
            .then(data => this.setState({ data }))
            .then(() => this.setState({ loading: false }));
    }

    render() {
        return (
            <DateTimeValueChart lineProps={[{ key: 'value' }]} loading={this.state.loading} data={this.state.data} />
        )
    }
}

export default NumberOfUsers
