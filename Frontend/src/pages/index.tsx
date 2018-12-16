import React from 'react'
import { Route, Link, BrowserRouter as Router, Switch } from 'react-router-dom'
import MiniDrawer from '../components/MiniDrawer';
import Content from './Content'

class Index extends React.Component<{}, { users: [] }> {
    render() {
        return (
            <Router>
                <MiniDrawer>
                    <Content />
                </MiniDrawer>
            </Router>
        )
    }
}

export default Index;
