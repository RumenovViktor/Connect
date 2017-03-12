var profileManager = {
    init: function () {
        $(profileManager.selectors.formAreaSelector).hide();
        profileManager.methods.showDatePicker();
        profileManager.methods.switchTabs();
        profileManager.methods.clearAddExperienceForm();
        profileManager.methods.closePannel();
    },
    events: {
        clickEvent: 'click',
        changeEvent: 'change'
    },
    selectors: {
        addExperienceButtonSelector: '#profile-qualifications-wrapper a',
        formAreaSelector: '.background',
        datePickerSelector: '.date-picker',
        addExperienceBtn: '#add-exp',
        addSkillPanelId: '#add-skill-panel',
        experienceFormId: '#exp-form-id',
        profileContentId: '#profile-content',
        profileNavBtn: '.profile-nav-btn',
        qualificationsTab: '#qualifications-tab',
        closeBtn: '.close',
        theWallId: '#theWallId',
        suitiblePositions: '#suitiblePositions',
        sectorId: '#sector',
        countryId: '#country'
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
        switchTabs: function () {
            var previousSelectedTab = $(profileManager.selectors.profileNavBtn + '.active');

            $(profileManager.selectors.profileNavBtn).on(profileManager.events.clickEvent, function () {
                $('#profile-content').html('');
                $(profileManager.selectors.profileNavBtn).removeClass('active');
                $(this).addClass('active');
            });
        },
        closePannel: function () {
            $(profileManager.selectors.closeBtn).on(profileManager.events.clickEvent, function () {
                $(this).parent().parent().hide('fadeout');
            });
        }
    }
}

$(document).ready(function () {
    profileManager.init();
});