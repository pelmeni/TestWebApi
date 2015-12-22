(
    //111
    function () {
        "use strict";
        var DrivermenuDirectiveFactory = function () {
            return {
                templateUrl: "views/driversCars.html",
                restrict: "E",
                repalce: "true"
                //,scope: {}
            };
        };

        angular.module("testwebapi").directive("testwebapiDrivermenu", DrivermenuDirectiveFactory);
    }
)();
