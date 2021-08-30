app.controller('CommentsController', ['$scope', '$window', '$timeout', 'CommonFactory',
function ($scope, $window, $timeout, CommonFactory) {
    var url = '/Comments/';
    $scope.Comments = new Object();
    $scope.CommentList = new Object();
       $scope.showCommentlist = function(a,b)
       {
           var action = url + 'GetCommentList';
           $scope.Comments.SUBJECTID = a;
           $scope.Comments.LESSONID = b;
           var datasend = JSON.stringify({
               data: $scope.Comments
           });
           CommonFactory.PostDataAjax(action, datasend, function (response) {
               if (response) {
                   if (response.rs) {
                       $scope.CommentList = response.commentList;
                   }
                   else {
                       alert('Không nhận được phản hồi từ máy chủ');
                   }
               } else {
                   alert('Không nhận được phản hồi từ máy chủ');
               }
           });
       }

       $scope.Add = function () {
           if (!$scope.Comments.COMMENT) {
               alert("Nội dung không được để trống!");
           }
           var action = url + 'Add';
           var datasend = JSON.stringify({
               data: $scope.Comments
           });
           CommonFactory.PostDataAjax(action, datasend, function (response) {
               if (response) {
                   if (response.rs) {
                       $scope.Comments.COMMENT ="";
                       $scope.showCommentlist($scope.Comments.SUBJECTID, $scope.Comments.LESSONID);
                   }
                   else {
                       alert('Không nhận được phản hồi từ máy chủ');
                   }
               } else {
                   alert('Không nhận được phản hồi từ máy chủ');
               }
           });
       }
       $scope.doSomething = function () {
           $scope.Add();
       }
   }]);
app.controller('SubjectController', ['$scope', '$window', '$timeout', 'CommonFactory',
function ($scope, $window, $timeout, CommonFactory) {
    var url = '/Subjects/';
    $scope.SUBJECT = new Object();
    $scope.SaveSubject = function () {
        var action = url + "Add";
        if (!$scope.SUBJECT.NAME) {
            swal({
                title: "Thông Báo",
                text: "Nhập tên môn học",
                icon: "error",
                button: "OK",
            });
            return;
        }
        var datasend = JSON.stringify({
            sub: $scope.SUBJECT
        });
        CommonFactory.PostDataAjax(action, datasend, function (response) {
            if (response) {
                if (response.rs) {
                    swal({
                        title: "Thông Báo",
                        text: response.msg,
                        icon: "success",
                        button: "OK",
                    }).then(function () {
                        window.location.href = url + "Index";
                    });
                }
                else {
                    swal({
                        title: "Thông Báo",
                        text: response.msg,
                        icon: "error",
                        button: "OK",
                    });
                    return;
                }
            } else {
                alert('Không nhận được phản hồi từ máy chủ');
            }
        });
    }
}]);
$(function () {
    $('#jstree').jstree({
        "plugins": ["search", "wholerow"],
        'core': {
            'data': {
                'url': function (node) {
                    return node.id === '#' ? "/Subjects/GetRoot" : "/Subjects/GetChildren/" + node.id;

                },
                'data': function (node) {
                    return { 'id': node.id };
                }
            }
        }
    });
    $('#jstree').on('changed.jstree', function (e, data) {

        if (data.node.parent !== "#") {
            variable1 = data.node.original.id;
            variable2 = data.node.original.parent; 
            $('#overlay').show();
            $.ajax({
                url: "/Lessons/GetFileByFolderID",
                type: "GET",
                data: {id: data.node.id},
                success: function (data) {
                    $('#overlay').hide();
                    $(".content-wrapper").first().html(data);
                    $("#comment-content").css("display", "block");
                    angular.element(document.getElementById('YourElementId')).scope().showCommentlist(variable1, variable2);
                },
                error: function (error) {
                    $('#overlay').hide();
                    console.log(error);
                }
            });
        }
    });

    $('#jstree').bind('hover_node.jstree', function () {
        var bar = $(this).find('.jstree-wholerow-hovered');
        bar.css('height',
            bar.parent().children('a.jstree-anchor').height() + 'px');
    });
    $('#jstree-user').jstree({
        "plugins": ["search", "wholerow"],
        'core': {
            'data': {
                'url': function (node) {
                    // Level 0
                    if (node.parents.length === 0)
                    {
                        return "/Reports/GetRoot";
                    }

                    // Level 1
                    if (node.parents.length === 1)
                    {
                        return "/Reports/GetChildren/" + node.id;
                    }

                    // Level 2
                    if (node.parents.length === 2) {
                        return "/Reports/GetChildrenSubject/" + node.id;
                    }

                    // Level 3
                    if (node.parents.length === 3)
                    {
                        return "/Reports/GetChildrenLesson/" + node.id;
                    }
                    

                },
                'data': function (node) {
                    return { 'id': node.id };
                }
            }
        }
    });

    $('#jstree-user').on('changed.jstree', function (e, data) {
        if (data.node.parent !== "#") {
            $('#overlay').show();
            $.ajax({
                url: "/Lessons/GetFileByFolderID",
                type: "GET",
                data: { id: data.node.id },
                success: function (data) {
                    $('#overlay').hide();
                    $(".content-wrapper").html(data);
                },
                error: function (error) {
                    $('#overlay').hide();
                    console.log(error);
                }
            });
        }
    });

    $('#jstree-user').bind('hover_node.jstree', function () {
        var bar = $(this).find('.jstree-wholerow-hovered');
        bar.css('height',
            bar.parent().children('a.jstree-anchor').height() + 'px');
    });


});
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
        var elementDataList = $("#info-student tbody tr td")
        var subject = $("#select-subject").val();

        if (subject === "-1")
        {
            swal({
                title: "Thông Báo!",
                text: "Vui lòng chọn môn học",
                icon: "error",
                button: "OK",
            });
            return;
        }
        var data = [];
        for(var item of elementDataList)
        {
            var eleCheck = item.querySelector('i');
            if (eleCheck) {
                var classList = eleCheck.classList;
                if (classList.contains("fa-check-square")) {
                    var prefix = "";
                    if (item.classList.contains('del-student')) {
                        prefix = "D_" + item.dataset.id + "_" + subject;
                    } else if (item.classList.contains('copy-student')) {
                        prefix = "C_" + item.dataset.id + "_" + subject;
                    }
                    data.push(prefix);
                    prefix = "";
                }
            }
        }
        if (data.length === 0)
        {
            swal({
                title: "Thông Báo!",
                text: "Vui lòng chọn học sinh",
                icon: "error",
                button: "OK",
            });
            return;
        }

        var dataSend =  JSON.stringify({
                data:data,
            });
        var action = "/ManagerStudents/AddStudentToSubject";
        $.ajax({
            url: action,
            type: "POST",
            data: dataSend,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                swal({
                    title: "Thông Báo!",
                    text: data,
                    icon: "success",
                    button: "OK",
                })
                .then(function () {
                    location.reload();
                });
            },
            error: function (error) {

            }
        });
    });
});