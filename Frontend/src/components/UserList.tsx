import React from 'react'
import MaterialTable from 'material-table'
import Dates from '../Util/Dates';

interface IUserList {
    users: []
}

class UserList extends React.Component<IUserList> {
    constructor(props: IUserList) {
        super(props);
    }

    render() {
        return (
            <MaterialTable
                columns={[
                    { title: 'Firstname', field: 'firstname' },
                    { title: 'Lastname', field: 'lastname', },
                    {
                        title: 'Created at', field: 'createdAt', render: (rowData) => {
                            return (<span>{Dates.FormatDate(rowData.createdAt)}</span>)
                        }
                    }
                ]}
                data={this.props.users}
                title='Users'
                options={{
                    showEmptyDataSourceMessage: true,
                    pageSizeOptions: [10],
                    pageSize: 10,
                }}
            />
        )
    }
}

export default UserList;
