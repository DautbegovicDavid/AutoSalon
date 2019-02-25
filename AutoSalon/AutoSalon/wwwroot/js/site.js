// Write your JavaScript code.
$(function(){
    $('[data-toggle="popover"]').popover({
        placement: "bottom",
        content: function () {
            return $("notification-content").html();
        },
        html:true
    });
});

$(".alert").fadeTo(2000, 500).slideUp(900, function () {
    $(".alert").slideUp(500);
});
