


        /*PATRICIO TOVAR - INSERTED IN _Layout*/
        //NEEDED FOR SPINNER DIALOG
        //$('body').append('<div class="modal" style="display: none"><div class="center"><img alt="" src="/images/ajax-loader.gif" /></div></div>');
        //-------------------------------------------

        //NEEDED FOR SPINNER DIALOG
        $.ajaxSetup({
            global: false,
            dataType: "json",
            beforeSend: function () {
                $("#loadingModal").show();
            },
            complete: function () {
                $("#loadingModal").fadeOut(200) 
            },
            error: function (response, status, error) {
                if (response.status == 901 || response.status == 403) {
                    $.ErrorDialog("Sorry, your session has expired. Please login again to continue", 'Session expired', function () { document.location.href = "/Home/"; });
                }
                else {
                    $.ErrorDialog("Please show this message to the system administrator. <br /><br />" + status + ": " + error, 'System error', null, 'lightcoral');
                }
            }
        });
