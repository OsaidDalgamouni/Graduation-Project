var Table;


$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    Table = $('#table1').DataTable({
        "ajax": {
            "url": "/Admin/Order/GetAll"
        },
        "columns": [
            { "data": "id", "width": "15%" },
            { "data": "orderDate", "width": "15%" },
            { "data": "applicationUser.phoneNumber", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {



                    return `<div class="btn-group" role="group"><a href="/Admin/Order/Details?id=${data}" class="mx-2 btn btn-primary">Details</a><a href="/Admin/Order/AcceptOrder?id=${data}" class="mx-2 btn btn-primary">Accept</a> <a href="/Admin/Order/Delete?id=${data}" class="mx-2 btn btn-primary">Delete</a></div>`






                },
                "width": "15%"
            }








        ]
    });


}
