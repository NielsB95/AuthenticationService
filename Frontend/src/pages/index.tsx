import React from 'react'
import UserList from '../components/UserList';
import { Route, Link, BrowserRouter as Router, Switch } from 'react-router-dom'
import Users from './Users';
import Roles from './Roles';
import NotFound from './NotFound'

class Index extends React.Component<{}, { users: [] }> {
    render() {
        return (
            <div>


                <Router>
                    <div>
                        <Link to='/users'>Users</Link>
                        <Link to='roles'>Roles</Link>
                        <Switch>
                            {/* <Route exact path="/" component={App} /> */}
                            <Route path="/users" component={Users} />
                            <Route path="/roles" component={Roles} />
                            <Route component={NotFound} />
                            {/* <Route component={Notfound} /> */}
                        </Switch>
                    </div>
                </Router>
            </div>
        )
    }
}

export default Index;
