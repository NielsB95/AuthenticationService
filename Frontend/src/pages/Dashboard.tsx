import React from 'react'
import { Grid } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import NumberOfUsers from '../components/Dashboard/NumberOfUsers';
import { blue } from '@material-ui/core/colors';
import UserActivity from '../components/Dashboard/UserActivity';

const styles = (theme: any) => ({
    root: {
        flexGrow: 1,
    },
    paper: {
        height: 240,
    },
    paperHeader: {
        margin: 0,
        marginBottom: 10,
        padding: 5,
    },
    control: {
        padding: theme.spacing.unit * 2,
    },
});

class Dashboard extends React.Component<{ classes: any }> {
    render() {
        const { classes } = this.props;

        return (
            <Grid container spacing={16} justify="flex-start">
                <Grid item xs={12} md={6}>
                    <Paper className={classes.paperHeader}>
                        <h3 style={{ margin: 0 }}>Total number of users</h3>
                    </Paper>
                    <Paper className={classes.paper}>
                        <NumberOfUsers />
                    </Paper>
                </Grid>

                <Grid item xs={12} md={6}>
                    <Paper className={classes.paperHeader}>
                        <h3 style={{ margin: 0 }}>Activity</h3>
                    </Paper>
                    <Paper className={classes.paper}>
                        <UserActivity />
                    </Paper>
                </Grid>
            </Grid >
        );
    }
}

export default withStyles(styles)(Dashboard);
