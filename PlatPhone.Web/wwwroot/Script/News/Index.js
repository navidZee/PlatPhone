
async function LoadListNews() {
    $("#NewsTableRow").html($loading);
    $result = await AjaxCall("GET", '/Admin/News/GetListNews', $TempObject, 0);
    $("#NewsTableRow").html($result);
    //$("ul.pagination li").removeAttr("disabled");
    //$(`ul.pagination li:nth-child(${pageindex})`).removeAttr("disabled");
}
LoadListNews();


async function LoadAddEditNews(id = undefined) {
    $("#ContentModal").html($loading);
    console.log(id);
    if (id == undefined)
        $result = await AjaxCall("GET", '/Admin/News/GetAddNews' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    else
        $result = await AjaxCall("GET", '/Admin/News/GetEditNews' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#ContentModal").html($result);

}
async function LoadDetailNews(id = undefined) {
    $("#showinf").html($loading);
    console.log(id);
    $result = await AjaxCall("GET", '/Admin/News/GetDisplayNews' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#showinf").html($result);

}
var ajaxResult = $("#AjaxResults");
var onBegin = function () {
    ajaxResult.html($loading);
}

var onSuccess = function (context) {
    if (context == "OK") {
        $('#BasicModal').modal('hide');
        LoadListNews();
    } else if (context == "Unauthorized") {
        alertUnauthorized();
    }
}

var onFailed = function (xhr) {
    alertError();
}

async function ConfirmDelete(id) {
    Swal.fire({
        title: 'آیا از حذف این خبر اطمینان دارید؟',
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
            $result = await AjaxCall("GET", `/Admin/News/ConfirmDelete?id=${id}`, $TempObject, 0);
            $("#DivResult").html($result);
            $("#currentId").val(id);
            LoadListNews();
        }
    });
}