
async function ListProductStatus(id = undefined) {
    $("#ProductTableRow").html($loading);
    $TempObject = {};
    $result = await AjaxCall("GET", '/Admin/ProductStatus/ListProductStatus' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#ProductTableRow").html($result);
    console.log($result);
    //$("ul.pagination li").removeAttr("disabled");
    //$(`ul.pagination li:nth-child(${pageindex})`).removeAttr("disabled");
}
ListProductStatus();


async function SuccssProductStatus(id) {
    if (confirm("آیا برای تبدیل وضعیت به حالت ارسال شده اطمینان دارید؟ ")) {

        $("#ProductTableRow").html($loading);
        $result = await AjaxCall("GET", `/Admin/ProductStatus/SuccssProductStatus?id=${id}`, $TempObject, 0);
        $("#ProductTableRow").html($result);
        $("#currentid").val(id);
        ListProductStatus();
    }
}


async function RejectdProductStatus(id) {
    if (confirm("آیا برای تبدیل وضعیت به حالت مرجوعی اطمینان دارید؟ ")) {
        $("#ProductTableRow").html($loading);
        $result = await AjaxCall("GET", `/Admin/ProductStatus/RejectdProductStatus?id=${id}`, $TempObject, 0);
        $("#ProductTableRow").html($result);
        $("#currentid").val(id);
        ListProductStatus();
    }
}

async function SendingProductStatus(id) {
    if (confirm("آیا برای تبدیل وضعیت به حالت مرجوعی اطمینان دارید؟ ")) {
        $("#ProductTableRow").html($loading);
        $result = await AjaxCall("GET", `/Admin/ProductStatus/SendingProductStatus?id=${id}`, $TempObject, 0);
        $("#ProductTableRow").html($result);
        $("#currentid").val(id);
        ListProductStatus();
    }
}



var ajaxResult = $("#AjaxResults");
var onBegin = function () {
    ajaxResult.html($loading);
}

var onSuccess = function (context) {
    console.log($("#BasicModal"));
    if (context == "OK") {
        $('#BasicModal').modal('hide');
        LoadListCategory();
    }
}

var onFailed = function (xhr) {
    //toastr[error]("مشکلی در سیستم بوجود آمده است", "پیام سیستم", tosterOption);
    alert("ERROR");
}
