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
            type: method,
            contentType: type,
            processData: false,
            success: success,
            error: error
        });

        //$.ajax({
        //    url: '/Skills/AddPositionSkills',
        //    type: 'POST',
        //    contentType: 'application/json',
        //    data: JSON.stringify({
        //        skills: ["asd"]
        //    })
        //});
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