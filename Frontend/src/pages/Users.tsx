import React from 'react';
import UserList from '../components/UserList'
import Settings from '../settings';
import { GetJson } from '../Util/Requests';

class Users extends React.Component<{}, { users: [] }> {

    constructor(props: object) {
        super(props);
        this.state = {
            users: []
        }
    }

    componentDidMount() {
        GetJson(`${Settings.BackendUrl}Users`)
            .then(users => {
                this.setState({ users: users });
            })
            .catch(error => console.log(error));;
    }

    render() {
        return (
            <UserList users={this.state.users} />
        );
    }
}
export default Users;
