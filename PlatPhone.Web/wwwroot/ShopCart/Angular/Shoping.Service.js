ShopingModule.service("ShopingService", function ($http) {
    this.GetShopingInformation = function () {
        return $http.get("/ShopCart/GetShopingInformation");
    };
    
    this.ChangeDetails = function (productID, Details) {
        return $http({
            method: "POST",
            url: "/ShopCart/ChangeDetails",
            data: { ProductID: productID, Details: Details }
        });
    };

    this.ChangeUserInformation = function (Information, CityFK) {
        return $http({
            method: "POST",
            url: "/ShopCart/ChangeUserInformation",
            data: { UserAddress: Information, "City_Id": CityFK}
        });
    };

    this.GetCity = function (id) {
        return $http({
            method: "POST",
            url: "/ShopCart/GetCity",
            data: { id: id }
        });
    };




 });