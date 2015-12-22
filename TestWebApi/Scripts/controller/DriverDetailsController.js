/**
 * Created by w10 on 17.12.2015.
 */

(function() {
    "use strict";

    angular.module("testwebapi").controller("DriverDetailsController", ['$q','$route', 
        "ApiService", "driver", function($q, $route, apiService, driver) {
            var _this = this;
            _this.$q = $q;
            _this.driver = driver;
            _this.cars = [];
            _this.cars_avail = [];
            _this.all_cars = [];
            this.$route = $route;
            _this.avgFeedback = 0.0;

            var calcAvgFeedback= function(driver) {
                apiService.getAvgFeedback(driver).then(function(data) {
                    _this.avgFeedback = data;
                });
            };
            calcAvgFeedback(driver);

            _this.favOnOver = function (v) {

                for (var i = 0; i < v; i++) {
                    $("[id^=fav_]")[i].style["color"] = "orange";
                }

            };
            _this.favOnOut = function (v) {

                for (var i = 0; i < v; i++) {
                    $("[id^=fav_]")[i].style["color"] = "gray";
                    }

            };
            
            _this.Feedback=function(value) {
                apiService.Feedback(driver, value)
                    .then(function(data) {
                        calcAvgFeedback(driver);
                    });

            }

            _this.calcCars = function(driver) {

                apiService.getDriverCars(driver.driver_id)
                    .then(function(data) {
                        _this.cars = data;
                        return data;
                    })
                    .then(function(data) {
                        apiService.getCars().then(function(data2) {

                                _this.all_cars = data2;
                                return data2;
                            })
                            .then(function(data3) {

                                var arr = [];
                                arr = data3; //all

                                var resArr = arr.filter(function(i) {
                                    return !_.any(data, function(i2) {
                                        return i.auto_id === i2.auto_id;
                                    });

                                });

                                _this.cars_avail = resArr;
                                return resArr;
                            });
                    });
            };
            _this.calcCars(driver);
                
            _this.addCar= function(carId) {


                apiService.addCarToDrv(driver, carId)
                .then(function(data) {
                    _this.calcCars(driver);
                        });


            }

            _this.removeCar = function(carId) {

                apiService.removeCarFromDrv(driver, carId)
                .then(function (data) {
                    _this.calcCars(driver);
                });



//                _this.cars = apiService.getDriverCars(driver.driver_id);
//                var allcars = apiService.getCars();
//                _this.cars_avail = _.filter(allcars, function(a) {
//                    return _.find(_this.cars, function(b) {
//                        return a.auto_id != b.auto_id;
//                    });
//                });


            };

            _this.submit = function() {
                apiService.updateDriver(driver);
               
            }; 
        }
    ]);
}());