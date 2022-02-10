let
    $ContactFirstName = $('#txtContactFirstName'),
    $ContactLastName = $('#txtContactLastName'),
    $ContactEmail = $('#txtContactEmail'),
    $ContactMessage = $('#txtContactMessage');

$('#btnContact').on('click', function (e) {
    option = [];
    option.push({ title: "position", value: "topLeft" });
    option.push({ title: "rtl", value: true });
    option.push({ title: "id", value: "warning" });


    if (!$ContactFirstName.val() &&
        !$ContactLastName.val() &&
        !$ContactEmail.val() &&
        !$ContactMessage.val()) {

        iziTostCall($resource["Warning"], $resource["PleaseFillAllTheInputs"], "5000","yellow", option);
        return;
    }

    if (!validateEmail($ContactEmail.val())) {
        iziTostCall($resource["Warning"], $resource["EmailIsNotValid"], "5000", "yellow", option);
        return;
    }

    var record = {
        FirstName: $ContactFirstName.val(),
        LastName: $ContactLastName.val(),
        Email: $ContactEmail.val(),
        Message: $ContactMessage.val(),
        ID: -1
    };
    $.ajax({
        url: '/api/ContactUsMessages/Insert',
        type: 'POST',
        data: record,
        success: function (response) {
            if (response.success) {        
                console.log($resource["YourEmailHasBeenSentSuccessfully"]);
                iziTostCall($resource["Successful"], $resource["YourEmailHasBeenSentSuccessfully"], "5000", "green", option);
                clearForm();
            }
            else {          
                iziTostCall($resource["Error"], $resource["ThereIsAProblemWithTheSystem"], "5000", "red", option);
            }
        }
    });
});

function clearForm() {
    $ContactFirstName.val('');
    $ContactLastName.val('');
    $ContactEmail.val('');
    $ContactMessage.val('');
}

function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}
