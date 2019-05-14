function addBook() {
	debugger;
	EasyLoading.show();
	var title = $("#title").val();
	var author = $("#author").val();
	var publicationDate = $('#datepicker').val();
	var pages = $("#pages").val();
	var description = $("#description").val();
	var genre = $('#genre').val();
	var photo = document.getElementById("image-file").files[0];

	var formData = new FormData();
	formData.append("Title", title);
	formData.append("Author", author);
	formData.append("PublicationDate", publicationDate);
	formData.append("Pages", pages);
	formData.append("Description", description);
	formData.append("Genre", genre);
	formData.append("PictureUrl", photo);

	AjaxHelper.postFile("Book/CreateBook",
		formData,
		function (response) {
			EasyLoading.hide();
			if (response.Success == true) {
				if (response.StatusCode == 1) {
					toastr.success("Book added successfully!");
					$("#add-book").modal('hide');
					$("#title").val('');
					$("#author").val('');
					$('#datepicker').val('');
					$("#pages").val('');
					$("#description").val('');
					$('#genre').val('');

				}
			}
			else {
				if (response.StatusCode == -6) {
					toastr.error("Error adding book!");
				}
			}
		},
		function () {
			EasyLoading.hide();
			toastr.error("Unable to add book!");
		}
	)
}