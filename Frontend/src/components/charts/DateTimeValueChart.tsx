import React from 'react';
import { LineChart, Line, XAxis, YAxis, Tooltip, ResponsiveContainer } from 'recharts';
import Dates from '../../Util/Dates';
import { withTheme, Theme } from '@material-ui/core';

interface IThemable {
    theme: Theme
}

interface IDateTimeValueChart extends IThemable {
    data: any[]
}

class DateTimeValueChart extends React.Component<IDateTimeValueChart> {
    iteration: number = 0;

    render() {
        const textStyling = {
            fontFamily: 'Helvetica'
        };

        var primary = this.props.theme.palette.primary.light;

        // Format the date
        this.props.data.map(x => x.date = Dates.FormatDate(x.date));
        this.iteration++;
        return (
            <ResponsiveContainer>
                <LineChart key={this.iteration} data={this.props.data} margin={{ top: 15, right: 60, bottom: 5, left: 0 }}>
                    <Line type="monotone" dataKey="value" stroke={primary} />
                    <XAxis dataKey="date" />
                    <YAxis />
                    <Tooltip labelStyle={textStyling} itemStyle={textStyling} />
                </LineChart>
            </ResponsiveContainer>
        )
    }
}

export default withTheme()(DateTimeValueChart);
