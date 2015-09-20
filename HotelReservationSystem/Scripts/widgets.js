$(document).ready(function () {

    // Create a jqxDateTimeInput
    $("#Indate").jqxDateTimeInput({ width: '250px', height: '25px' });
    $("#Outdate").jqxDateTimeInput({ width: '250px', height: '25px' });

});
$("#resRoomReq").dialog({
    title: 'Error',
    modal: true, width: '300', buttons: {
        "Close": function () {
            $(this).dialog("close");
        }
    }
});