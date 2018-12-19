import React from 'react';
import MaterialTable from 'material-table'

interface IApplicationList {
    applications: []
}

class ApplicationList extends React.Component<IApplicationList> {
    constructor(props: IApplicationList) {
        super(props);
    }

    render() {
        return (
            <MaterialTable
                columns={[
                    { title: 'Name', field: 'name', }
                ]}
                data={this.props.applications}
                title='Applications'
                options={{
                    showEmptyDataSourceMessage: true,
                    pageSizeOptions: [5, 10, 15],
                    pageSize: 10
                }}
            />
        )
    }
}

export default ApplicationList;
