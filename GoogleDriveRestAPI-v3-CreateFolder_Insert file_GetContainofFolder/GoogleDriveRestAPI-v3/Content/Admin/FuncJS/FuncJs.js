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
    var groupColumn = 2;
    var table = $("#example2").DataTable({
        'columnDefs': [
                {'Visible': false, 'targets': groupColumn}
        ],
        'order': [[groupColumn, 'asc']],
        'displayLength': 25,
        'drawCallback': function (settings) {
            var api = this.api();
            var rows = api.rows({ page: 'current' }).nodes();
            var last = null;
            api.column(groupColumn, { page: 'current' }).data().each(function (group, i) {
                if (last !== group) {
                    $(rows).eq(i).before(
                        '<tr class="group"><td colspan="5">' + group + '</td></tr>'
                        );
                    last = group;
                }
            });
        }
    });
    $('#example2 tbody').on('click', 'tr.group', function () {
        var currenOrder = table.order()[0];
        if (currenOrder[0] == groupColumn && currenOrder[1] == 'asc') {
            table.order([groupColumn, 'desc']).draw();
        } else {
            table.order([groupColumn, 'asc']).draw();
        }
    });
});