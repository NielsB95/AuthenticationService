import React from 'react'
import MaterialTable from 'material-table'
import { GetJson } from '../Util/Requests';
import Settings from '../settings';
import Dates from '../Util/Dates';

export interface IAuthenticationLogList {
    logs: []
}

class AuthenticationLogList extends React.Component<IAuthenticationLogList> {
    constructor(props: IAuthenticationLogList) {
        super(props);
    }

    render() {
        return (
            <MaterialTable
                columns={[
                    { title: 'Name', render: (row) => (row.user || {}).fullname },
                    { title: 'Successful', field: 'successful', type: 'boolean' },
                    {
                        title: 'Created at', field: 'createdAt', render: (rowData) => {
                            return (<span>{Dates.FormatDate(rowData.createdAt)} {Dates.FormatTime(new Date(rowData.createdAt))}</span>)
                        }
                    },
                    { title: 'Application', render: (row) => (row.application || {}).name }
                ]}
                data={this.props.logs}
                title='Logs'
                options={{
                    showEmptyDataSourceMessage: true,
                    pageSizeOptions: [10],
                    pageSize: 10,
                }}
            />
        )
    }
}

export default AuthenticationLogList;
