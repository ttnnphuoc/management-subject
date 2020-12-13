$(function () {
    $('#btn-info').on('click', function () {
        $.ajax({
            url: "/ManagerStudents/GetUserByRole",
            type: "GET",
            success: function (data) {
                var html = "";
                for(var item of data)
                {
                    html += "<tr>" + 
                                    "<td class='del-student pointer' data-id='" + item.ID + "'><i class='far fa-square'></i></td>" +
                                    "<td class='copy-student pointer' data-id='" + item.ID + "'><i class='far fa-square'></i></td>" +
                                    "<td>"+ item.Fullname + "</td>"
                }
                $("#info-student tbody").html("");
                $("#info-student tbody").html(html);
                var classCheck = "fa-check-square";

                $("td.del-student").on('click', function (event) {
                    var currentElement = event.currentTarget;
                    var elementCheck = currentElement.querySelector('i');
                    if (elementCheck)
                    {
                        var className = elementCheck.classList;
                        if (className.contains("fa-square")) {
                            elementCheck.classList.remove("fa-square");
                            elementCheck.classList.add(classCheck);
                            var elementCopy = $(event.currentTarget).closest("tr").find('.copy-student');
                            if (elementCopy)
                            {
                                elementCheck = elementCopy[0].querySelector('i');
                                className = elementCheck.classList;
                                if (className.contains(classCheck))
                                {
                                    elementCheck.classList.remove(classCheck);
                                    elementCheck.classList.add("fa-square");
                                }
                            }
                        }
                        else if (className.contains(classCheck)) {
                            elementCheck.classList.remove(classCheck);
                            elementCheck.classList.add("fa-square");
                        }
                    }
                });

                $("td.copy-student").on('click', function () {
                    var currentElement = event.currentTarget;
                    var elementCheck = currentElement.querySelector('i');
                    if (elementCheck) {
                        var className = elementCheck.classList;
                        if (className.contains("fa-square")) {
                            elementCheck.classList.remove("fa-square");
                            elementCheck.classList.add(classCheck);


                            var elementCopy = $(event.currentTarget).closest("tr").find('.del-student');
                            if (elementCopy) {
                                elementCheck = elementCopy[0].querySelector('i');
                                className = elementCheck.classList;
                                if (className.contains(classCheck)) {
                                    elementCheck.classList.remove(classCheck);
                                    elementCheck.classList.add("fa-square");
                                }
                            }
                        }
                        else if (className.contains(classCheck)) {
                            elementCheck.classList.remove(classCheck);
                            elementCheck.classList.add("fa-square");
                        }
                    }
                });
            },
            error: function (error) {
                console.log(error);
            }
        });
    });
    $('#btn-go').on('click', function () {
        alert("test");
    })
});