'use strict';

declare var clickTabMenu;

/* ****************************************************************************************************
 * click on the ethernet tab
 * ****************************************************************************************************/
(() => {
    setTimeout(() => {
        try {
            window.frames["tabfrm"].clickTabMenu('link_Admin_0_2_1');
            // the ethernet tab isn't shown so we need to reload the page
            location.reload();
        } catch (e) {
            //alert(e.Message);
            window.location.href = window.location.href += "http://192.168.1.1/html/content.asp?error=" + encodeURIComponent(JSON.stringify(e));
        }        
    }, 250);
})();