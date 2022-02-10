//#region Toster
let tosterOption = { positionClass: "toast-top-left", rtl: true, showMethod: "slideDown", hideMethod: "slideUp", timeOut: "5000", "closeButton": false, "progressBar": true };
let warning = "warning";
let error = "error";
let info = "info";
let success = "success";
//#endregion

let $loading = "<img src=\"/images/Icon/Loading.gif\" alt=\"در حال بارگذاری...\" />";
var $TempObject = {};

async function AjaxCall(method, url, data, type) {
    let TempData = type === 0 ? [] : type === 1 ? 0 : "";
    await $.ajax({
        method: method,
        url: url,
        data: data,   
        
        success: function (output) {
            TempData = output;
        },
        error: function (xhr) {
            TempData = null;
        }
    });
    return TempData;
}

function clearModal() {
    $("#DivResult input[type=checkbox]").attr('checked', false);
    $("#DivResult input[type=number],#DivResult input[type=password],#DivResult input[type=text]").val("");
    $("#DivResult textarea").val("");
}

function alertNotValidFile() {
    Swal.fire({
        type: 'error',
        title: 'پیغام سیستم',
        text: 'فرمت یا حجم فایل انتخاب شده مجاز نمیباشد',
    })
}

function alertUnauthorized() {
    Swal.fire({
        type: 'error',
        title: 'پیغام سیستم',
        text: 'نشست شما به پایان رسیده است،لطفا مجدد وارد حساب کاربری خود شوید',
    });
    setTimeout(function () {
        location.href = "/Account/Login";
    }, 3000)
}
function alertError() {
    Swal.fire({
        type: 'error',
        title: 'پیغام سیستم',
        text: 'مشکلی در سیتسم بوجود آمده است، لطفا مجددا صفحه را بارگذاری نمایید'
    })
}
function alertOK() {
    Swal.fire({
        type: 'success',
        title: 'پیغام سیستم',
        text: 'تغییرات با موفقیت ذخیره شد'
    })
}