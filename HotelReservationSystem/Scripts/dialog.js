

    $(document).ready(function () {
        $(".hi").hide();
        var url = "";

        if ('@TempData["msg"]' != "") {
            $("#dialog-alert").dialog('open');
        }



        $("#dialog-confirm").dialog({
            autoOpen: false,
            title: ' Delete Pannel',
            resizable: false,
            height: 250,
            width: 350,
            position: [370, 120],
            show: { effect: 'drop', direction: "up" },
            modal: true,
            draggable: true,
            open: function (event, ui) {
                $(".ui-dialog-titlebar-close").hide();

            },
            buttons: {
                "OK": function () {
                    $(this).dialog("close");
                    window.location.href = url;
                },
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });





        $(".lnkDelete").live("click", function (e) {
            // e.preventDefault(); use this or return false

            url = $(this).attr('href');
            $("#dialog-confirm").dialog('open');

            return false;
        });



        $("#btnClose").live("click", function (e) {
            $("#dialog-edit").dialog("close");
            return false;
        });
    });