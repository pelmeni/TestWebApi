(
    //111
    function () {
        "use strict";
        var CarDriversDirectiveFactory = function () {
            return {
                templateUrl: "views/carDrivers.html",
                restrict: "E",
                repalce: "true"
                //,scope: {}
            };
        };

        angular.module("testwebapi").directive("testwebapiCardrivers", CarDriversDirectiveFactory);
    }
)();
