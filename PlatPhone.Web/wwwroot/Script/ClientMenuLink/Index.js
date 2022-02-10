async function LoadListCML(id = undefined) {
    $("#CMLTableRow").html($loading);
    $TempObject = {};
    $result = await AjaxCall("GET", '/Admin/ClientMenuLink/GetListCML' + (id === undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#CMLTableRow").html($result);
    console.log($result);
}
LoadListCML();
//-------------
async function LoadAddEditCML(id = undefined) {
    $("#ContentModal").html($loading);
    console.log(id);
    if (id == undefined)
        $result = await AjaxCall("GET", '/Admin/ClientMenuLink/GetAddCML' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    else
        $result = await AjaxCall("GET", '/Admin/ClientMenuLink/GetEditCML' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#ContentModal").html($result);

    //CKEDITOR.replace('ContentRanderingPage');


}
//-------------
async function LoadDetailCML(id = undefined) {
    $("#showinf").html($loading);
    console.log(id);
    $result = await AjaxCall("GET", '/Admin/ClientMenuLink/GetDisplayCML' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#showinf").html($result);

}
//-------------
function ConfirmDelete(id) {
    Swal.fire({
        title: 'آیا از حذف این منو اطمینان دارید؟',
        text: " این عمل غیر قابل بازگشت میباشد !",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'تایید!',
        cancelButtonText: 'لغو',
    }).then(async (result) => {
        if (result.value) {
            $("#CMLTableRow").html($loading);
            $result = await AjaxCall("GET", `/Admin/ClientMenuLink/ConfirmDelete?id=${id}`, $TempObject, 0);
            $("#CMLTableRow").html($result);
            $("#currentid").val(id);
            LoadListCML();
        }
    })
}
//-------------
var ajaxResult = $("#AjaxResults");
var onBegin = function () {
    ajaxResult.html($loading);
}
//-------------
var onSuccess = function (context) {
    if (context == "OK") {
        $('#BasicModal').modal('hide');
        LoadListCML();
    }
}
//-------------
var onFailed = function (xhr) {
    alert("ERROR");
}
//-------------