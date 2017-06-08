'use strict';
/* ****************************************************************************************************
 * navigate to the LAN page in the side nav
 * ****************************************************************************************************/
(function () {
    setTimeout(function () {
        // traverse to the menu frame (by name) then use the frames javascript method to handle nav clicks
        window.frames["menufrm"].clickMenuLink("link_Admin_0_2");
    }, 250);
})();
//# sourceMappingURL=NavigateLAN.js.map