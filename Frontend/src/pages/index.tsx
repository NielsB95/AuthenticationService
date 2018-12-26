import React from 'react'
import { BrowserRouter as Router } from 'react-router-dom'
import MiniDrawer from '../components/MiniDrawer';
import Content from './Content'
import { createMuiTheme, withTheme, MuiThemeProvider } from '@material-ui/core/styles';
import blue from '@material-ui/core/colors/red';

const theme = createMuiTheme({
    typography: {
        useNextVariants: true,
    },
    palette: {
        primary: blue
    },
});

class Index extends React.Component {
    render() {
        return (
            <MuiThemeProvider theme={theme} >
                <Router>
                    <MiniDrawer>
                        <Content />
                    </MiniDrawer>
                </Router>
            </MuiThemeProvider>
        )
    }
}

export default withTheme()(Index);
