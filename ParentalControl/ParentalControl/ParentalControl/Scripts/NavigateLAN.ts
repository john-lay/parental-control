'use strict';

declare var clickMenuLink;

/* ****************************************************************************************************
 * navigate to the LAN page in the side nav
 * ****************************************************************************************************/
(() => {
    setTimeout(() => {
        // traverse to the menu frame (by name) then use the frames javascript method to handle nav clicks
        window.frames["menufrm"].clickMenuLink("link_Admin_0_2");
    }, 250);
})();