/**
 * Created by w10 on 17.12.2015.
 */

(function() {
    "use strinct";

    angular.module("testwebapi").controller("CarController", ["ApiService", function(apiService) {
            var _this = this;
            _this.cars = [];

            apiService.getCars()
                .then(function(data) {
                    _this.cars = data;
                });
        }
    ]);
}());