
async function LoadListProduct(id = undefined) {
    $("#ProductTableRow").html($loading);

    $result = await AjaxCall("GET", '/Admin/Product/GetListProduct' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#ProductTableRow").html($result);
    //$("ul.pagination li").removeAttr("disabled");
    //$(`ul.pagination li:nth-child(${pageindex})`).removeAttr("disabled");
}
LoadListProduct();


async function LoadAddEditProduct(id = undefined) {
    $("#ContentModal").html($loading);
    console.log(id);
    if (id == undefined) {
        $result = await AjaxCall("GET", '/Admin/Product/GetAddProduct' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);

    }
    else {
        $result = await AjaxCall("GET", '/Admin/Product/GetEditProduct' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    }
    $("#ContentModal").html($result);

}

async function LoadDeleteGift(id) {
    $("#DivResult").html($loading);
    $result = await AjaxCall("GET", `/Gift/DeleteGift?iD=${id}`, $TempObject, 0);
    $("#DivResult").html($result);
    $("#currentId").val(id);
}


var ajaxResult = $("#AjaxResults");
var onBegin = function () {
    ajaxResult.html($loading);
}

var onSuccess = function (context) {
    if (context == "OK") {
        $('#BasicModal').modal('hide');
        LoadListProduct();
    } else if (context == "Unauthorized") {
        alertUnauthorized();
    }
    else if (context == "NotModified") {
        Swal.fire({
            type: 'error',
            title: 'پیغام سیستم',
            text: "لطفا دسته بندی محصول را انتخاب کنید !",
            confirmButtonColor: '#3085d6',
            confirmButtonText: 'باشه !'
        })
    }
}

var onFailed = function (xhr) {
    //toastr[error]("مشکلی در سیستم بوجود آمده است", "پیام سیستم", tosterOption);
    alert("ERROR");
}

async function ConfirmDelete(id) {
    Swal.fire({
        title: 'آیا از حذف این محصول اطمینان دارید؟',
        text: " این عمل غیر قابل بازگشت میباشد !",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'تایید!',
        cancelButtonText: 'لغو',
    }).then(async (result) => {
        if (result.value) {
            $("#DivResult").html($loading);
            $result = await AjaxCall("GET", `/Admin/Product/ConfirmDelete?iD=${id}`, $TempObject, 0);
            $("#DivResult").html($result);
            $("#currentId").val(id);
            LoadListProduct();
        }
    });
}