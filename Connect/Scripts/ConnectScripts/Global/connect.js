var connect = {
    init: function () {
        connect.sendAjax();
        connect.clearForm();
        connect.showToolTip();
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
    },
    showToolTip: function () {
        $('[data-toggle="tooltip"]').tooltip();
    }
};

$(document).ready(function () {
    connect.init();
});