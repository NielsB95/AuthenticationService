import React from 'react';
import { LineChart, Line, XAxis, YAxis, Tooltip, ResponsiveContainer } from 'recharts';
import Dates from '../../Util/Dates';
import { withTheme, Theme, CircularProgress } from '@material-ui/core';
import LoadingIcon from '../LoadingIcon';

interface IThemable {
    theme: Theme
}

export interface ILineProperties {
    key: string,
    color?: string
}

interface IDateTimeValueChart extends IThemable {
    data: any[],
    lineProps: ILineProperties[],
    loading?: boolean
}

class DateTimeValueChart extends React.Component<IDateTimeValueChart> {
    iteration: number = 0;

    render() {
        const textStyling = {
            fontFamily: 'Helvetica'
        };

        // Get the primary colour.
        var primary = this.props.theme.palette.primary.main;

        // Format the date
        this.props.data.map(x => x.date = Dates.FormatDate(x.date));
        this.iteration++;

        let lines: any[] = [];
        this.props.lineProps.map(lineProp => {
            let color = lineProp.color || primary;
            lines.push(<Line type="monotone" dataKey={lineProp.key} key={lineProp.key} stroke={color} />)
        });

        return this.props.loading ?
            (
                <LoadingIcon />
            )
            :
            (
                <ResponsiveContainer>
                    <LineChart key={this.iteration} data={this.props.data} margin={{ top: 15, right: 60, bottom: 5, left: 0 }}>
                        {lines}
                        <XAxis dataKey="date" />
                        <YAxis />
                        <Tooltip labelStyle={textStyling} itemStyle={textStyling} />
                    </LineChart>
                </ResponsiveContainer>
            );
    }
}

let exportableDateTimeValueChart = withTheme()(DateTimeValueChart);
export { exportableDateTimeValueChart as DateTimeValueChart };
