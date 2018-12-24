import React from 'react';
import RoleList from '../components/RoleList';
import Settings from '../settings';
import { Promise } from 'q';

class Roles extends React.Component<{}, { roles: [] }> {

    constructor(props: object) {
        super(props);
        this.state = {
            roles: []
        }
    }

    componentDidMount() {
        fetch(`${Settings.BackendUrl}Roles`)
            .then(response => response.json())
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
