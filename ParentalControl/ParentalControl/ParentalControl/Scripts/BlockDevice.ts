'use strict';

/* ****************************************************************************************************
 * set the source MAC address field and click the submit button
 * ****************************************************************************************************/
(() => {
    setTimeout(() => {
        try {
            //window.frames["contentfrm"].document.forms["ConfigForm"].elements["X_WlanSrcMacAddress"].setAttribute('value', '44:6D:6C:EB:BF:EA');
            window.frames["contentfrm"].document.forms["ConfigForm"].elements["X_WlanSrcMacAddress"].value = '44:6D:6C:EB:BF:EA';

            var clickEvent = document.createEvent('MouseEvent');
            clickEvent.initEvent('click', true, true);
            window.frames["contentfrm"].document.getElementsByName("btnApply")[0].dispatchEvent(clickEvent);            
        } catch (e) {
            window.location.href = window.location.href += "http://192.168.1.1/html/content.asp?error=" + encodeURIComponent(JSON.stringify(e));
        }
    }, 250);    
})();