import React from 'react'
import { DateTimeValueChart } from '../charts/DateTimeValueChart';
import Settings from '../../settings';
import { GetJson } from '../../Util/Requests';

class NumberOfUsers extends React.Component<{}, { data: [] }> {
    constructor(props: object) {
        super(props);
        this.state = {
            data: []
        }
    }

    componentDidMount() {
        GetJson(`${Settings.BackendUrl}Dashboard/UsersFromLastDays`)
            .then(data => this.setState({ data }));
    }

    render() {
        return (
            <DateTimeValueChart lineProps={[{ key: 'value' }]} data={this.state.data} />
        )
    }
}

export default NumberOfUsers
