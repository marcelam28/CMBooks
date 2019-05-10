﻿function filter(genre) {
	debugger
	EasyLoading.show();
    AjaxHelper.getViewWithoutData("/Home/Filter?genre=" + genre,
        function (result) {
			$("#partial-view").html(result);
			EasyLoading.hide();
        },
		function (err) {
			EasyLoading.hide();
			toastr.error("An error occured!");
        }
    )
}

function showDetailsModal(id) {
	EasyLoading.show();
	AjaxHelper.getViewWithoutData("Home/GetBookDetails?id=" + id,
		function (result) {
			$("#book-details-container").html(result);
			$("#book-details").modal('show');
			EasyLoading.hide();
		},
		function (err) {
			EasyLoading.hide();
			toastr.error("An error occured!");
		}
	)
}

//function showComments(id) {
//    EasyLoading.show();
//    AjaxHelper.getViewWithoutData("Home/GetBookComments?id=" + id,
//        function (result) {
//            $("#list-of-comments").html(result);
//            EasyLoading.hide();
//        },
//        function (err) {
//            EasyLoading.hide();
//            toastr.error("An error occured!");
//        }
//    )

//}