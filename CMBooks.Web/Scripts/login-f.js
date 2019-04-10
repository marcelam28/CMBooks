function login() {
            debugger;
    EasyLoading.show();

            var email = $('#email').val();
            var password = $('#password').val();
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
                            toastr.error("Invalid email!");
                        }
                        if (response.StatusCode == -7) {
                            toastr.error("Invalid password!");
                        }
                    }
                },
                function () {
                    EasyLoading.hide();
                    toastr.error("Unable to login!");
                }
            )
}