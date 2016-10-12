var companies = {
    init: function () {
        companies.getCompaniesForSector();
    },
    getCompaniesForSector: function () {
        $('#supportedSector-dropdown').on('change', function () {
            var selectedSectorId = this.value;

            if (!utils.isNotNullOrEmpty(selectedSectorId)) {
                $('#businessInfo-supportedCompanies').html('<h2 class="text-center text-info">Please select a secotor...</h2>');
                return;
            }

            connect.sendAjax('/BusinessInfo/SupportedCompanies', { sectorId: selectedSectorId }, 'GET', 'text/html', function (response) {
                $('#businessInfo-supportedCompanies').html(response);
            }, function (response) {
                // Show error dialog.
            });
        });
    }
};

$(document).ready(function () {
    companies.init();
});