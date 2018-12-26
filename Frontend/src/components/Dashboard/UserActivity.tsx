import React from 'react';
import { DateTimeValueChart } from '../charts/DateTimeValueChart';
import Settings from '../../settings';
import { GetJson } from '../../Util/Requests';

class UserActivity extends React.Component<{}, { data: any[] }> {

    constructor(props: any) {
        super(props);

        this.state = {
            data: []
        }
    }

    componentDidMount() {
        GetJson(`${Settings.BackendUrl}Dashboard/UserActivityFromLastDays`)
            .then(data => this.setState({ data }));
    }

    render() {
        return (
            <DateTimeValueChart lineProps={[{ key: 'value' }]} data={this.state.data} />
        )
    }

}

export default UserActivity;
