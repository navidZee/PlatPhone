
let $externalRegisterEmail = $(".mainWorkExternalRegister span.Email")
    , $externalRegisterUserName = $(".mainWorkExternalRegister input.UserName")
    , $externalRegisterPassword = $(".mainWorkExternalRegister input.Password");
    

$(function () {    
    iziToast.show({
        title: 'کاربر گرامی',
        message: 'پیش از ورود به سایت در سایت ثبت نام کنید',
        rtl: true,
        timeout: 100000,
        position: 'topRight',
        backgroundColor: '#02e5ae'
    });

})
async function ExternalRegister() {
    //#region  Validation
    if ($externalRegisterEmail.text().length === 0
        || $externalRegisterUserName.val().trim().length === 0
        || $externalRegisterPassword.val().trim().length === 0) {
        return 0;
    }
    else if (!validateEmail($externalRegisterEmail.text())) {
        $(".mainWorkExternalRegister .text-validation-External-Email").removeClass("text-hide");
        return 0;
    }

    //#endregion
    let userInformation = {
        "Email": $externalRegisterEmail.text(),
        "UserName": $externalRegisterUserName.val(),
        "PasswordHash": $externalRegisterPassword.val()
    };
    let result = await AjaxCall("POST", "Register?externalLogin=true", userInformation, 0);

    if (result.data === 0) {
        result.Message.toString().indexOf("Email") >= 0 ?
            $("div.text-already-External-Email").removeClass("text-hide") :
            $("div.text-already-External-UserName").removeClass("text-hide");
    } else if (result.data === 2) {
        location.href = "/ControlePanel#/BIS/Business-dashboard";
    } else if (result.data === 1) {
        location.href = "/Home/Index";

    }
}

function validateEmail(email) {
    let pattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return pattern.test(String(email).toLowerCase());
}

async function AjaxCall(method, url, data, type) {
    console.log(data);
    url = "/api/Authentication/" + url;
    let TempData = type === 0 ? [] : type === 1 ? 0 : "";
    await $.ajax({
        method: method,
        url: url,
        data: data,
        success: function (output) {
            TempData = output;
        },
        error: function () {
            alert("error");
            TempData = null;
        }
    });
    return TempData;
}
