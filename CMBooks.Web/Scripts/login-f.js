function login() {
    debugger;
    EasyLoading.show();

    var email = $('#email').val().trim();
    var password = $('#password').val().trim();
    var atpos = email.indexOf("@");
    var dotpos = email.lastIndexOf(".");
    if (email == "" || password == "") 
        toastr.error("Please complete all the fields!");
    else if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= email.length) 
        toastr.error("Not a valid email address!");
    else {
        var formData = {
            "Email": email,
            "Password": password
        };
        AjaxHelper.post(
            'Account/Login',
            formData,
            function (response) {
                EasyLoading.hide();
                if (response.Success == true) {
                    if (response.StatusCode == 2) {
                        toastr.success("Logged in successfully!");
                        setTimeout(function () { window.location = "http://localhost:62402/Home/Index" }, 500);
                        $('#email').val("");
                        $('#password').val("");
                    }
                }
                else {
                    if (response.StatusCode == -4) {
                        toastr.error("There is no account with this email address!");
                    }
                    if (response.StatusCode == -7) {
                        toastr.error("Wrong password!");
                    }
                }
            },
            function () {
                EasyLoading.hide();
                toastr.error("Unable to login!");
            }
        )
    }
    EasyLoading.hide();
    }