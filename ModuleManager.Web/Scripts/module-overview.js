var table;

$(function () {

    /* Disable closing toggle-columns on click */
    $("body").on("click", ".dropdown-menu", function (e) {
        e.stopPropagation();
    });

    init_select2();
    init_datatable();
    init_toggle_columns();
    init_select_all();

});

function init_datatable() {

    $('#modules tfoot th').each(function () {
        var title = $('#modules thead th').eq($(this).index()).text();
        $(this).html('<input class="form-control" style="width:100%;" type="text" placeholder="' + title + '" />');
    });

    /* Datatables */
    table = $("#modules").DataTable({
        dom:
            "<'row'<'col-sm-6'l><'col-sm-6 toolbar text-right'>>" +
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-6'p><'col-sm-6'i>>",
        processing: true,
        serverSide: true,
        language: {
            url: "/Scripts/dataTables.dutch.js"
        },
        ajax: {
            url: "/api/Module/GetOverview",
            type: "POST",
            data: function (d) {
                d.filter = {
                    Zoekterm: $("#Zoekterm").val(),
                    Competenties: $("#FilterCompetenties").val(),
                    Fases: $("#FilterFases").val(),
                    Leerjaar: $("#FilterLeerjaar").val(),
                    Blokken: $("#FilterBlokken").val(),
                    Tags: $("#FilterTags").val(),
                    Ec: $("#FilterEc").val(),
                    Leerlijnen: $("#FilterLeerlijnen").val()
                }
            }
        },
        columns: [
            { "data": "Icon" },
            { "data": "Naam" },
            { "data": "CursusCode" },
            { "data": "Blokken" },
            { "data": "TotalEc" },
            { "data": "FaseNamen" },
            { "data": "Verantwoordelijke" },
            { "data": "Docenten" },
            { "data": "CursusCode" },
        ],
        aoColumnDefs: [
            {
                sClass: "text-center",
                bSortable: false,
                mRender: function (data, type, full) {
                    return '<span class="fa fa-3x fa-' + data + '"></span>';
                },
                aTargets: [0]
            },
            {
                mRender: function (data, type, full) {
                    return data + "<br /><span class=\"text-muted\">" + full['Verantwoordelijke'] + ", " + full['Docenten'] + "</span>";
                },
                aTargets: [1]
            },
            {
                mRender: function (data, type, full) {
                    return data + " EC";
                },
                aTargets: [4]
            },
            {
                sClass: "text-center",
                sTitle: "<input type=\"checkbox\" id=\"checkbox-select-all\"></input>",
                mRender: function (data, type, full) {
                    return "<input type=\"checkbox\" class=\"checkbox-module\" data-export=\"data\" />";
                },
                bSortable: false,
                aTargets: [8]
            }
        ],
        order: [[1, "asc"]],
        initComplete: function () {

            $(".toolbar").append($("#toggle-columns"));
            $("#toggle-columns").show();

            init_filters();

        }
    });

}

function init_filters() {

    var api = $("#modules").dataTable().api();

    /* Search */
    $('.search-query').keyup(function () {
        table.search($(this).val()).draw();
    });
    
    /* Block */
    $("#block select").on('change', function () {
        api.column(3)
            .search($(this).val() ? '^' + $(this).val() + '$' : '', true, false)
            .draw();
    });

    /* Leerjaar */
    $("#fase select").on('change', function () {
        api.column(4)
            .search($(this).val() ? '^' + $(this).val() + '$' : '', true, false)
            .draw();
    });

    /* Set filters */
    $("#FilterTable").on("click", function (e) {
        e.preventDefault();
        $("#modules").dataTable().fnDraw();
    });

}

function init_toggle_columns() {
    /* Toggle columns */
    $(".toggle").on("click", function (e) {

        // Get the column API object
        var column = $("#modules").dataTable().api().column($(this).data("column"))

        // Toggle the visibility
        column.visible(!column.visible());
    });
}

function init_select_all() {
    /* Select all */
    $("#modules").on("click", "#checkbox-select-all", function () {

        if ($(this).is(":checked")) {
            $('.checkbox-module').prop("checked", true);
        } else {
            $('.checkbox-module').prop("checked", false);
        }

    });
}

function init_select2() {
    $("#FilterCompetenties").select2({
        placeholder: "Competenties"
    });
    $("#FilterLeerlijnen").select2({
        placeholder: "Leerlijnen"
    });
    $("#FilterFases").select2({
        placeholder: "Fases"
    });
    $("#FilterLeerjaar").select2({
        placeholder: "Leerjaar"
    });
    $("#FilterEc").select2({
        placeholder: "EC"
    });
    $("#FilterBlokken").select2({
        placeholder: "Blokken"
    });
    $("#FilterTags").select2({
        placeholder: "Tags"
    });
}

