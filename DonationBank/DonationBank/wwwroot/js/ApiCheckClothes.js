var Table;


$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    Table = $('#table1').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            {
                "data":"imagePath",
                "render": function (img) {



                    return `<div class="btn-group" role="group"> <img src="${img}" width="250" height="250"></div>`






                },
                "width": "15%"
            },
            { "data": "size", "width": "15%" },
            { "data": "category", "width": "15%" },
            { "data": "description","width": "15%" },
            { "data": "applicationUser.phoneNumber","width": "15%" },
            {
                "data": "id",
                "render": function (data) {



                    return `<div class="btn-group" role="group"><a href="/Admin/Product/Accept?id=${data}" class="mx-2 btn btn-primary">Accept</a> <a onClick=Delete('/Admin/Product/Delete/${data}') class=" mx-2 btn btn-danger">Delete</a></div>`






                },
                "width": "15%"
            }








        ]
    });


}
function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'Delete',
                success: function (data) {
                    if (data.success) {
                        Table.ajax.reload();
                        toaster.success(data.message);
                    }
                    else {
                        toaster.error(data.message);
                    }
                }
            })
        }
    })

}