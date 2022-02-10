
async function ListReportSal(id = undefined) {
    $("#ProductTableRow").html($loading);
    $TempObject = {};
    $result = await AjaxCall("GET", '/Admin/ReportSal/ListReportSal' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#ProductTableRow").html($result);
    console.log($result);
    //$("ul.pagination li").removeAttr("disabled");
    //$(`ul.pagination li:nth-child(${pageindex})`).removeAttr("disabled");
}
ListReportSal();


async function DetailReportSal(id = undefined) {
    $("#ContentModal").html($loading);
    console.log(id);
    $result = await AjaxCall("GET", '/Admin/ReportSal/DetailReportSal' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#ContentModal").html($result);

}


async function Checkout(id) {
    Swal.fire({
        title: 'آیا از تسویه این فاکتور اطمینان دارید؟',
        text: " این عمل قابل بازگشت میباشد !",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'تایید!',
        cancelButtonText: 'لغو'
    }).then(async (result) => {
        if (result.value) {
            $("#ProductTableRow").html($loading);
            $result = await AjaxCall("GET", `/Admin/ReportSal/ChekoutReportSal?id=${id}`, $TempObject, 0);
            $("#ProductTableRow").html($result);
            $("#currentid").val(id);
            ListReportSal();
        }
    });
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
