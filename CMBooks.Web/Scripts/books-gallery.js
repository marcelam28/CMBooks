function filter(genre) {
    AjaxHelper.getViewWithoutData("/Home/Filter?genre=" + genre,
        function (result) {
            $("#partial-view").html(result);
        },
        function (err) {
        }
    )
}