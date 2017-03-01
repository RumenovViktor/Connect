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

            $('.positions-list').append(response);
            var positionIds = $('.positionId');
            var lastPositionId = positionIds.last().val();
            skillsManager.methods.addPositionRequiredSkills(requiredSkills, lastPositionId);
        }
    }
};

$(document).ready(function () {
    positionsManager.init();
});