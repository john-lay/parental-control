'use strict';
/* ****************************************************************************************************
 * click on the Wi-Fi Filtering tab
 * ****************************************************************************************************/
(function () {
    setTimeout(function () {
        try {
            window.frames["tabfrm"].clickTabMenu('link_Admin_1_3_1');
        }
        catch (e) {
            //alert(e.Message);
            window.location.href = window.location.href += "http://192.168.1.1/html/content.asp?error=" + encodeURIComponent(JSON.stringify(e));
        }
        // the Wi-Fi Filtering tab isn't shown so we need to reload the page
        location.reload();
    }, 250);
})();
//# sourceMappingURL=NavigateWiFiFiltering.js.map