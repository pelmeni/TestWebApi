/**
 * Created by w10 on 01.12.2015.
 */
(
    //111
    function() {
        "use strict";
        var NavBarDirectiveFactory=function() {
        return {
          templateUrl:"views/NavbarDirective.html",
            restrict:"E"
        };
        };

        angular.module("testwebapi").directive("testwebapiNavbar",NavBarDirectiveFactory);
    }
)();
