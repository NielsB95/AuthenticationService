import React from 'react'
import { Route, Switch } from 'react-router-dom'
import Users from './Users';
import Roles from './Roles';
import NotFound from './NotFound'
import Dashboard from './Dashboard';
import Applications from './Applications';
import Login from './Login';
import PrivateRoute from '../components/Authentication/PrivateRoute';
import AuthenticationLogs from './AuthenticationLogs';

class Content extends React.Component {

    render() {
        return (
            <div>
                <div>
                    <Switch>
                        <Route exact path="/" component={Dashboard} />
                        <Route path="/login" component={Login} />
                        <Route path="/dashboard" component={Dashboard} />
                        <PrivateRoute path="/users" component={Users} />
                        <PrivateRoute path="/roles" component={Roles} />
                        <PrivateRoute path="/applications" component={Applications} />
                        <PrivateRoute path="/logs" component={AuthenticationLogs} />
                        <Route component={NotFound} />
                    </Switch>
                </div>
            </div>
        );
    }
}
export default Content;
