import React from 'react'
import MaterialTable from 'material-table'

interface IUserList {
    users: []
}

function formatDate(date: any) {
    var monthNames = [
        "January", "February", "March",
        "April", "May", "June", "July",
        "August", "September", "October",
        "November", "December"
    ];

    date = new Date(date);
    var day = date.getDate();
    var monthIndex = date.getMonth();
    var year = date.getFullYear();

    day = day < 9 ? '0' + day : day;

    return day + ' ' + monthNames[monthIndex] + ' ' + year;
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
                            return (<span>{formatDate(rowData.createdAt)}</span>)
                        }
                    }
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
