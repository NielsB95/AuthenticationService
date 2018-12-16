import React from 'react'
import { Grid } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';

const styles = (theme: any) => ({
    root: {
        flexGrow: 1,
    },
    paper: {
        height: 140,
    },
    control: {
        padding: theme.spacing.unit * 2,
    },
});

class General extends React.Component<{ classes: any }> {
    render() {
        const { classes } = this.props;

        return (
            <Grid container spacing={16} xs={12} justify="flex-start">
                <Grid item xs={12} md={6}>
                    <Paper className={classes.paper}>
                    </Paper>
                </Grid>
                <Grid item xs={12} md={3}>
                    <Paper className={classes.paper}>
                    </Paper>
                </Grid>
                <Grid item xs={12} md={3}>
                    <Paper className={classes.paper}>
                    </Paper>
                </Grid>
            </Grid >
        );
    }
}

export default withStyles(styles)(General);
