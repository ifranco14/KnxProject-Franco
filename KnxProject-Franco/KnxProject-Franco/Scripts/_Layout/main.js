$(document).ready(function () {
    $(".dropdown").mouseover(function () {
        $(".dropdown-menu").show();
    })
    $(".dropdown").mouseout(function () {
        $(".dropdown-menu").hide();
    });
}); 