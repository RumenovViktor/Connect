var loginSiteManager = {
    init: function () {
        loginSiteManager.existingUserMessage();
        loginSiteManager.redirectToUrl();
        loginSiteManager.redirectToUrlWithData();
    },
    existingUserMessage: function (data) {
        if (data) {    
            sweetAlert("Oops...", data.statusText, "error");
        }
    },
    redirectToUrl: function (data) {
        if (data) {
            window.location.href = data.RedirectUrl;
        }
    }
};

$(document).ready(function () {
    loginSiteManager.init();
});