


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
                //$(".modal").delay(2000).hide();
                $("#loadingModal").fadeOut(200) //BETTER DESING
            },
            error: function (x, status, error) {
                if (x.status == 901) {
                    alert("Sorry, your session has expired. Please login again to continue");
                    document.location.href = "/Home/";
                }
                else {
                    alert("An error occurred: " + status + "nError: " + error);
                }
            }
        });
