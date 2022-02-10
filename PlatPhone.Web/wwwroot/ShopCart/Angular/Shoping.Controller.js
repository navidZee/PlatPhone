ShopingModule.controller("ShopingController", function ($scope, ShopingService, $rootScope) {
    $scope.UserInformation = [];
    $scope.getShopingInformation = function () {
        ShopingService.GetShopingInformation().then(function (output) {            
            $scope.ShopingInformation = output.data;
            $scope.MainStateNameUser = output.data[0].MainStateName;
            $scope.LastName = output.data[0].LastName;
            $scope.FirstName = output.data[0].FirstName;
            $scope.SubStateNameUser = output.data[0].SubStateName;
            $scope.PlaqueUser = output.data[0].Plaque;
            $scope.PostalCodeNameUser = output.data[0].PostalCodeName;
            $scope.ListCityID = output.data[0].ListCityID;
            $scope.ListCityName = output.data[0].ListCityName;
            $scope.ListProvinceID = output.data[0].ListProvinceID;
            $scope.ListProvinceName = output.data[0].ListProvinceName;
            $scope.Total(output.data);
            console.log(output.data);
           }, function () {
            toast('در دریافت اطلاعات مشکلی بوجود امده است ', 'danger', 5000);
        });
    };

    $scope.Total = function (data) {
        $scope.TotalProductPrice = 0;
        $scope.TotalDiscount = 0;
        $scope.TotalBuyProduct = 0;
        $scope.TotalCountProduct = 0;
        angular.forEach(data, function (value) {
            $scope.TotalProductPrice += ((value.Product.Price * value.Count) / 10);
            $scope.TotalDiscount += (value.Sal / 10);
            $scope.TotalBuyProduct += (value.Price / 10);
            $scope.TotalCountProduct += value.Count;
        });
    };


    $scope.changeUserInformation = function () {    
        var record = { "MainStateName": $scope.MainStateNameUser, "SubStateName": $scope.SubStateNameUser, "Plaque": $scope.PlaqueUser, "PostalCodeName": $scope.PostalCodeNameUser};
        ShopingService.ChangeUserInformation(record,$scope.CityIdForUser).then(function (output) {
            if (output.data) {                
                $scope.ShopingInformation[0].MainStateName = record.MainStateName;
                $scope.ShopingInformation[0].SubStateName = record.SubStateName;
                $scope.ShopingInformation[0].Plaque = record.Plaque;
                $scope.ShopingInformation[0].ProvinceName = $("#UserProvince option:selected").text();
                $scope.ShopingInformation[0].CityName = $("#UserCity option:selected").text();
                hideModal('UpdateUserInformation');
            }
        }, function () {
            toast('در دریافت اطلاعات مشکلی بوجود امده است ', 'danger', 5000);
        });
    };

    $scope.getCityForUser = function () {
        if ($scope.selectedCityForUser !== 0) {
            ShopingService.GetCity($scope.selectedCityForUser).then(function (output) {
                angular.forEach(output.data, function (value, key) {
                    $scope.ListCityID[key] = value.Id,
                        $scope.ListCityName[key] = value.CityName;
                });
            }, function () {
                toast('در دریافت اطلاعات مشکلی بوجود امده است ', 'danger', 5000);
            });
        }
    };

    $scope.getShopingInformation();
});

