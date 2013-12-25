$(document).ready(function () {

    $("#CheckInDate").datepicker({
        defaultDate: 0,
        showOn: "both",
        changeMonth: true,
        numberOfMonths: 2,
        buttonImage: "/Images/Resources/calendar.gif",
        buttonImageOnly: true,
        minDate: new Date(),
        onClose: function (selectedDate) {
            $("#CheckOutDate").datepicker("option", "minDate", selectedDate);
        }
    });
    $("#CheckOutDate").datepicker({
        defaultDate: +1,
        showOn: "both",
        changeMonth: true,
        buttonImage: "/Images/Resources/calendar.gif",
        buttonImageOnly: true,
        numberOfMonths: 2
    });

    
});

