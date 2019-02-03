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
                    { title: 'Name', field: 'name' },
                    { title: 'Application code', field: 'applicationCode' }
                ]}
                data={this.props.applications}
                title='Applications'
                options={{
                    showEmptyDataSourceMessage: true,
                    pageSizeOptions: [10],
                    pageSize: 10,
                }}
            />
        )
    }
}

export default ApplicationList;
