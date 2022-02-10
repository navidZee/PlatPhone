let $mainWorkLogin = $(".mainWorkLogin"), $mainWorkRegister = $(".mainWorkRegister");
let $loginEmail = $(".mainWorkLogin input.Email"), $loginPassword = $(".mainWorkLogin input.Password"), $rememberMe = $("#rememberMe");
let $registerEmail = $(".mainWorkRegister input.Email"), $registerPassword = $(".mainWorkRegister input.Password");
var $resource;
var language = $("input#userLang").val();
var direction = $("input#userDir").val();


$(function () {
    $.getJSON(`/pages/core/models/resources/${language}.json`, function (result) {
        $resource = result;
    });
});


function validateEmail(email) {
    let pattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return pattern.test(String(email).toLowerCase());
}

function clear() {
    $(".mainWorkLogin .input-group input,.mainWorkRegister .input-group input ").val("");
}

function changeAuth(status) {
    clear();

    if (!status) {

        $(".register-section-Content").removeClass('fadeInLeft animated').addClass('fadeInLeft animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
            $(this).removeClass('fadeInLeft animated');
        });

        $(".register-section-slider").removeClass('fadeInRight animated').addClass('fadeInRight animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
            $(this).removeClass('fadeInRight animated');
        });

        $(".login-section-slider").removeClass('fadeOutLeft animated').addClass('fadeOutLeft animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
            $(this).removeClass('fadeOutLeft animated');
            $('.mainWorkRegister').show();
        });

        $(".login-section-Content").removeClass('fadeOutRight animated').addClass('fadeOutRight animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
            $(this).removeClass('fadeOutRight animated');
            $('.mainWorkLogin').hide();
        });

    } else {

        $(".login-section-slider").removeClass('fadeInLeft animated').addClass('fadeInLeft animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
            $(this).removeClass('fadeInLeft animated');
        });

        $(".login-section-Content").removeClass('fadeInRight animated').addClass('fadeInRight animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
            $(this).removeClass('fadeInRight animated');
        });

        $(".register-section-Content").removeClass('fadeOutLeft animated').addClass('fadeOutLeft animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
            $(this).removeClass('fadeOutLeft animated');
            $('.mainWorkLogin').show();
        });

        $(".register-section-slider").removeClass('fadeOutRight animated').addClass('fadeOutRight animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
            $(this).removeClass('fadeOutRight animated');
            $('.mainWorkRegister').hide();
        });


    }
}

function iziTostCall(title, message, timeout, color, options) {
    var prop = { title: title, message: message, timeout: timeout, color: color };
    $.each(options, function (key, item) { prop[options[key].title] = options[key].value; });
    iziToast.show(prop);
}

$("#LoginForm").submit(function () {
    let option = [];
    //#region  Validation
    if ($loginEmail.val().trim().length === 0 || $loginPassword.val().trim().length === 0) {
        option = [];
        option.push({ title: "position", value: "topLeft" });
        option.push({ title: "rtl", value: direction});
        option.push({ title: "id", value: "warning" });
        iziTostCall($resource["Warning"], $resource["PleaseCompleteAllFields"], "5000", 'yellow', option);
        return false;
    }
    else if (!validateEmail($loginEmail.val())) {
        option = [];
        option.push({ title: "position", value: "topLeft" });
        option.push({ title: "rtl", value: direction});
        iziTostCall($resource["Warning"], $resource["TheEmailEnteredIsNotValid"], "5000", 'yellow', option);
        return false;
    }
    return true;
    //#endregion
});



$("#RegisterForm").submit(function () {
    let option = [];
    //#region  Validation
    if ($registerEmail.val().trim().length === 0 || $registerPassword.val().trim().length === 0) {
        option = [];
        option.push({ title: "position", value: "topRight" });
        option.push({ title: "rtl", value: direction});
        option.push({ title: "id", value: "warning" });
        iziTostCall($resource["Warning"], $resource["PleaseCompleteAllFields"], "5000", 'yellow', option);
        return false;
    }
    else if (!validateEmail($registerEmail.val())) {
        option = [];
        option.push({ title: "position", value: "topRight" });
        option.push({ title: "rtl", value: direction});
        iziTostCall($resource["Warning"], $resource["TheEmailEnteredIsNotValid"], "5000", 'yellow', option);
        return false;
    }
    return true;
    //#endregion
});

function comeingSoon() {
    option = [];
    option.push({ title: "position", value: "topLeft" });
    option.push({ title: "rtl", value: direction});
    option.push({ title: "id", value: "warning" });
    iziTostCall($resource["Attention"], $resource["ComeingSoon"], "5000", 'yellow', option);
}