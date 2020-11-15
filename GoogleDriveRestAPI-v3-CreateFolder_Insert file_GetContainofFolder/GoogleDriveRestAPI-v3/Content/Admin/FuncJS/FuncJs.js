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
            console.log("=> selected node: " + data.node.id);
            $('#overlay').show();
            $.ajax({
                url: "/Lessons/GetFileByFolderID",
                type: "GET",
                data: {id: data.node.id},
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
            console.log("=> selected node: " + data.node.id);
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

