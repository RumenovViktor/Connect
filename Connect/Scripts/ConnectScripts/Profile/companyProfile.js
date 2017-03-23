var companyProfileManager = {
    init: function () {
        companyProfileManager.methods.assocRecruiters();
    },
    events: {
        changeEvent: 'change'
    },
    selectors: {
        assocRecruitersId: '#assoc-recruiter'
    },
    methods: {
        assocRecruiters: function () {
            $(companyProfileManager.selectors.assocRecruitersId).on(companyProfileManager.events.changeEvent, function () {
                var userEmail = $(companyProfileManager.selectors.assocRecruitersId).val();
                connect.sendAjax('/CompanyProfile/FindUser?email=' + userEmail, null, 'GET', 'text/html', function (response) {
                    console.log(response);
                }, null);
            });
        }
    }
}

$(document).ready(function () {
    companyProfileManager.init();
});