import React from 'react';
import RoleList from '../components/RoleList';
import Settings from '../settings';
import { Promise } from 'q';
import { GetJson } from '../Util/Requests';

class Roles extends React.Component<{}, { roles: [] }> {

    constructor(props: object) {
        super(props);
        this.state = {
            roles: []
        }
    }

    componentDidMount() {
        GetJson(`${Settings.BackendUrl}Roles`)
            .then(roles => {
                this.setState({ roles: roles });
            })
            .catch(error => console.log(error));
    }

    render() {
        return (
            <RoleList roles={this.state.roles} />
        );
    }
}
export default Roles;
