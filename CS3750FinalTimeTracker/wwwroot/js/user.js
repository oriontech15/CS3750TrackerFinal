var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/user",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [

            { "data": "userName", "width": "15%" },
            { "data": "startTime", "width": "15%" },
            { "data": "endTime", "width": "15%" },
            { "data": "totalTime", "width": "15%" },
            { "data": "description", "width": "20%" },
            { "data": "group.name", "width": "15%" }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%",
        "order": [[2, "asc"]]
    });
}