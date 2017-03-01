var skillsManager = {
    init: function () {
        skillsManager.methods.getMatchedSkills();
        skillsManager.methods.populateSkillsDropdown();
        skillsManager.methods.addAsSelected();
        skillsManager.methods.addPositionRequiredSkills();
    },
    properties: {
    },
    events: {
        changeEvent: 'change',
        clickEvent: 'click'
    },
    selectors: {
        skillsInput: '.skills-input',
        addSkillButton: '.add-skill',
        addedSkills: '.added-skills'
    },
    methods: {
        stopInterval: function(){
            $('.close').on('click', function () {
                if (skillsManager.properties.timer != null) {
                    clearInterval(skillsManager.properties.timer);
                }
            });
        },
        getMatchedSkills: function () {
            var dropdown = $('#skills-dropdown');

            $(skillsManager.selectors.skillsInput).keyup(function() {
                    var skillTyped = $(skillsManager.selectors.skillsInput).val();

                    connect.sendAjax('/Skills/GetSkills?name=' + skillTyped, null, 'GET', 'text/json', function (response) {
                        skillsManager.methods.populateSkillsDropdown(response);
                        skillsManager.methods.populateSkillInput();
                    }, function () { });
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
        },
        addAsSelected: function () {
            $(skillsManager.selectors.addSkillButton).on(skillsManager.events.clickEvent, function () {
                var addedSkillsWell = $(skillsManager.selectors.addedSkills);
                var selectedSkill = $(skillsManager.selectors.skillsInput).val();

                if (addedSkillsWell.children('p').length) {
                    addedSkillsWell.html('');
                }

                addedSkillsWell.append('<span class="badge requiredSkill">' + selectedSkill + '</span>');
                $(skillsManager.selectors.skillsInput).val('');
                $('#skills-dropdown').html('');
                $('#skills-dropdown').hide();
            });
        },
        addPositionRequiredSkills: function (requiredSkills, positionId) {
            if (!requiredSkills || !requiredSkills.length)
                return;

            connect.sendAjax('/Skills/AddPositionSkills', JSON.stringify({ skills: requiredSkills, positionId: positionId }), 'POST', 'application/json', null, null);
        }
    }
};

$(document).ready(function () {
    skillsManager.init();
});