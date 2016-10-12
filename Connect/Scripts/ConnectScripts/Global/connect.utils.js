var utils = {
    init: function () {
        utils.isNotNullOrEmpty();
    },
    isNotNullOrEmpty: function (text) {
        if (text.length > 0 && text !== 'undefined' && text !== null) {
            return true;
        }

        return false;
    }
};

$(document).ready(function () {
    utils.init();
});