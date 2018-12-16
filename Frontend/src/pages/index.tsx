import React from 'react'
import UserList from '../components/userList';
import { Button } from '@material-ui/core';


class Index extends React.Component<{}, { users: [] }> {
    constructor(props: object) {
        super(props);
        this.state = {
            users: []
        }
    }

    componentDidMount() {
        fetch('http://localhost:5000/Users')
            .then(response => response.json())
            .then(users => {
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
