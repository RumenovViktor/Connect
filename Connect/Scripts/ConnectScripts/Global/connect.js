var connect = {
    init: function () {
        connect.sendAjax();
        connect.clearForm();
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
    },
    clearForm: function (formId) {
        $(formId).trigger('reset');
    }
};

$(document).ready(function () {
    connect.init();
});