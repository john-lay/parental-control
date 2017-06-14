'use strict';
/* ****************************************************************************************************
 * navigate to the Basic > Wi-Fi page in the side nav
 * ****************************************************************************************************/
(function () {
    setTimeout(function () {
        // traverse to the menu frame (by name) then use the frames javascript method to handle nav clicks
        try {
            window.frames["menufrm"].clickMenuLink("link_Admin_1_3");
        }
        catch (e) {
            //alert(e.Message);
            window.location.href = window.location.href += "http://192.168.1.1/html/content.asp?error=" + encodeURIComponent(JSON.stringify(e));
        }
    }, 250);
})();
//# sourceMappingURL=NavigateBasicWiFi.js.map