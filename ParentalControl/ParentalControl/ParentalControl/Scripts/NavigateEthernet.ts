'use strict';

declare var clickTabMenu;

/* ****************************************************************************************************
 * click on the ethernet tab
 * ****************************************************************************************************/
(() => {
    setTimeout(() => {
        window.frames["tabfrm"].clickTabMenu('link_Admin_0_2_1');
        // the ethernet tab isn't shown so we need to reload the page
        location.reload();
    }, 250);
})();