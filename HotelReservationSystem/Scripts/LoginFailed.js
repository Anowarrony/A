$(document).ready(function () {
    $("#logmess").dialog({
        modal: true, width: 430, draggable: false, resizable: false, title: 'Login Failed Pannel', buttons: {
            "OK": function () {
                $(this).dialog("close");
            }
        }
    });
});
