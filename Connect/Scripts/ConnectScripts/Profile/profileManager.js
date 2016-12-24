var profileManager = {
    init: function () {
        profileManager.methods.createExperienceForm();
        $(profileManager.selectors.formAreaSelector).hide();
    },
    events: {
        clickEvent: 'click'
    },
    selectors: {
        addExperienceButtonSelector: '#profile-qualifications-wrapper a',
        formAreaSelector: '.background',
        closeButtonSelector: '#close-btn',
        datePickerSelector: '.date-picker',
        addExperienceBtn: '#add-exp'
    },
    properties: {
        emptyString: ''
    },
    methods: {
        createExperienceForm: function () {
            $(profileManager.selectors.addExperienceButtonSelector).on(profileManager.events.clickEvent, function () {
                connect.sendAjax('/Profile/AddExperience', null, 'GET', 'text/html', function (returnData) {
                    $(profileManager.selectors.formAreaSelector).html(returnData);
                    $(profileManager.selectors.formAreaSelector).fadeIn();
                    profileManager.methods.destroyExperienceForm();
                    profileManager.methods.showDatePicker();
                }, function (returnData) { });
            });
        },
        destroyExperienceForm: function () {
            $(profileManager.selectors.closeButtonSelector).on(profileManager.events.clickEvent, function () {
                $(profileManager.selectors.formAreaSelector).fadeOut(200, function () {
                    $(profileManager.selectors.formAreaSelector).html(profileManager.properties.emptyString);
                });
            });
        },
        showDatePicker: function () {
            $(profileManager.selectors.datePickerSelector).datepicker({
                dateFormat: "yy/mm/dd"
            });
        }
    }
}

$(document).ready(function () {
    profileManager.init();
});