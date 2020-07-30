jQuery.noConflict()(function ($) {
    $(document).ready(function () {
        loadTableData();
    })
})

var dataTable;

function loadTableData() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "Inventory/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "hospital.name", "width": "40%" },
            { "data": "hospital.branch", "width": "15%" },
            { "data": "quantity", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center text-white">
                        <a href="Inventory/AddInventory/${data}" class="btn btn-primary" style="cursor:pointer; width:40px">
                            <i class="fas fa-edit"></i>
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