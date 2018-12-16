import React from 'react'
import { Table, TableHead, TableCell, TableRow, TableBody } from '@material-ui/core';

interface IUserList {
    users: []
}

class UserList extends React.Component<IUserList> {
    constructor(props: IUserList) {
        super(props);
    }

    render() {
        return (
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>Firstname</TableCell>
                        <TableCell>Lastname</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {this.props.users.map((user: {
                        id: string,
                        firstname: string,
                        lastname: string
                    }) => {
                        return (
                            <TableRow key={user.id}>
                                <TableCell>{user.firstname}</TableCell>
                                <TableCell>{user.lastname}</TableCell>
                            </TableRow>
                        )
                    })}
                </TableBody>
            </Table>
        )
    }
}

export default UserList;
