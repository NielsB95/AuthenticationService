
import React, { Component } from 'react';
import { Redirect, Route } from 'react-router';
import { CanAuthenticate } from '../../security/Security';

class PrivateRoute extends React.Component<{ path?: string, component?: any }> {
    render() {
        return CanAuthenticate() ?
            <Route path={this.props.path} component={this.props.component} />
            :
            <Redirect to={{ pathname: '/Login' }} />
    }
}
export default PrivateRoute;
