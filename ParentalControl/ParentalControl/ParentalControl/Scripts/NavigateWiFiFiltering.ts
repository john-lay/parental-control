'use strict';

declare var clickTabMenu;

/* ****************************************************************************************************
 * click on the Wi-Fi Filtering tab
 * ****************************************************************************************************/
(() => {
    setTimeout(() => {
        window.frames["tabfrm"].clickTabMenu('link_Admin_1_3_1');
        // the Wi-Fi Filtering tab isn't shown so we need to reload the page
        location.reload();
    }, 250);
})();