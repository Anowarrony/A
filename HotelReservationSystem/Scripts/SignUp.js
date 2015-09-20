    $(document).ready(function () {
        var url = "";
        $("#dialog-edit").dialog({
            title: 'Create User',
            autoOpen: false,
            resizable: false,
            width: 470,
            position:[400,150],
            show: { effect: 'drop', direction: "up" },
            modal: true,
            draggable: false,
            open: function (event, ui) {
               $(".ui-dialog-titlebar-close").hide();
                $(this).load(url);
            }
      
        });

        $("#lnkCreate").live("click", function (e) {

            url = $(this).attr('href');
            $("#dialog-edit").dialog('open');
 
            return false;
        });
        $("#btnCancel").live("click", function (e) {
            $("#dialog-edit").dialog("close");
            return false;
        });
    });
