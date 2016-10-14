var profileBasicInfo = {
    init: function () {
        profileBasicInfo.uploadPicture();
    },
    uploadPicture: function () {
        $('#file').on('change', function (e) {
            $('#upload').submit();
        });
    }

};

$(document).ready(function () {
    profileBasicInfo.init();
});