//! Copyright (c), Data & Object Factory, LLC, All rights reserved.

//
// To learn more about JavaScript patterns see our
//  -- Dofactory JS product
//

// ** JavaScript Namespace pattern

var Dofactory = {
    namespace: function (name) {
        var parts = name.split(".");
        var ns = this;

        for (var i = 0, len = parts.length; i < len; i++) {
            ns[parts[i]] = ns[parts[i]] || {};
            ns = ns[parts[i]];
        }

        return ns;
    }
};

// Namespace template -- use this as a template on local pages

Dofactory.namespace("Local").Doit = (function () {

    var start = function () {
    };

    return { start: start };

})();

// Displays failure and success alert boxes

Dofactory.namespace("Utils").Alert = (function () {

    var start = function () {

        $("#alert-success").fadeIn(1000).delay(3000).fadeOut(1000, function () {
            $(this).remove();
        });

        $("#alert-failure").fadeIn(1000).delay(5500).fadeOut(1000, function () {
            $(this).remove();
        });

        $("#alert-info").fadeIn(500).delay(6500).fadeOut(1000, function () {
            $(this).remove();
        });
    };

    return { start: start };

})();

// Confirm delete requests

Dofactory.namespace("Utils").Delete = (function () {

    var start = function () {

        $('.js-delete').each(function () {

            var dependencies = $(this).data('dependencies');
            if (dependencies > 0) {
                $(this).prop('href', 'javascript:void(0);');
                $(this).prop('title', 'Cannot be deleted');
                $(this).attr('data-toggle', 'tooltip');
                $(this).tooltip();
            }
        });

        // delete button. open modal delete confirmation box.

        $('.js-delete').on('click', function (e) {

            if ($(this).attr('href') != "javascript:void(0);") {
                var id = $(this).data('id');
                var returnUrl = $(this).data('return-url');

                // opens and populates modal delete box

                $('#delete-id').val(id);
                $('#delete-return-url').val(returnUrl);
                $('#delete-form').attr('action', $(this).attr("href"));
                $('#delete-modal').modal('show');
            }

            e.preventDefault();
            return false;
        });

        $('.js-submit-delete').on('click', function (e) {

            var url = $('#delete-form').attr('action');
            var id = $('#delete-id').val();
            var token = $('[name="__RequestVerificationToken"]').val();
            var data = { 'id': id, '__RequestVerificationToken': token };

            $.ajax({
                url: url,
                type: 'POST',
                data: data,
                error: function (e) {
                    alert('Sorry, an error occured');
                    location = location;
                },
                success: function (data) {
                    // redirect page or refresh same page

                    var returnUrl = $('#delete-return-url').val();

                    if (returnUrl) {
                        location = returnUrl;
                    } else {
                        location = location;
                    }
                }
            });
        });

        // set the proper referer url before editing

        $('.js-edit').on('click', function (e) {

            var url = window.location.href.split('?')[0];
            history.pushState({}, '', url + "?tab=details");

            return true;
        });
    };

    return { start: start };

})();

// Page tabs, filters, and sorters 

Dofactory.namespace("Utils").Misc = (function () {

    var start = function () {

        // activate proper tab when returning to detail pages

        var tab = getUrlParameter("tab");

        if (tab) {
            $('[href="#' + tab + '"]').click();
        }

        var subtab = getUrlParameter("subtab");

        if (subtab) {
            $('[href="#' + subtab + '"]').click();
        }

        // center tab in detail page is clicked -> display different tab area

        $('.tabs a').on('click', function (e) {
            var tab = $(this).attr("href").substr(1);
            var url = window.location.href.split('?')[0];
            history.pushState({}, '', url + "?tab=" + tab);

            $(this).tab('show');
            e.preventDefault();
            return false;
        });

        // standard filter dropdown changed -> submit

        $('#Filter').on('change', function () {
            $('#Page').val(1);
            $(this).closest('form').submit();
        });

        // advanced filter button is clicked

        $('.js-filter').on('click', function () {
            $('#Page').val(1);
        });

        // Start export to Excel

        $('.js-export').on('click', function (e) {
            var url = $(this).attr("href");
            var form = $(this).closest('form');

            form.attr("action", url);
            form.submit();
            form.attr("action", "");

            e.preventDefault();
            return false;
        });



        // sort header is clicked -> submit

        $('[data-sort]').on('click', function () {
            var sort = $(this).data('sort');
            $("#Sort").val(sort);
            $("#Page").val(1);

            $(this).closest('form').submit();
        });

        // page button is clicked -> submit

        $('[data-page]').on('click', function () {
            var page = $(this).data('page');
            $("#Page").val(page);

            $(this).closest('form').submit();
        });

        // Filter toggles are clicked -> animate to different filter area

        $('.standard-toggle').on('click', function () {
            $('#standard-filter').slideDown();
            $('#advanced-filter').slideUp();
            $('#AdvancedFilter').val('False');

            $('.advanced-toggle').removeClass('active');
            $('.standard-toggle').addClass('active');
        });

        $('.advanced-toggle').on('click', function () {
            $('#standard-filter').slideUp();
            $('#advanced-filter').slideDown();
            $('#AdvancedFilter').val('True');

            $('.standard-toggle').removeClass('active');
            $('.advanced-toggle').addClass('active');
        });

        // Initialize popovers and tooltips

        $('[data-toggle="popover"]').popover({ placement: "top", trigger: "hover", html: true });
        $('[data-toggle="tooltip"]').tooltip();

        // Initialize date picker

        $('.js-date-picker').datepicker({ format: 'm/d/yyyy', autoclose: true, orientation: 'bottom' });


        //FROM https://stackoverflow.com/questions/17965839/close-a-div-by-clicking-outside

        $('.search-popup').on('click', function (ev) {
            ev.stopPropagation(); // prevent event from bubbling up to the body and closing the popup
        });

        $(".search-link").click(function (e) {

            var popup = $('.search-popup');
            popup.fadeIn(300, function () { $(this).focus(); $('#q').focus(); });


            setTimeout(function () {
                $('body').on('click', function (ev) {
                    popup.fadeOut(300); // click anywhere to hide the popup; all click events will bubble up to the body if not prevented
                    $(this).off('click');
                });

            }, 500);



            e.preventDefault();
        });


        $('.timeline').each(function (index, el) {
            var height = $(this).parent().height();
            
            $(this).css('min-height', (height - 40) + 'px');
        });

        // When any checkbox is clicked set value to true/false to facilitate submission to server
        $(':checkbox').on('click', function () {
            if ($(this).is(":checked")) {
                $(this).val('true');
            } else {
                $(this).val('false');
            }
        });
    };

    // get parameter value from query string

    var getUrlParameter = function (name) {

        var url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");

        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)");
        var results = regex.exec(url);

        if (!results) return null;
        if (!results[2]) return '';

        return decodeURIComponent(results[2].replace(/\+/g, " "));
    };

    return { start: start, getUrlParameter: getUrlParameter };

})();

