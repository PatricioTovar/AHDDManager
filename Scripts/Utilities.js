function currencyValidate(evt, input) {
    var theEvent = evt || window.event;   

    var text = '';

    // Handle paste
    if (theEvent.type === 'paste') {
        text = event.clipboardData.getData('text/plain');
    } else {
        // Handle key press
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
        text = input.value + key

        if (key == '.') {
            text += "00";
        }
    }
    var regex = /^((\d|[1-9]\d+)(\.\d{1,2})?|\.\d{1,2})$/;
    if (!regex.test(text)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}

function numericValidate(evt) {
    var theEvent = evt || window.event;

    // Handle paste
    if (theEvent.type === 'paste') {
        text = event.clipboardData.getData('text/plain');
    } else {
        // Handle key press
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);        
    }
    var regex = /^[0-9]/;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}

var formatterCurrency = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',

    // These options are needed to round to whole numbers if that's what you want.
    //minimumFractionDigits: 0, // (this suffices for whole numbers, but will print 2500.10 as $2,500.1)
    //maximumFractionDigits: 0, // (causes 2500.99 to be printed as $2,501)
});

//https://jqueryui.com/autocomplete/#combobox
$(function () {
    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<div>")
                .attr("id", this.element.attr("id") + "-wrapper")
                .addClass("custom-combobox")
                .addClass("input-group")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .attr("id", this.element.attr("id") + "-input")
                .appendTo(this.wrapper)
                .addClass("form-control")
                .val(value)
                .attr("placeholder", this.element.data("placeholder"))
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source")
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                    this.element.change();
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {
            var input = this.input,
                wasOpen = false;

            $("<span>")
                .attr("id", this.element.attr("id") + "-button")
                .appendTo(this.wrapper)
                .addClass("input-group-addon btn btn-default")
                .append($("<i>").addClass("fa fa-caret-down fa-lg"))
                .attr("tabIndex", -1)
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                })
                .attr("title", "Show All")
                .tooltip({
                    placement: "left",
                    container: "#" + this.element.attr("id") + "-wrapper"
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {
                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;
            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {
                return;
            }

            // Remove invalid value
            this.input.val("")
            this.element.val("").change();


        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        },

        clear: function () {
            this.input.val("")
            this.element.val("").change();
        }
    });

});