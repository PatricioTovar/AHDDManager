

$.ConfirmDialog = function (message, title, callbackYes, callbackNo, callbackArgument, TitleBarColor) {
    /// <summary>
    ///     Generic confirmation dialog.
    ///
    ///     Usage:
    ///         $.ConfirmDialog('Do you want to continue?', 'Continue Title', function() { alert('yes'); }, function() { alert('no'); }, null);
    ///         $.ConfirmDialog('Do you want to continue?', 'Continue Title', function(arg) { alert('yes, ' + arg); }, function(arg) { alert('no, ' + arg); }, 'please');
    ///</summary>
    ///<param name="message" type="String">
    ///     The string message to display in the dialog.
    ///</param>
    ///<param name="title" type="String">
    ///     The string title to display in the top bar of the dialog.
    ///</param>
    ///<param name="callbackYes" type="Function">
    ///     The callback function when response is yes.
    ///</param>
    ///<param name="callbackNo" type="Function">
    ///     The callback function when response is no.
    ///</param>
    ///<param name="callbackNo" type="Object">
    ///     Optional parameter that is passed to either callback function.
    ///</param>

    if ($("#modalConfirmDialog").length == 0)
        $('body').append('<div id="modalConfirmDialog"></div>');

    var dlg = $("#modalConfirmDialog")
        .html(message)
        .dialog({
            autoOpen: false, // set this to false so we can manually open it
            dialogClass: "confirmScreenWindow no-close",
            closeOnEscape: false,
            draggable: false,
            width: 600,
            minHeight: 50,
            modal: true,
            resizable: false,
            title: title,
            //open: function (event, ui) {

            //    var s = new Option().style;
            //    s.color = TitleBarColor;
            //    if (s.color != TitleBarColor) {
            //        TitleBarColor = 'beige';
            //    }

            //    $(".ui-dialog").find(".ui-widget-header").css("background", TitleBarColor);
            //},
            buttons: {
                Yes: function () {
                    if (callbackYes && typeof (callbackYes) === "function") {
                        if (callbackArgument == null) {
                            callbackYes();
                        } else {
                            callbackYes(callbackArgument);
                        }
                    }


                    $(this).dialog("close");
                },

                No: function () {

                    if (callbackNo && typeof (callbackNo) === "function") {
                        if (callbackArgument == null) {
                            callbackNo();
                        } else {
                            callbackNo(callbackArgument);
                        }
                    }


                    $(this).dialog("close");
                }
            }
        });


    if (TitleBarColor) {
        dlg.prev(".ui-dialog-titlebar").css("background", TitleBarColor);
    }
    dlg.dialog("open");
};

$.AlertDialog = function (message, title, callbackYes, TitleBarColor) {
    /// <summary>
    ///     Generic confirmation dialog.
    ///
    ///     Usage:
    ///         $.ConfirmDialog('Do you want to continue?', 'Continue Title', function() { alert('yes'); }, function() { alert('no'); }, null);
    ///         $.ConfirmDialog('Do you want to continue?', 'Continue Title', function(arg) { alert('yes, ' + arg); }, function(arg) { alert('no, ' + arg); }, 'please');
    ///</summary>
    ///<param name="message" type="String">
    ///     The string message to display in the dialog.
    ///</param>
    ///<param name="title" type="String">
    ///     The string title to display in the top bar of the dialog.
    ///</param>
    ///<param name="callbackYes" type="Function">
    ///     The callback function when response is yes.
    ///</param>
    ///<param name="callbackNo" type="Function">
    ///     The callback function when response is no.
    ///</param>
    ///<param name="callbackNo" type="Object">
    ///     Optional parameter that is passed to either callback function.
    ///</param>

    if ($("#modalAlertDialog").length == 0)
        $('body').append('<div id="modalAlertDialog"></div>');

    var dlg = $("#modalAlertDialog")
        .html(message)
        .dialog({
            autoOpen: false, // set this to false so we can manually open it
            dialogClass: "confirmScreenWindow",
            closeOnEscape: true,
            draggable: false,
            width: 600,
            minHeight: 50,
            modal: true,
            resizable: false,
            title: title,
            //open: function (event, ui) {
            //    var s = new Option().style;
            //    s.color = TitleBarColor;
            //    if (s.color != TitleBarColor) {
            //        TitleBarColor = 'beige';
            //    }

            //    $(".ui-dialog").find(".ui-widget-header").css("background", TitleBarColor);
            //},
            buttons: {
                Close: function () {
                    if (callbackYes && typeof (callbackYes) === "function") {
                        callbackYes();
                    }

                    $(this).dialog("close");
                }
            },
            close: function () {
                if (callbackYes && typeof (callbackYes) === "function") {
                    callbackYes();
                }

                $(this).dialog("close");
            }
        });
    if (TitleBarColor) {
        dlg.prev(".ui-dialog-titlebar").css("background", TitleBarColor);
    }

    dlg.dialog("open");
};

