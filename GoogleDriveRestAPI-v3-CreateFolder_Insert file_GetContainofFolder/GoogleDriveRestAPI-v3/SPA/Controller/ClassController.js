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