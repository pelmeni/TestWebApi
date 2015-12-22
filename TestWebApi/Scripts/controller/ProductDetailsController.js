/**
 * Created by w10 on 02.12.2015.
 */
(
    function(){
        'use strict;'

        var ProductDetaisController=function(product){
            var _this=this;
            _this.product= product;

        };
        ProductDetaisController.$inject = ['product'];
        angular.module('testwebapi').controller('ProductDetailsController', ProductDetaisController);



    }
)();
