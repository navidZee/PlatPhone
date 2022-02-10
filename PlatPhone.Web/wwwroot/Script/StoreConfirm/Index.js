//function ShowOne() {
//    $.ajax({
//        url: "/Admin/Store/ShowOne",
//        type:"GET",
//        data: null,
//        success: function (response) { $("#showinf").html(response); },
//        error: function (ex) {}
//    });
//}
async function LoadListStoreConfirm(id = undefined) {
    $("#ConfirmTable").html($loading);
    $TempObject = {};
    $result = await AjaxCall("GET", '/Admin/StoreConfirmation/LoadList' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#ConfirmTable").html($result);
    console.log($result);
}
LoadListStoreConfirm();

async function DetailStoreConfirm(id = undefined) {
    $("#showinf").html($loading);
    console.log(id);
    $result = await AjaxCall("GET", '/Admin/StoreConfirmation/DetailInfo' + (id == undefined ? "" : "?id=" + id), $TempObject, 0);
    $("#showinf").html($result);

}


async function SuccssStoreConfirm(id) {
    Swal.fire({
        title: 'آیا از تایید این فروشگاه اطمینان دارید؟',
        text: " این عمل غیر قابل بازگشت میباشد !",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'تایید!',
        cancelButtonText: 'لغو'
    }).then(async (result) => {
        if (result.value) {
            $("#ConfirmTable").html($loading);
            $result = await AjaxCall("GET", `/Admin/StoreConfirmation/SuccssStoreConfirm?id=${id}`, $TempObject, 0);
            $("#ConfirmTable").html($result);
            $("#currentid").val(id);
            LoadListStoreConfirm();
        }
    });
}


async function FaildStoreConfirm(id) {
    Swal.fire({
        title: 'آیا از رد کردن این فروشگاه  مطمئن هستید؟',
        text: " این عمل غیر قابل بازگشت میباشد ! (علت رد کردن فروشگاه را برای مالک فروشگاه بنویسید)" ,
        type: 'warning',
        input: 'text',
     //   showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'تایید!',
        cancelButtonText: 'لغو'
    }).then(async (result) => {
           console.log(result);

        $("#ConfirmTable").html($loading);
        $result = await AjaxCall("GET", `/Admin/StoreConfirmation/FaildStoreConfirm?id=${id}&note=${result.value}`, $TempObject, 0);
            $("#ConfirmTable").html($result);
            $("#currentid").val(id);
            LoadListStoreConfirm();
    });
}

