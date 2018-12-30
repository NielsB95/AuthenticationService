import React from 'react'
import MaterialTable from 'material-table'

interface IRoleList {
    roles: []
}

class RoleList extends React.Component<IRoleList> {
    constructor(props: IRoleList) {
        super(props);
    }

    render() {
        return (
            <MaterialTable
                columns={[
                    { title: 'Name', field: 'name', }
                ]}
                data={this.props.roles}
                title='Roles'
                options={{
                    showEmptyDataSourceMessage: true,
                    pageSizeOptions: [10],
                    pageSize: 10,
                }}
            />
        )
    }
}

export default RoleList;
