/**
 * Created by w10 on 17.12.2015.
 */

(function() {
    "use strinct";

    angular.module("testwebapi").controller("DriverController", ["ApiService", function(apiService) {
            var _this = this;
            _this.drivers = [];

            apiService.getDrivers()
                .then(function(data) {
                    _this.drivers = data;
                });
        }
    ]);
}());