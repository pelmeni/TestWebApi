(function () {
    'use strict';

    angular.module("testwebapi", ["ngRoute"])
        .config([
            "$routeProvider", function($routeProvider, $locationProvider) {
//
//                var title = function(page) {
//                    return page + '| testwebapi';
//                };
//
                $routeProvider
//                    .when("/", {
//                        templateUrl: "views/home.html",
//                        controller: "HomeController",
//                        controllerAs: "ctrl"
//                        //                        //title: title('Home')
//                        
//                    })


//                    .when("/driver/:id/driverMenu", {
//                        templateUrl: "views/driversCars.html?1",
//                        controller: "DriverDetailsController",
//                        controllerAs: "ctrl",
//                        disableCache: true,
//                        resolve: {
//                            driver: ["$route", "ApiService",
//                                function ($route, apiService) {
//                                    var driverId = parseInt($route.current.params.id);
//                                    return apiService.getDriverById(driverId);
//                                }
//                            ]
//                        }
//                    })
                    .when("/driver/:id/driverMenu", {
                        templateUrl: "views/driversCars.html",
                        controller: "DriverDetailsController",
                        controllerAs: "ctrl",
                        resolve: {
                            driver: [
                                "$route", "ApiService",
                                function($route, apiService) {
                                    var driverId = parseInt($route.current.params.id);
                                    return apiService.getDriverById(driverId);
                                }
                            ]
                        }
                    })
                    .when("/drivers", {
                        templateUrl: "views/drivers.html",
                        controller: "DriverController",
                        controllerAs: "ctrl"
                        //title: title('Водители')

                    })
                    .when("/driver/:id", {
                        templateUrl: "views/driver.html",
                        controller: "DriverDetailsController",
                        controllerAs: "ctrl",
                        disableCache: true,
                        //title: title('Product'),
                        resolve: {
                            driver: [
                                "$route", "ApiService",
                                function($route, apiService) {
                                    var driverId = parseInt($route.current.params.id);
                                    return apiService.getDriverById(driverId);
                                }
                            ]
                        }
                    })
                    .when("/cars", {
                        templateUrl: "views/cars.html",
                        controller: "CarController",
                        controllerAs: "ctrl"
                        //title: title('Автомобили')

                    })
                    .when("/car/:id", {
                        templateUrl: "views/car.html",
                        controller: "CarDetailsController",
                        controllerAs: "ctrl",
                        disableCache: true,
                        //title: title('Product'),
                        resolve: {
                            car: [
                                "$route", "ApiService",
                                function($route, apiService) {
                                    var carId = parseInt($route.current.params.id);
                                    return apiService.getCarById(carId);
                                }
                            ]
                        }
                    })
                    .when("/car/:id/carDrivers", {
                        templateUrl: "views/carDrivers.html",
                        controller: "CarDetailsController",
                        controllerAs: "ctrl",
                        resolve: {
                            car: [
                                "$route", "ApiService",
                                function($route, apiService) {
                                    var carId = parseInt($route.current.params.id);
                                    return apiService.getCarById(carId);
                                }
                            ]
                        }
                    })
                    .otherwise({
                        redirectTo: "/"
                    });
            }
        ]);


//        .run(['$rootScope', function($rootScope){
//            $rootScope.$on('$routeChangeSuccess', function (event, currentRoute) {
//                $rootScope.pageTitle=currentRoute.title;
//            });
//        }]);

}());
