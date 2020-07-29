jQuery.noConflict()(function ($) {
    $(document).ready(function () {
        loadTableData();
    })
})

var dataTable;

function loadTableData() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "Hospital/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "name", "width": "30%" },
            { "data": "branch", "width": "20%" },
            { "data": "city", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center text-white">
                        <a href="Hospital/Details/${data}" class="btn btn-primary" style="cursor:pointer; width:40px">
                            <i class="fas fa-eye"></i>
                        </a>
                        &nbsp;
                        <a href="Hospital/AddGroup/${data}" class="btn btn-primary" style="cursor:pointer; width:40px">
                            <i class="fas fa-edit"></i>
                        </a>
                        &nbsp;
                        <a onClick=Delete("Hospital/Delete/${data}") class="btn btn-danger" style="cursor:pointer; width:40px">
                            <i class="fas fa-trash-alt"></i>
                        </a>
                    </div>`;
                },
                "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "No Record Found!"
        },
        "width": "100%"
    })
}

function Delete(url) {
    swal({
        title: "ARE YOU SURE YOU WANT TO DELETE IT?",
        text: "YOU WILL NOT BE ABLE TO RESTORE IT!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#FF0000',
        confirmButtonText: 'Yes, delete it!'
    },
        function () {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    )
}