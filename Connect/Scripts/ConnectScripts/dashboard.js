var dashboardManager = {
    init: function () {
        //dashboardManager.methods.getSuitiblePositions();
        dashboardManager.methods.getFilteredSuitiblePositions();
    },
    events: {
        clickEvent: 'click',
        changeEvent: 'change'
    },
    selectors: {
        suitiblePositions: '#suitiblePositions',
        sectorId: '#sector',
        countryId: '#country'
    },
    methods: {
        getFilteredSuitiblePositions: function () {
            var selectionCallback = function () {
                var sector = sectorDropdown.val();
                var country = countryDropdown.val();

                connect.sendAjax('/Dashboard/UserSuitiblePositions?sectorId=' + sector + '&countryId=' + country, null, 'GET', 'application/json', function (response) {
                    $(dashboardManager.selectors.suitiblePositions).html('');
                    $(dashboardManager.selectors.suitiblePositions).append(response);
                });
            }

            var sectorDropdown = $(dashboardManager.selectors.sectorId);
            var countryDropdown = $(dashboardManager.selectors.countryId);

            sectorDropdown.on(dashboardManager.events.changeEvent, selectionCallback);
            countryDropdown.on(dashboardManager.events.changeEvent, selectionCallback);
        }
    }
}

$(document).ready(function () {
    dashboardManager.init();
});