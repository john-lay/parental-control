'use strict';
/* ****************************************************************************************************
 * find the blocked device in the table, locate the associated checkbox and remove from black list
 * ****************************************************************************************************/
(function () {
    setTimeout(function () {
        try {
            var rows = window.frames["contentfrm"].document.getElementById("wlMacFliter").getElementsByClassName("trTabContent");
            var macAddress = '44:6D:6C:EB:BF:EA';
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].cells[0].innerText.trim() == macAddress) {
                    // check the input box
                    rows[i].cells[1].children[0].checked = true;
                    // click the remove button
                    window.frames["contentfrm"].clickRemove('Wi-Fi Filtering');
                }
            }
        }
        catch (e) {
            //alert(e.Message);
            window.location.href = window.location.href += "http://192.168.1.1/html/content.asp?error=" + encodeURIComponent(JSON.stringify(e));
        }
    }, 250);
})();
//# sourceMappingURL=UnblockDevice.js.map