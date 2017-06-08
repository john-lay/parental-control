'use strict';
/* ****************************************************************************************************
 * grab the device info and send it as a get parameter back to the xamarin form
 * ****************************************************************************************************/
(function () {
    setTimeout(function () {
        window.location.href = window.location.href += "?deviceInfo=" + encodeURIComponent(JSON.stringify(window.frames["contentfrm"].DeviceInfo));
    }, 250);
})();
//# sourceMappingURL=DeviceInfo.js.map