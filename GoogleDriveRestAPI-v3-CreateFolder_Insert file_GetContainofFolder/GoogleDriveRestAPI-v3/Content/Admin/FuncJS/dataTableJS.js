$(function () {
    var groupColumn = 2;
    var table = $("#example2").DataTable({
        'columnDefs': [
                { 'Visible': false, 'targets': groupColumn }
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