import React from 'react';
import UserList from '../components/UserList'
import Settings from '../settings';

class Users extends React.Component<{}, { users: [] }> {

    constructor(props: object) {
        super(props);
        this.state = {
            users: []
        }
    }

    componentDidMount() {
        fetch(`${Settings.BackendUrl}Users`)
            .then(response => response.json())
            .then(users => {
                this.setState({ users: users });
            });
    }

    render() {
        return (
            <UserList users={this.state.users} />
        );
    }
}
export default Users;
