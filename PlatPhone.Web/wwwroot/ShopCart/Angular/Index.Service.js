IndexModule.service("IndexService", function ($http) {
    this.GetShopCartDetail = function () {
        return $http.get("/ShopCart/GetShopCart");
    };

    this.ChangeCount = function (productID, status, count, Attribute) {
        return $http({
            method: "POST",
            url: "/ShopCart/ChangeCount",
            data: { ProductID: productID, status: status, count: count, Attribute: Attribute}
        });
    };


    this.RemoveFromCart = function (productID, Attribute) {
        return $http({
            method: "POST",
            url: "/ShopCart/RemoveFromCart",
            data: { ProductID: productID, Attribute: Attribute}
        });
    };

    this.ChangeDetails = function (productID, Details, Attribute) {
        console.log(productID + " de " + Details + "  " + Attribute);
        return $http({
            method: "POST",
            url: "/ShopCart/ChangeDetails",
            data: { ProductID: productID, Details: Details, Attribute: Attribute}
        });
    };
 });