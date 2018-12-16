import React from 'react'
import { AppBar, Button, Table, TableRow, TableCell, TableBody, TableHead, Drawer } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import UserList from '../components/userList';


class Index extends React.Component<{}, { users: [] }> {
    constructor(props: object) {
        super(props);
        this.state = {
            users: []
        }
    }

    componentDidMount() {
        fetch('http://localhost:59246/Users')
            .then(response => response.json())
            .then(users => {
                console.log(users);
                this.setState({ users: users });
            });
    }

    render() {
        return (
            <div>
                <UserList users={this.state.users} />
            </div>
        )
    }
}

export default Index;
