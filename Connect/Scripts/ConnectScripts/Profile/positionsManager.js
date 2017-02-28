var positionsManager = {
    init: function () {
        positionsManager.methods.processPosition();
    },
    selectors: {
        addPositionBtn: '#add-position'
    },
    events: {
        click: 'click'
    },
    methods: {
        processPosition: function (response) {
            if (!response)
                return;

            var requiredSkills = [];

            $('.requiredSkill').each(function () {
                requiredSkills.push($(this).text());
            });

            skillsManager.methods.addPositionRequiredSkills(requiredSkills);

            $('.positions-list').append(response);
        }
    }
};

$(document).ready(function () {
    positionsManager.init();
});