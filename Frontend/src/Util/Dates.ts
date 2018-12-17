class Dates {
    static FormatDate(date: any) {
        var monthNames = [
            "January", "February", "March",
            "April", "May", "June", "July",
            "August", "September", "October",
            "November", "December"
        ];

        date = new Date(date);
        var day = date.getDate();
        var monthIndex = date.getMonth();
        var year = date.getFullYear();

        day = day < 9 ? '0' + day : day;

        return day + ' ' + monthNames[monthIndex] + ' ' + year;
    }
}

export default Dates
