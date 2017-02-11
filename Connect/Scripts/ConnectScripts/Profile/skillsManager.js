var skillsManager = {
    init: function () {
        skillsManager.methods.getMatchedSkills();
        skillsManager.methods.populateSkillsDropdown();
    },
    properties: {
        timer: null
    },
    events: {
        changeEvent: 'change'
    },
    selectors: {
        skillsInput: '#skills-input'
    },
    methods: {
        stopInterval: function(){

        },
        getMatchedSkills: function () {
            var dropdown = $('#skills-dropdown');

            $(skillsManager.selectors.skillsInput).on(skillsManager.events.changeEvent, function () {
                skillsManager.properties.timer = setInterval(function () {
                    var skillTyped = $(skillsManager.selectors.skillsInput).val();

                    connect.sendAjax('/Profile/GetSkills?name=' + skillTyped, null, 'GET', 'text/json', function (response) {
                        skillsManager.methods.populateSkillsDropdown(response);
                        skillsManager.methods.populateSkillInput();
                    }, function () { });
                }, 1000)
            });
        },
        populateSkillInput: function () {
            $('.skill-option').on('click', function () {
                var selectedSkillName = this.innerText;
                $(skillsManager.selectors.skillsInput).val(selectedSkillName);
            });
        },
        populateSkillsDropdown: function (matchedSkills) {
            if (matchedSkills === undefined || !matchedSkills.length) {
                $('#skills-dropdown').hide();
                $('.skill-option').parent().remove();
                skillsManager.methods.destroySkillsDropdown();
                return;
            }

            var matchedSkillsToArray = utils.jsonToArray(matchedSkills);

            for (var i = 0; i < matchedSkillsToArray.length; i++) {
                $('#skills-dropdown').show();

                var doesElementExistInList = skillsManager.methods.checkIfReturnedValueIsInTheList(matchedSkillsToArray[i].Name);

                if (doesElementExistInList)
                    return;

                $('<a />', {
                    href: '#',
                    class: 'skill-option',
                    text: matchedSkillsToArray[i].Name
                }).wrap('<li/>').parent().appendTo('#skills-dropdown');
            }
        },
        checkIfReturnedValueIsInTheList: function (returnedSkill) {
            var allLiInUl = [];
            var isBullshit = false;

            $('#skills-dropdown').children('li').each(function (index, element) {
                if (returnedSkill === element.innerText.trim()) {
                    isBullshit = true;
                }
            });

            return isBullshit;
        }
    }
};

$(document).ready(function () {
    skillsManager.init();
});