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
                    //window.location.href = "/Lessons/GetFileByFolderID/" + data;
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
});