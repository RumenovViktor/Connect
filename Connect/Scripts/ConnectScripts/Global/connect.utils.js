var utils = {
    init: function () {
        utils.isNotNullOrEmpty();
    },
    isNotNullOrEmpty: function (text) {
        if (text === undefined) {
            return false;
        }

        if (text.length > 0 && text !== null) {
            return true;
        }

        return false;
    }
};

$(document).ready(function () {
    utils.init();
});