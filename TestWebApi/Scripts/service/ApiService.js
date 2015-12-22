/**
 * Created by w10 on 17.12.2015.
 */

(function(){
    "use strict";

    var ApiService=function($http){
        this.$http=$http;
        
    };
    ApiService.$inject=["$http"];

    ApiService.prototype = {

        getDrivers: function() {
            return this.$http.get("api/driver")
                .then(function(resp) {
                    return resp.data;
                });
        },
        getDriverById: function(driverId) {
            return this.$http.get("api/driver/" + driverId)
                .then(function(resp) {
                    return resp.data;
                });
        },
        updateDriver: function(driver) {
            this.$http.put("/api/driver/" + driver.driver_id, driver);
        },
        getDriverCars: function(driverId) {

            var url = "api/driver/" + driverId.toString() + "/autos";

            return this.$http.get(url)
                .then(function(resp) {
                    return resp.data;
                });
        },
        addCarToDrv: function(driver, autoId) {
            return this.$http.post("/api/driver/" + driver.driver_id.toString() + "/auto", autoId);
        },
        removeCarFromDrv: function(driver, autoId) {
            return this.$http.put("/api/driver/" + driver.driver_id.toString() + "/auto", autoId.toString());
        },
        getAvgFeedback: function(driver) {
            return this.$http.get("api/driver/" + driver.driver_id.toString() + "/avgpoints").then(function(resp) {
                return resp.data;
            });
        },
        Feedback: function(driver, value) {
            return this.$http.post("api/driver/" + driver.driver_id.toString() + "/feedback", value).then(function(resp) {
                return resp.data;
            });
        },
        getCars: function() {
            return this.$http.get("api/auto")
                .then(function(resp) {
                    return resp.data;
                });
        },
        getCarById: function(carId) {
            return this.$http.get("api/auto/" + carId)
                .then(function(resp) {
                    return resp.data;
                });
        },
        getCarDrivers: function (carId) {

            var url = "api/auto/" + carId.toString() + "/drivers";

            return this.$http.get(url)
                .then(function(resp) {
                    return resp.data;
                });
        },
        addDrvToCar: function(car, driverId) {
            return this.$http.post("/api/auto/" + car.auto_id.toString() + "/driver", driverId);
        },
        removeDrvFromCar: function(car, driverId) {
            return this.$http.put("/api/auto/" + car.auto_id.toString() + "/driver", driverId.toString());
        },
        updateCar: function(car) {
            this.$http.put("/api/auto/" + car.auto_id, car);
        }

    };

    angular.module("testwebapi").service("ApiService", ApiService);

}());