function register() {
    debugger;
    EasyLoading.show();
    var firstName = $('#FirstName').val().trim();
    var lastName = $('#lastName').val().trim();
    var birthdate = $('#datepicker').val();
    var email = $('#email').val().trim();
    var password = $('#password').val().trim();
    var atpos = email.indexOf("@");
    var dotpos = email.lastIndexOf(".");
    if (firstName == "" || lastName == "" || email == "" || password == "") {
        toastr.error("Please complete all the fields!");
        EasyLoading.hide();
    }
    else if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= email.length) {
        toastr.error("Not a valid email address!");
        EasyLoading.hide();
    }
    else {
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
}
