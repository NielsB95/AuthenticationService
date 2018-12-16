import React from 'react';
import RoleList from '../components/RoleList';

class Roles extends React.Component<{}, { roles: [] }> {

    constructor(props: object) {
        super(props);
        this.state = {
            roles: []
        }
    }

    componentDidMount() {
        fetch('http://192.168.2.29:5000/Roles')
            .then(response => response.json())
            .then(roles => {
                this.setState({ roles: roles });
            });
    }


    render() {
        return (
            <RoleList roles={this.state.roles} />
        );
    }
}
export default Roles;
