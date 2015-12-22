/**
 * Created by w10 on 17.12.2015.
 */
(function(){
    'use strict';
   var SettingsService=function(){

   };
    SettingsService.prototype={
        baseUrl:'http://localhost:51094'
    };


    angular.module('testwebapi').service('SettingsService', SettingsService);
}());