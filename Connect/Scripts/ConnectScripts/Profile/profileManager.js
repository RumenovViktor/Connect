var profileManager = {
    init: function () {
        profileManager.methods.createExperienceForm();
        $(profileManager.selectors.formAreaSelector).hide();
        profileManager.methods.getAddSkillPanel();
    },
    events: {
        clickEvent: 'click'
    },
    selectors: {
        addExperienceButtonSelector: '#profile-qualifications-wrapper a',
        formAreaSelector: '.background',
        closeButtonSelector: '#close-btn',
        datePickerSelector: '.date-picker',
        addExperienceBtn: '#add-exp',
        addSkillBtn: '#add-skill-button',
        addSkillPanelId: '#add-skill-panel'
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
        },
        getAddSkillPanel: function () {
            $(profileManager.selectors.addSkillBtn).on(profileManager.events.clickEvent, function () {
                connect.sendAjax('/Profile/AddSkill', null, 'GET', 'text/html', function (returnedData) {
                    $(profileManager.selectors.addSkillPanelId).html(returnedData);
                })
            });
        }
    }
}

$(document).ready(function () {
    profileManager.init();
});