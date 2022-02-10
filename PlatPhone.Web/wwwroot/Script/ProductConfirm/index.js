async function LoadListProductConfirm(id = undefined) {
    $("#ProductTableRow").html($loading);
    $TempObject = {};
    $result = await AjaxCall("GET", '/Admin/ProductConfirm/LoadListProductConfirm' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#ProductTableRow").html($result);
    console.log($result);
    //$("ul.pagination li").removeAttr("disabled");
    //$(`ul.pagination li:nth-child(${pageindex})`).removeAttr("disabled");
}
LoadListProductConfirm();


async function SuccssProductConfirm(id) {
    Swal.fire({
        title: 'آیا از تایید این محصول اطمینان دارید؟',
        text: " این عمل غیر قابل بازگشت میباشد !",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'تایید!',
        cancelButtonText: 'لغو'
    }).then(async (result) => {
        if (result.value) {
            $("#ProductTableRow").html($loading);
            $result = await AjaxCall("GET", `/Admin/ProductConfirm/SuccssProductConfirm?id=${id}`, $TempObject, 0);
            $("#ProductTableRow").html($result);
            $("#currentid").val(id);
            LoadListProductConfirm();
        }
    });
}


async function FaildProductConfirm(id) {
    Swal.fire({
        title: 'آیا از رد کردن این محصول اطمینان دارید؟',
        text: " این عمل غیر قابل بازگشت میباشد !",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'رد کردن!',
        cancelButtonText: 'لغو'
    }).then(async (result) => {
        if (result.value) {
            $("#ProductTableRow").html($loading);
            $result = await AjaxCall("GET", `/Admin/ProductConfirm/FaildProductConfirm?id=${id}`, $TempObject, 0);
            $("#ProductTableRow").html($result);
            $("#currentid").val(id);
            LoadListProductConfirm();
        }
    });
}


async function DetailProductConfirm(id = undefined) {
    $("#ContentModal").html($loading);
    console.log(id);
    $result = await AjaxCall("GET", '/Admin/ProductConfirm/DetailProductConfirm' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#ContentModal").html($result);

}

async function UpdatePrice() {    
    $TempObject.price = $("input#Price").val();
    $TempObject.Id = $("input#Id").val();
    $TempObject.discount = $("input#DisCount").val();
    $result = await AjaxCall("GET", `/Admin/ProductConfirm/UpdatePrice`, $TempObject, 0);
    LoadListProductConfirm();
    $('#BasicModal').modal('hide');
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
