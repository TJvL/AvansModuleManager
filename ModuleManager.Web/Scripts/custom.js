/* 
 * Controller:  Module/Overview 
 * View:        Module/Overview
 */
$(function () {
    // THIS FOR ALL OVERVIEWS
    $(".item").on("click", function () {
        window.location = $(this).data("href");
    });

    //
    $('.dropdown-menu').on('click', function (e) {
        if ($(this).hasClass('dropdown-menu-form')) {
            e.stopPropagation();
        }
    });

});

// Select2 - Module Edit
$(function () {
    $("#werkvorm").select2({
        placeholder: "Werkvorm"
    });
});

// Modal - Curriculum beheer
$(function () {
    // Module Add
    $('#module-add').on('show.bs.modal', function (e) { });
});

// Select2 - Curriculum beheer
$(function () {

    // Module Add
    $("#ModuleAddMajor").select2({
        placeholder: "Majors"
    });
    $("#ModuleAddMinor").select2({
        placeholder: "Minors"
    });
    $("#ModuleAddFase").select2({
        placeholder: "Fase"
    });
});



/*
 * TEMP
 * TEMP: BackgroundColor in Header
 * TEMP
 */
$(function () {
    var para1 = $(location).prop('pathname').split('/')[1];
    var para2 = $(location).prop('pathname').split('/')[2];

    switch (para1) {
        case "":
        case "Home":
        case "Module":
            if (para2 === "Overview_Teacher_Temp" || para2 === "Details_Teacher_Temp" || para2 === "Edit") {
                $("#header").css('background', '#428BCA');
            } else {
                $("#header").css('background', '#FF004B');
            }
            break;
        case "Admin":
            $("#header").css('background', '#212121');
            break;
        default:
            $("#header").css('background', '#FF004B');
            break;
    }
});
/*
 * TEMP
 * TEMP: BackgroundColor in Header
 * TEMP
 */