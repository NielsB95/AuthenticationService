import React from 'react'
import { Route, Switch } from 'react-router-dom'
import Users from './Users';
import Roles from './Roles';
import NotFound from './NotFound'
import General from './General';

class Content extends React.Component {

    render() {
        return (
            <div>
                <div>
                    <Switch>
                        <Route exact path="/" component={Users} />
                        <Route path="/users" component={Users} />
                        <Route path="/roles" component={Roles} />
                        <Route path="/general" component={General} />
                        <Route component={NotFound} />
                    </Switch>
                </div>
            </div>
        );
    }
}
export default Content;
