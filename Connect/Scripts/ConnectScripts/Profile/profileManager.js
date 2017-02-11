var profileManager = {
    init: function () {
        $(profileManager.selectors.formAreaSelector).hide();
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
        }
    }
}

$(document).ready(function () {
    profileManager.init();
});