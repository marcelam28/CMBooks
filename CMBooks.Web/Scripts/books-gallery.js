function filter(genre) {
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

function showAddBookModal() {
    EasyLoading.show();
    $("#add-book").modal('show');
    EasyLoading.hide();
}

function deleteComment(id) {
	EasyLoading.show();
	AjaxHelper.post("Comment/DeleteComment?commentId=" + id,
		{},
		function () {
			$("#comment-container-" + id).remove();
			EasyLoading.hide();
			toastr.success("Comment deleted successfully!");
		},
		function () {
			EasyLoading.hide();
			toastr.error("An error occured when deleting the comment!");
		}
	)
}

