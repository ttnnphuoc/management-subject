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
            $.ajax({
                url: "/Lessons/LoadFileInFolder",
                type: "GET",
                data: {id: data.node.id},
                success: function (data) {
                    window.location.href = "/Lessons/GetFileByFolderID/" + data;
                },
                error: function (error) {
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
});