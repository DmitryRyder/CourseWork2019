function adjustGridHeight() {
    $('.k-grid').each(function () {
        let grid = $(this).getKendoGrid();
        if (!grid)
            grid = $(this).getKendoTreeList();
        if (!(grid && grid.content))
            return;
        let height = $(window).height() - 5;

        var body = $('body');
        if (body.length === 1) {
            height -= parseFloat(body.css('padding-top'));
            height -= parseFloat(body.css('padding-bottom'));
            height -= parseFloat(body.css('margin-top'));
            height -= parseFloat(body.css('margin-bottom'));
        }
        var kReset = $(".k-reset.k-tabstrip-items");
        if (kReset.outerHeight(true)) {
            height -= kReset.outerHeight(true);
            height -= parseFloat(kReset.css('padding-top'));
        }
        var kStateActive = $(".k-content.k-state-active");
        if (kStateActive.length === 1) {
            height -= parseFloat(kStateActive.css('padding-top'));
            height -= parseFloat(kStateActive.css('padding-bottom'));
            height -= parseFloat(kStateActive.css('margin-bottom'));
        }
        grid.content.css('height', `${height}px`);
    });
}﻿

function error_handler(e) {
    if (e.errors) {
        var message = "Errors:\n";
        $.each(e.errors, function (key, value) {
            if ('errors' in value) {
                $.each(value.errors, function () {
                    message += this + "\n";
                });
            }
        });
        alert(message);
    }
}