(function () {
    'use strict';
    var sidebarAndWrapper = $("#sidebar,#wrapper");
    $("#sidebarToggle")
        .on('click',
            function () {
                sidebarAndWrapper.toggleClass('hide-sidebar');
            });
})();