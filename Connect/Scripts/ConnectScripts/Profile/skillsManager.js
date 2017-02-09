var skillsManager = {
    init: function () {
        skillsManager.methods.getMatchedSkills();
        skillsManager.methods.populateSkillsDropdown();
    },
    events: {
        changeEvent: 'change'
    },
    selectors: {
        skillsInput: '#skills-input'
    },
    methods: {
        getMatchedSkills: function () {
            $(skillsManager.selectors.skillsInput).on(skillsManager.events.changeEvent, function () {
                setTimeout(function () {
                    var skillTyped = $(skillsManager.selectors.skillsInput).val();

                    connect.sendAjax('/Profile/GetSkills?name=' + skillTyped, null, 'GET', 'text/json', function (response) {

                    }, function () { });
                }, 500)
            });
        },
        populateSkillsDropdown: function (matchedSkills) {

        }
    }
};

$(document).ready(function () {
    skillsManager.init();
});