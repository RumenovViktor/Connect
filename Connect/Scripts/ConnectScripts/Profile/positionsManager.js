var positionsManager = {
    init: function () {
        positionsManager.methods.processPosition();
        positionsManager.methods.positionCreation();
    },
    selectors: {
        openCreatePositionBtn: '#openCreatePosition',
        positionCreation: "#positionCreation"
    },
    events: {
        click: 'click'
    },
    methods: {
        positionCreation: function(){
            $(positionsManager.selectors.openCreatePositionBtn).on(positionsManager.events.click, function () {
                $(positionsManager.selectors.positionCreation).show();
            });
        },
        processPosition: function (response) {
            if (!response)
                return;

            var requiredSkills = [];

            $('.requiredSkill').each(function () {
                requiredSkills.push($(this).text());
            });

            skillsManager.methods.addPositionRequiredSkills(requiredSkills, response);
        },

    }
};

$(document).ready(function () {
    positionsManager.init();
});