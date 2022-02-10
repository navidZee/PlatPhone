
async function LoadListMutimedia(multimediaType) {
    $("#MutimediaTableRow").html($loading);

    $result = await AjaxCall("GET", '/Admin/Multimedia/GetListMultimedia', $TempObject, 0);
    $("#MutimediaTableRow").html($result);
    //$("ul.pagination li").removeAttr("disabled");
    //$(`ul.pagination li:nth-child(${pageindex})`).removeAttr("disabled");
}
LoadListMutimedia(1);


async function LoadAddEditMutimedia(id = undefined, multimediaType) {
    $("#ContentModal").html($loading);

    if (id == undefined)
        $result = await AjaxCall("GET", '/Admin/Multimedia/GetAddMultimedia?multimediaType=' + multimediaType, $TempObject, 0);
    else
        $result = await AjaxCall("GET", '/Admin/Multimedia/GetEditMultimedia?id=' + id , $TempObject, 0);

    $("#ContentModal").html($result);

}

async function ConfirmDelete(id) {

    Swal.fire({
        title: 'پیغام سیستم',
        text: "آیا از حذف این رسانه اطمینان دارید؟ این عمل غیر قابل بازگشت میباشد",
        type: 'error',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        confirmButtonText: 'تایید',
        cancelButtonText: 'نمیخوام',
    }).then(async (result) => {
        if (result.value) {
            $("#ContentModal").html($loading);
            $result = await AjaxCall("GET", `/Admin/Multimedia/ConfirmDelete?id=${id}`, $TempObject, 0);
            LoadListMutimedia(2); 
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
        console.log($("input#MultimediaType"));
        LoadListMutimedia($("input#MultimediaType").val());
    
    } else if (context == "NotAcceptable") {
        alert("نوع فایل ورودی برای فایل مناسب نمیباشد");
    }
}

var onFailed = function (xhr) {
    alert("ERROR");
}