/**
 * Created by w10 on 17.12.2015.
 */

(function() {
    "use strict";

    angular.module("testwebapi").controller("CarDetailsController", ['$route', 
        "ApiService", "car", function( $route, apiService, car) {
            var _this = this;
            
            _this.car = car;
            _this.drivers = [];
            _this.drivers_avail = [];
            _this.all_drivers = [];
            this.$route = $route;
         


            _this.calcDrivers = function(car) {

                apiService.getCarDrivers(car.auto_id)
                    .then(function(data) {
                        _this.drivers = data;
                        return data;
                    })
                    .then(function(data) {
                        apiService.getDrivers().then(function(data2) {

                                _this.all_drivers = data2;
                                return data2;
                            })
                            .then(function(data3) {

                                var arr = [];
                                arr = data3; //all

                                var resArr = arr.filter(function(i) {
                                    return !_.any(data, function(i2) {
                                        return i.driver_id === i2.driver_id;
                                    });

                                });

                                _this.drivers_avail = resArr;
                                return resArr;
                            });
                    });
            };
            _this.calcDrivers(car);
                
            _this.addDriver= function(driverId) {


                apiService.addDrvToCar(car, driverId)
                .then(function(data) {
                    _this.calcDrivers(car);
                        });


            }

            _this.removeDriver = function(driverId) {

                apiService.removeDrvFromCar(car, driverId)
                    .then(function(data) {
                        _this.calcDrivers(car);
                    });
            }


//                _this.cars = apiService.getDriverCars(driver.driver_id);
//                var allcars = apiService.getCars();
//                _this.cars_avail = _.filter(allcars, function(a) {
//                    return _.find(_this.cars, function(b) {
//                        return a.auto_id != b.auto_id;
//                    });
//                });


//            };

            _this.submit = function() {
                apiService.updateCar(car);
               
            }; 
        }
    ]);
}());