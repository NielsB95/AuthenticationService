import React from 'react';
import { FormControl, TextField, Button, Paper, withStyles, Grid, Snackbar } from '@material-ui/core';
import { LogIn, CanAuthenticate } from '../security/Security';
import { Redirect } from 'react-router';
import { CSSProperties } from 'jss/css';

interface ILoginPage {
    username: string,
    password: string,
    isLoading: boolean,
    authenticated: boolean,
    invalidCredentials: boolean
}

class Login extends React.Component<{ styles: any }, ILoginPage> {
    constructor(props: any) {
        super(props);

        this.state = {
            username: "",
            password: "",
            isLoading: false,
            authenticated: CanAuthenticate(),
            invalidCredentials: false
        };
    }

    handleLogin = () => {
        let { username, password } = this.state;

        this.setState({ isLoading: true });
        LogIn(username, password)
            .then(() => this.setState({ authenticated: true, isLoading: false }))
            .catch((error: Error) => {
                if (error.message.includes('401'))
                    this.setState({ invalidCredentials: true, isLoading: false })
            });
    }

    handleChange = (event: any) => {
        let changes: any = {};
        changes[event.target.name] = event.target.value;
        this.setState(changes);
    }

    render() {
        const { username, password, invalidCredentials } = this.state;
        const card: any = {
            paddingTop: 20,
            paddingBottom: 20,
            paddingLeft: 30,
            paddingRight: 30,
            width: '100%'
        }

        return (
            this.state.authenticated ?
                <Redirect to={{ pathname: '/' }} />
                :
                <>
                    <Grid
                        container
                        spacing={0}
                        direction="row"
                        justify="center"
                        style={{ minHeight: '60vh' }}
                    >
                        <Grid item lg={4} md={6} xs={12}>
                            <Paper style={card}>
                                <h2>Login</h2>
                                <FormControl fullWidth>
                                    <TextField label="Username" name='username' value={username} onChange={this.handleChange} fullWidth required />
                                    <TextField label="Password" name='password' value={password} onChange={this.handleChange} fullWidth type="password" required />
                                    <Button type="submit" onClick={this.handleLogin}>Login</Button>
                                </FormControl>
                            </Paper>
                        </Grid>
                    </Grid>
                    <Snackbar
                        open={invalidCredentials}
                        onClose={() => this.setState({ invalidCredentials: false })}
                        autoHideDuration={5000}
                        message="Wrong username and/or password" />
                </>
        )
    }
}

export default Login;
