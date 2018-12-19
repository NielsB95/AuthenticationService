import React from 'react'
import { BrowserRouter as Router } from 'react-router-dom'
import MiniDrawer from '../components/MiniDrawer';
import Content from './Content'

class Index extends React.Component {
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
