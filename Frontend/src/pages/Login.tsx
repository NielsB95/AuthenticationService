import React from 'react';
import { FormControl, TextField, Button } from '@material-ui/core';
import { LogIn, CanAuthenticate } from '../security/Security';
import { Redirect } from 'react-router';

class Login extends React.Component<{}, { username: string, password: string, isLoading: boolean, authenticated: boolean }> {
    constructor(props: any) {
        super(props);

        this.state = {
            username: "",
            password: "",
            isLoading: false,
            authenticated: CanAuthenticate()
        };
    }

    handleLogin = () => {
        let { username, password } = this.state;

        this.setState({ isLoading: true });
        LogIn(username, password)
            .then(() => this.setState({ authenticated: true, isLoading: false }))
            .catch(error => console.log(error));
    }

    handleChange = (event: any) => {
        let changes: any = {};
        changes[event.target.name] = event.target.value;
        this.setState(changes);
    }

    render() {
        const { username, password } = this.state;
        return (
            this.state.authenticated ?
                <Redirect to={{ pathname: '/' }} />
                :
                <FormControl >
                    <TextField label="Username" name='username' value={username} onChange={this.handleChange} required />
                    <TextField label="Password" name='password' value={password} onChange={this.handleChange} type="password" required />
                    <Button type="submit" onClick={this.handleLogin}>Login</Button>
                </FormControl>
        )
    }
}

export default Login;
