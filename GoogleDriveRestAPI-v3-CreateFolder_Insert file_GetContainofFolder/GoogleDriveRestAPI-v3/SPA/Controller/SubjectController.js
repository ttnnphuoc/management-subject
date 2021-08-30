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