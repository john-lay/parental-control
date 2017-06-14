'use strict';

/* ****************************************************************************************************
 * set the source MAC address field and click the submit button
 * ****************************************************************************************************/
(() => {
    setTimeout(() => {
        try {
            // check if there's already an existing device on the black list
            if (window.frames["contentfrm"].document.forms["ConfigForm"].elements["X_WlanSrcMacAddress"].value !== "") {
                window.frames["contentfrm"].clickAdd('Wi-Fi Filtering');
            }

            setTimeout(() => {
                //window.frames["contentfrm"].document.forms["ConfigForm"].elements["X_WlanSrcMacAddress"].setAttribute('value', '44:6D:6C:EB:BF:EA');
                window.frames["contentfrm"].document.forms["ConfigForm"].elements["X_WlanSrcMacAddress"].value = '44:6D:6C:EB:BF:EA';

                var clickEvent = document.createEvent('MouseEvent');
                clickEvent.initEvent('click', true, true);
                window.frames["contentfrm"].document.getElementsByName("btnApply")[0].dispatchEvent(clickEvent);

                // move the navigation along
                location.reload();
            }, 250);
        } catch (e) {
            //alert(e.Message);
            window.location.href = window.location.href += "http://192.168.1.1/html/content.asp?error=" + encodeURIComponent(JSON.stringify(e));
        }
    }, 250);
})();