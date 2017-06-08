'use strict';

/* ****************************************************************************************************
 * grab the device info and send it as a get parameter back to the xamarin form
 * ****************************************************************************************************/
(() => {
    setTimeout(() => {
        window.location.href = window.location.href += "?deviceInfo=" + encodeURIComponent(JSON.stringify(window.frames["contentfrm"].DeviceInfo));
    }, 250);    
})();