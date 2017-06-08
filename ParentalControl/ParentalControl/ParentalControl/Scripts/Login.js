'use strict';
/* ****************************************************************************************************
 * set the username and password fields and click the login button
 * ****************************************************************************************************/
(function () {
    document.getElementById('txt_Username').setAttribute('value', 'xxxxx');
    document.getElementById('txt_Password').setAttribute('value', 'xxxxx');
    //same as: document.getElementById("link").click()
    var clickEvent = document.createEvent('MouseEvent');
    clickEvent.initEvent('click', true, true);
    document.getElementById('btnLogin').dispatchEvent(clickEvent);
})();
//# sourceMappingURL=Login.js.map