// Supports Excel import

Dofactory.namespace("Utils").Import = (function () {

    var start = function () {

      //  $('[data-toggle="tooltip"]').tooltip();

        //$('#itemupload').on('click', function (e) {
        //    $('#DataloadItem').val('Accounts');
        //});

        $('#itemupload').on('change', function () {
            $('#image-loader').show();
            $(this).closest('form').submit();
        });

        $('#accept').on('click', function () {
            $('#accept-image-loader').show();
            return true;
        });

        $(".dropdown-menu li a").click(function () {
            var text = $(this).text();
            $('#type').val(text);
            $(this).closest("form").submit();
        });
    };

    return { start: start };

})();

// Support for Typeahead Search controls

Dofactory.namespace("Utils").Typeahead = (function () {

    var init = function (controlId, list) {

        var typeahead = function (controlId, list) {

            var controlid = controlId;
            var items = list;

            var matcher = function (items) {
                return function findMatches(q, process) {
                    var matches = [];
                    var regex = new RegExp(q, 'i');

                    // iterate through the pool of strings and for any string that
                    // contains the substring `q`, add it to the `matches` array
                    $.each(items, function (i, item) {
                        if (regex.test(item.name)) {
                            matches.push(item);
                        }
                    });
                    //console.log(matches)

                    // display some suggestions if nothing has been typed yet.

                    if (!q && matches.length == 0) {
                        $.each(items.slice(0, 4), function (i, item) {
                            matches.push(item.name);
                        });
                    }

                    process(matches);
                };
            };


            $('#' + controlid + 'Input').typeahead({
                hint: true,
                minLength: 0
            },
                {
                    name: 'items',
                    source: matcher(items),
                    display: 'name',
                    templates: {
                        suggestion: Handlebars.compile('<div><i class="{{icon}} icon-little"></i> {{name}}</div>')
                    }
                })
                .on("typeahead:selected", function (obj, item) {

                    $('.typeahead').typeahead('close');
                    $('#' + controlid).val(item.id);
                    $('#' + controlid + 'Type').val(item.type);
                });


            // If an id exists, then find the name and assign its value and type to input control
            var currentid = $('#' + controlid).val();
            var currenttype = $('#' + controlid + 'Type').val();

            if (currentid > 0) {
                $.each(items, function (i, item) {
                    if (item.id == currentid) {
                        if (!currenttype || item.type == currenttype) {
                            $('#' + controlid + 'Input').typeahead('val', item.name);
                        }
                    }
                });
            } else {
                $('#' + controlid + 'Input').val('');
            }
        };

        typeahead(controlId, list);
    };

    var start = function () {

        // Set dropdown width to same width of input control
        setTimeout(function () {
            $('.twitter-typeahead .tt-menu').each(function (index, item) {
                var width = $(this).siblings('.tt-input').css('width');
                $(this).css('width', width);
            });
        }, 100);
    };

    return {
        start: start,
        init: init
    };

})();


$(function () {

    Dofactory.Utils.Alert.start();
    Dofactory.Utils.Misc.start();
    Dofactory.Utils.Delete.start();
    Dofactory.Utils.Typeahead.start();

});
