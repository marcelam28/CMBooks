function register() {
    debugger;
    EasyLoading.show();
    var firstName = $('#FirstName').val();
    var lastName = $('#lastName').val();
    var birthdate = $('#datepicker').val();
    var email = $('#email').val();
    var password = $('#password').val();

    var formData = {
        "FirstName": firstName,
        "LastName": lastName,
        "DateOfBirth": birthdate,
        "Email": email,
        "Password": password
    };
    AjaxHelper.post(
        'User/CreateUser',
        formData,
        function (response) {
            debugger;
            EasyLoading.hide();
            if (response.Success == true) {
                if (response.StatusCode == 1) {
                    debugger;
                    toastr.success("Your account was created!");
                    setTimeout(function () { window.location = "http://localhost:62402/Account/Index" }, 1000);
                    $('#FirstName').val("");
                    $('#lastName').val("");
                    $('#email').val("");
                    $('#password').val("");
                }
            }
            else {
                if (response.StatusCode == -6) {
                    toastr.error("Error in creating your account!");
                }
                if (response.StatusCode == -5) {
                    toastr.error("You didn't complete the form correctly!");
                }
            }
        },
        function () {
            debugger;
            EasyLoading.hide();
            toastr.error("Unable to register!");
        }
    )
}
