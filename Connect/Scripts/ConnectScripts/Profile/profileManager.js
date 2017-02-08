var profileManager = {
    init: function () {
        $(profileManager.selectors.formAreaSelector).hide();
        profileManager.methods.getAddSkillPanel();
        profileManager.methods.showDatePicker();
        profileManager.methods.clearAddExperienceForm();
    },
    events: {
        clickEvent: 'click'
    },
    selectors: {
        addExperienceButtonSelector: '#profile-qualifications-wrapper a',
        formAreaSelector: '.background',
        datePickerSelector: '.date-picker',
        addExperienceBtn: '#add-exp',
        addSkillBtn: '#add-skill-button',
        addSkillPanelId: '#add-skill-panel',
        experienceFormId: '#exp-form-id'
    },
    properties: {
        emptyString: ''
    },
    methods: {
        clearAddExperienceForm: function(){
            $(profileManager.selectors.addExperienceButtonSelector).click(function () {
                connect.clearForm(profileManager.selectors.experienceFormId);
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