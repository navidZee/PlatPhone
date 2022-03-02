IndexModule.controller("IndexController", function ($scope, $rootScope, IndexService) {
    //برای زدن دکمه توضیحات)(اگه مساوی مقدار جدید با قبلی بود اون دکمه ریموو بشه)
    $scope.Detail = [];
    $scope.getShopCartDetail = function () {
        IndexService.GetShopCartDetail().then(function (output) {
            $scope.ShopCartDetail = output.data; 
            $scope.Total(output.data);
        }, function () {
            alert("در دریافت اطلاعات مشکلی بوجود امده است");
        });
    };

    $scope.changeCount = function (productId, status, Count, Attribute) {
        debugger;
        if (Count === 1 && status === false) {
            return null;
        }
        else {
            IndexService.ChangeCount(productId, status, Count, Attribute).then(function (output) {
                if (output !== false) {
                    $scope.ShopCartDetail = output.data;
                    $scope.Total(output.data);                 
                }
            }, function () {
                alert("در دریافت اطلاعات مشکلی بوجود امده است");
            });
        }
    };

    $scope.Total = function (data) {
        $scope.TotalProductPrice = 0;
        $scope.TotalDiscount = 0;
        $scope.TotalBuyProduct = 0;
        $scope.TotalCountProduct = 0;
        angular.forEach(data, function (value) {
            $scope.TotalProductPrice += ((value.product.price * value.count));
            $scope.TotalDiscount += (value.sal);
            $scope.TotalBuyProduct += (value.price);
            $scope.TotalCountProduct += value.count;
            $scope.Detail[value.product] = value.details;
        });
      
        $rootScope.$emit('changeCount', $scope.TotalCountProduct);
        $rootScope.$emit('CurrentShopCart', $scope.ShopCartDetail);
    };
    $scope.removeFromCart = function (productId, Attribute) {
        IndexService.RemoveFromCart(productId, Attribute).then(function (output) {
            $scope.ShopCartDetail = output.data;
            $scope.Total(output.data);
            $("#record_" + productId).fadeOut("1500");          
        });
    };
    $scope.changeDetails = function (productId, Details, Attribute,item) {         
        IndexService.ChangeDetails(productId, Details, Attribute).then(function (output) {
            $scope.Detail[item] = Details;
        });
    };
    $scope.FillModal = function (item) {
        $scope.CurrentProduct = item;        
    };
    $scope.getShopCartDetail();
});

