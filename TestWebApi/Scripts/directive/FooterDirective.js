/**
 * Created by w10 on 02.12.2015.
 */
(
    function() {
        'use strict;'
        var FooterDirectiveFactory = function () {
            return {
                templateUrl: 'views/FooterDirective.html',
                restrict: 'E'
            };
        };

        angular.module('testwebapi').directive('testwebapiFooter', FooterDirectiveFactory);
    })();
