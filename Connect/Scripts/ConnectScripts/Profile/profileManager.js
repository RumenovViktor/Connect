var profileManager = {
    init: function () {
        $(profileManager.selectors.formAreaSelector).hide();
        profileManager.methods.showDatePicker();
        profileManager.methods.switchTabs();
        profileManager.methods.clearAddExperienceForm();
        profileManager.methods.closePannel();
        profileManager.methods.getDefaultSuitiblePositions();
        profileManager.methods.getSuitiblePositions();
        profileManager.methods.getFilteredSuitiblePositions();
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
        getFilteredSuitiblePositions: function () {
            var selectionCallback = function () {
                var sector = sectorDropdown.val();
                var country = countryDropdown.val();

                profileManager.methods.getSuitiblePositions(sector, country);
            }

            var sectorDropdown = $(profileManager.selectors.sectorId);
            var countryDropdown = $(profileManager.selectors.countryId);

            sectorDropdown.on(profileManager.events.changeEvent, selectionCallback);
            countryDropdown.on(profileManager.events.changeEvent, selectionCallback);
        },
        getDefaultSuitiblePositions: function () {
            $(profileManager.selectors.theWallId).on(profileManager.events.clickEvent, function () {
                profileManager.methods.getSuitiblePositions();
            });
        },
        getSuitiblePositions: function (sectorId, countryId) {
            var isActive = $(profileManager.selectors.theWallId).hasClass('active');
            if (!isActive)
                return;

            connect.sendAjax('/Profile/UserSuitiblePositions?sectorId=' + sectorId + '&countryId=' + countryId, null, 'GET', 'application/json', function (response) {
                $(profileManager.selectors.suitiblePositions).html('');
                $(profileManager.selectors.suitiblePositions).append(response);
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