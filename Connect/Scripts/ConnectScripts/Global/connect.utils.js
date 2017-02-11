var utils = {
    init: function () {
        utils.isNotNullOrEmpty();
        utils.jsonToArray();
    },
    isNotNullOrEmpty: function (text) {
        if (text === undefined) {
            return false;
        }

        if (text.length > 0 && text !== null) {
            return true;
        }

        return false;
    },
    jsonToArray: function (jsonObj) {
        if (jsonObj === undefined)
            return;

        return $.map(jsonObj, function (item) { return item; });
    }
};

$(document).ready(function () {
    utils.init();
});