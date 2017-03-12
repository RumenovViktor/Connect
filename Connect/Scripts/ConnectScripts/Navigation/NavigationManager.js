var navigationManager = {
    init: function () {
        navigationManager.methods.toogleNavContainer();
    },
    events: {
        clickEvent: 'click'
    },
    selectors: {
        navProfileSelector: '#nav-profile'
    },
    methods: {
        toogleNavContainer: function () {
            $(navigationManager.selectors.navProfileSelector).on(navigationManager.events.clickEvent, function () {
                $('.nav-select-option').toggle();
            });
        }
    }
}

$(document).ready(function () {
    navigationManager.init();
});