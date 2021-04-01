app.factory('CommonFactory', ['$timeout', function ($timeout) {
    var service = {};

    service.PostDataAjax = function (url, data, callBack, timeout) {
        if (!timeout)
            timeout = 60000;
        $.ajax({
            url: url,
            type: "POST",
            timeout: timeout,
            cache: true,
            crossDomain: true,
            contentType: "application/json; charset=utf-8;",
            dataType: "json",
            data: data,
            processData: true,
            beforeSend: function () { },
            async: true,
            tryCount: 0,
            retryLimit: 3,

            success: function (response) {
                if (response) {
                    $timeout(function () {
                        callBack(response);
                    }, 10);
                } else {
                    $timeout(callBack, 10);
                }
            },

            error: function (error) {
                $timeout(callBack, 10);
            }
        });
    };
    return service;
}]);
app.filter('dateFormat', function ($filter) {
    return function (input, format) {
        if (!input) { return ""; }
        var temp = input.replace(/\//g, "").replace("(", "").replace(")", "").replace("Date", "").replace("+0700", "").replace("-0000", "");

        var resultDate = new Date(+temp);
        return $filter("date")(resultDate, format);
    };
});
app.directive('myEnter', function () {
    return function (scope, element, attrs) {
        element.bind("keydown keypress", function (event) {
            if (event.which === 13) {
                scope.$apply(function () {
                    scope.$eval(attrs.myEnter);
                });

                event.preventDefault();
            }
        });
    };
});