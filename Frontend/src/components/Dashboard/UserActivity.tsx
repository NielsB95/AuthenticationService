import React from 'react';
import DashboardLine from '../charts/DashboardLine';

class UserActivity extends React.Component<{}, { data: any[] }> {

    constructor(props: any) {
        super(props);

        this.state = {
            data: [{ "date": "2018-12-03T00:00:00+01:00", "value": 15.0 }, { "date": "2018-12-04T00:00:00+01:00", "value": 2.0 }, { "date": "2018-12-05T00:00:00+01:00", "value": 25.0 }, { "date": "2018-12-06T00:00:00+01:00", "value": 28.0 }, { "date": "2018-12-07T00:00:00+01:00", "value": 35.0 }, { "date": "2018-12-08T00:00:00+01:00", "value": 5.0 }, { "date": "2018-12-09T00:00:00+01:00", "value": 16.0 }, { "date": "2018-12-10T00:00:00+01:00", "value": 10.0 }, { "date": "2018-12-11T00:00:00+01:00", "value": 4.0 }, { "date": "2018-12-12T00:00:00+01:00", "value": 8.0 }, { "date": "2018-12-13T00:00:00+01:00", "value": 8.0 }, { "date": "2018-12-14T00:00:00+01:00", "value": 8.0 }, { "date": "2018-12-15T00:00:00+01:00", "value": 8.0 }, { "date": "2018-12-16T00:00:00+01:00", "value": 8.0 }]
        }
    }

    render() {
        return (
            <DashboardLine data={this.state.data} />
        )
    }

}

export default UserActivity;
