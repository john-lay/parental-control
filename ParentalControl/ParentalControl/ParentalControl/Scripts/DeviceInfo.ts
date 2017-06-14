'use strict';

/* ****************************************************************************************************
 * grab the device info and send it as a get parameter back to the xamarin form
 * ****************************************************************************************************/
(() => {
    setTimeout(() => {
        try {
            window.location.href = window.location.href += "?deviceInfo=" + encodeURIComponent(JSON.stringify(window.frames["contentfrm"].DeviceInfo));
        } catch (e) {
            //alert(e.Message);
            window.location.href = window.location.href += "http://192.168.1.1/html/content.asp?error=" + encodeURIComponent(JSON.stringify(e));
        }
    }, 250);    
})();