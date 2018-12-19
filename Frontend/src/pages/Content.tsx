import React from 'react'
import { Route, Switch } from 'react-router-dom'
import Users from './Users';
import Roles from './Roles';
import NotFound from './NotFound'
import Dashboard from './Dashboard';
import Applications from './Applications';

class Content extends React.Component {

    render() {
        return (
            <div>
                <div>
                    <Switch>
                        <Route exact path="/" component={Dashboard} />
                        <Route path="/users" component={Users} />
                        <Route path="/roles" component={Roles} />
                        <Route path="/dashboard" component={Dashboard} />
                        <Route path="/applications" component={Applications} />
                        <Route component={NotFound} />
                    </Switch>
                </div>
            </div>
        );
    }
}
export default Content;
