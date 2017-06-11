'use strict';
/* ****************************************************************************************************
 * navigate to the Basic > Wi-Fi page in the side nav
 * ****************************************************************************************************/
(function () {
    setTimeout(function () {
        // traverse to the menu frame (by name) then use the frames javascript method to handle nav clicks
        window.frames["menufrm"].clickMenuLink("link_Admin_1_3");
    }, 250);
})();
//# sourceMappingURL=NavigateBasicWiFi.js.map