class Dates {
    static FormatDate(date: any) {
        let monthNames = [
            "January", "February", "March",
            "April", "May", "June", "July",
            "August", "September", "October",
            "November", "December"
        ];

        date = new Date(date);
        let day = date.getDate();
        let monthIndex = date.getMonth();
        let year = date.getFullYear();

        day = day < 9 ? '0' + day : day;

        return day + ' ' + monthNames[monthIndex] + ' ' + year;
    }

    static FormatTime(date: Date) {
        let hour = date.getHours();
        let hours = hour < 9 ? '0' + hour : hour;

        let minute = date.getMinutes();
        let minutes = minute < 0 ? '0' + minute : minute;

        return `${hours}:${minutes}`;
    }
}

export default Dates
