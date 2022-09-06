let skip = 6;
let coursesCount = $("#coursescount").val();
$(document).on("click", "#loadmorebtn", function () {
    $.ajax({
        url: "/Courses/CourseLoad",
        type: "get",
        data: {
            "skip": skip
        },
        success: function (response) {
            $("#mycourse").append(response);
            skip += 6;
            if (skip >= coursesCount) {
                $("#loadmorebtn").remove()
            }
        }
    });
});