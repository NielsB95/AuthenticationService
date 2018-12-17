import React from 'react';
import { LineChart, Line, XAxis, YAxis, Tooltip, ResponsiveContainer } from 'recharts';

class DashboardLine extends React.Component {
    render() {
        const data = [
            { name: 'Monday', value: 4000 },
            { name: 'Tuesday', value: 3000 },
            { name: 'Wednesday', value: 2000 },
            { name: 'Thursday', value: 2780 },
            { name: 'Friday', value: 1890 },
            { name: 'Saterday', value: 2390 },
            { name: 'Sunday', value: 3490 },
        ];

        const textStyling = {
            fontFamily: 'Helvetica'
        };

        return (
            <ResponsiveContainer>
                <LineChart data={data} margin={{ top: 5, right: 40, bottom: 5, left: 0 }}>
                    <Line type="natural" dataKey="value" stroke="#8884d8" />
                    <XAxis dataKey="name" />
                    <YAxis />
                    <Tooltip labelStyle={textStyling} itemStyle={textStyling} />
                </LineChart>
            </ResponsiveContainer>
        )
    }
}



export default DashboardLine
