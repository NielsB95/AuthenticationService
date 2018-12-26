import React from 'react';
import AuthenticationLogList, { IAuthenticationLogList } from '../components/AuthenticationLogList';
import { GetJson } from '../Util/Requests';
import Settings from '../settings';

class AuthenticationLogs extends React.Component<{}, IAuthenticationLogList> {

    constructor(props: object) {
        super(props);
        this.state = {
            logs: []
        }
    }

    componentWillMount() {
        GetJson(`${Settings.BackendUrl}AuthenticationLogs`)
            .then(logs => this.setState({ logs }));
    }

    render() {
        return <AuthenticationLogList logs={this.state.logs} />;
    }
}

export default AuthenticationLogs;
