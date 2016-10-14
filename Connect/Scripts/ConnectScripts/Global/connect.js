var connect = {
    init: function () {
        connect.sendAjax();
    },
    sendAjax: function (url, data, method, type, success, error) {
        $.ajax({
            url: url,
            data: data,
            method: method,
            type: type,
            processData: false,
            success: success,
            error: error
        });
    }
};

$(document).ready(function () {
    connect.init();
});