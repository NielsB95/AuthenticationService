import React from 'react'
import MaterialTable from 'material-table'

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
                ]}
                data={this.props.users}
                title='Users'
                options={{
                    showEmptyDataSourceMessage: true,
                    pageSizeOptions: [5, 10, 15],
                    pageSize: 10
                }}
            />
        )
    }
}

export default UserList;