$.ErrorDialog = function (message, title, callback) {
    if ($("#modalErrorDialog").length == 0)
        $('body').append('<div id="modalErrorDialog"></div>');

    var dlg = $("#modalErrorDialog")
        .html(message)
        .dialog({
            autoOpen: false, // set this to false so we can manually open it
            dialogClass: "confirmScreenWindow no-close",
            closeOnEscape: false,
            draggable: false,
            width: 600,
            minHeight: 50,
            modal: true,
            resizable: false,
            title: title,
            buttons: {
                OK: function () {
                    if (callback && typeof (callback) === "function") {
                        callback();
                    }

                    $(this).dialog("close");
                }
            },
            close: function () {
                if (callback && typeof (callback) === "function") {
                    callback();
                }

                $(this).dialog("close");
            }
        });
        dlg.prev(".ui-dialog-titlebar").css("background", "tomato");

    dlg.dialog("open");
};



$.PromptDialog = function (message, title, callbackYes, callbackNo, callbackArgument, TitleBarColor) {
    /// <summary>
    ///     Generic confirmation dialog.
    ///
    ///     Usage:
    ///         $.ConfirmDialog('Do you want to continue?', 'Continue Title', function() { alert('yes'); }, function() { alert('no'); }, null);
    ///         $.ConfirmDialog('Do you want to continue?', 'Continue Title', function(arg) { alert('yes, ' + arg); }, function(arg) { alert('no, ' + arg); }, 'please');
    ///</summary>
    ///<param name="message" type="String">
    ///     The string message to display in the dialog.
    ///</param>
    ///<param name="title" type="String">
    ///     The string title to display in the top bar of the dialog.
    ///</param>
    ///<param name="callbackYes" type="Function">
    ///     The callback function when response is yes.
    ///</param>
    ///<param name="callbackNo" type="Function">
    ///     The callback function when response is no.
    ///</param>
    ///<param name="callbackNo" type="Object">
    ///     Optional parameter that is passed to either callback function.
    ///</param>

    if ($("#promptConfirmDialog").length == 0)
        $('body').append('<div id="promptConfirmDialog"></div>');

    var dlg = $("#promptConfirmDialog")
        .html(message + ' <input type="text" id="txtTitle" class="form-control"  style="max-width:500px;"> <P></P>Description: <br /><textarea id="txtDescription" class="form-control" style="max-width:500px; height:100px;"></textarea>')
        .dialog({
            autoOpen: false, // set this to false so we can manually open it
            dialogClass: "confirmScreenWindow",
            closeOnEscape: true,
            draggable: false,
            width: 600,
            minHeight: 50,
            modal: true,
            resizable: false,
            title: title,
            //open: function (event, ui) {

            //    var s = new Option().style;
            //    s.color = TitleBarColor;
            //    if (s.color != TitleBarColor) {
            //        TitleBarColor = 'beige';
            //    }

            //    $(".ui-dialog").find(".ui-widget-header").css("background", TitleBarColor);
            //},
            buttons: {
                OK: function () {
                    if (callbackYes && typeof (callbackYes) === "function") {
                        if (callbackArgument == null) {
                            appt = {                                
                                title: $('#txtTitle').val(),
                                description: $('#txtDescription').val()
                            }

                            callbackYes(appt);
                        } else {
                            callbackYes(callbackArgument);
                        }
                    }


                    $(this).dialog("close");
                },

                Cancel: function () {

                    if (callbackNo && typeof (callbackNo) === "function") {
                        if (callbackArgument == null) {
                            callbackNo('test');
                        } else {
                            callbackNo(callbackArgument);
                        }
                    }


                    $(this).dialog("close");
                }
            }
        });


    if (TitleBarColor) {
        dlg.prev(".ui-dialog-titlebar").css("background", TitleBarColor);
    }

    dlg.dialog("open");
};



