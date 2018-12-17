import React from 'react';
import { LineChart, Line, XAxis, YAxis, Tooltip, ResponsiveContainer } from 'recharts';
import Dates from '../../Util/Dates';

interface IDashboardLine {
    data: any[]
}

class DashboardLine extends React.Component<IDashboardLine> {
    render() {
        const textStyling = {
            fontFamily: 'Helvetica'
        };

        // Format the date
        this.props.data.map(x => x.date = Dates.FormatDate(x.date));

        return (
            <ResponsiveContainer>
                <LineChart data={this.props.data} margin={{ top: 5, right: 40, bottom: 5, left: 0 }}>
                    <Line type="natural" dataKey="value" stroke="#8884d8" />
                    <XAxis dataKey="date" />
                    <YAxis />
                    <Tooltip labelStyle={textStyling} itemStyle={textStyling} />
                </LineChart>
            </ResponsiveContainer>
        )
    }
}



export default DashboardLine
