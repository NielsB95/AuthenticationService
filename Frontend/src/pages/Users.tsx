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
        // let token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiI1YTkyZjBmNi1iM2Y2LTQ1ZWQtOTk2Ny0xYTY1MzBhNDhkNzYiLCJOYW1lIjoiTmllbHMgQm9lcmthbXAiLCJVc2VySVAiOiI6OjEiLCJSb2xlSUQiOiI5ZWNhYjc5OC04NjhiLTRiYzUtYWQ4Yi0wMDM2NTdlMmExZTIiLCJuYmYiOjE1NDU2NTU1MDEsImV4cCI6MTU0NTY1NjcwMSwiaWF0IjoxNTQ1NjU1NTAxLCJpc3MiOiJBdXRoZW50aWNhdGlvbi5TZXJ2aWNlIn0.BfWPofqMvzfIQhTzZ4MwCSJXMrqQ-lQYfHfWtRBVh2U";

        let token = JSON.parse(localStorage.getItem('token') || "");


        fetch(`${Settings.BackendUrl}Users`, {
            headers: {
                'Authorization': `bearer ${token}`
            }
        })
            .then(response => response.json())
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
