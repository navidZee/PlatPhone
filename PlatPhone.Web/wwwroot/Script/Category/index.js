async function LoadListCategory(id = undefined) {
    $("#categoryTableRow").html($loading);
    $TempObject = {};
    $result = await AjaxCall("GET", '/Admin/Catgory/GetListCategory' + (id === undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#categoryTableRow").html($result);
}
LoadListCategory();


async function LoadAddCategory(id = undefined) {
    $("#ContentModal").html($loading);
    $result = await AjaxCall("GET", '/Admin/Catgory/GetAddCategory' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#ContentModal").html($result);

}
async function GetAddSubCategory(id = undefined) {
    $("#ContentModal").html($loading);
    $result = await AjaxCall("GET", '/Admin/Catgory/GetAddSubCategory' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#ContentModal").html($result);

}

function confirmdelete(id) {
    Swal.fire({
        title: 'آیا از حذف این دسته بندی اطمینان دارید؟',
        text: " این عمل غیر قابل بازگشت میباشد !",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'تایید!',
        cancelButtonText: 'لغو',
    }).then(async (result) => {
        if (result.value) {
            $("#categoryTableRow").html($loading);
            $result = await AjaxCall("GET", `/Admin/Catgory/ConfirmDelete?id=${id}`, $TempObject, 0);
            $("#categoryTableRow").html($result);
            $("#currentid").val(id);
            LoadListCategory();
        }
    });
}

var ajaxResult = $("#AjaxResults");
var onBegin = function () {
    ajaxResult.html($loading);
}

var onSuccess = function (context) {

    if (context == "OK") {
        $('#BasicModal').modal('hide');
        LoadListCategory();
    }
    else if (context === "NotAcceptable") {
        Swal.fire({
            type: 'error',
            title: 'پیام سیستم',
            text: 'فرمت فایل انتخاب شده مجاز نمیباشد (jpg-png-svg)'
        });
    }
    else if (context === "NotFound") {
        Swal.fire({
            type: 'error',
            title: 'پیام سیستم',
            text: 'لطفا تصویر دسته بندی را انتخاب نمایید'
        });
    }
}

var onFailed = function (xhr) {
    alert("ERROR");
}