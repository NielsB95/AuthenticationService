import React from 'react';
import { DateTimeValueChart, ILineProperties } from '../charts/DateTimeValueChart';
import { GetJson } from '../../Util/Requests';
import Settings from '../../settings';
import { Promise } from 'bluebird';

class SuccessFailRatio extends React.Component<{}, { data: object[], loading: boolean }> {

    constructor(props: object) {
        super(props);
        this.state = {
            data: [],
            loading: false
        }
    }

    componentWillMount() {
        this.setState({ loading: true });
        let succesful = GetJson(`${Settings.BackendUrl}Dashboard/SuccesfulAuthenticationActivityLastDays`)
            .then(data => {
                data.forEach((d: any) => {
                    d.succesful = d.value;
                    delete d.value
                });
                this.setState({ data: this.handleData(data) })
            });

        let failed = GetJson(`${Settings.BackendUrl}Dashboard/FailedAuthenticationActivityLastDays`)
            .then(data => {
                data.forEach((d: any) => {
                    d.failed = d.value;
                    delete d.value
                });
                this.setState({ data: this.handleData(data) })
            });

        // Wait for both requests to be finished.
        Promise.all([succesful, failed])
            .then(() => this.setState({ loading: false }));
    }

    handleData(newData: object[]): object[] {
        let tempData: object[] = this.state.data || [];
        for (let i = 0; i < newData.length; i++)
            tempData[i] = ({ ...tempData[i], ...newData[i] });

        return tempData;
    }

    render() {
        let keyValues: ILineProperties[] = [{
            key: 'succesful',
        }, {
            key: 'failed',
            color: '#FF0000'
        }];

        return <DateTimeValueChart lineProps={keyValues} loading={this.state.loading} data={this.state.data} />
    }
}
export default SuccessFailRatio;
