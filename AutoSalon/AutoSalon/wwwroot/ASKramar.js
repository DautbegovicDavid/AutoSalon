function DodajAjaxEvente() {
    
    $("a[ajax-poziv='da']").click(function (event) {
        $(this).attr("ajax-poziv", "dodan");
        event.preventDefault();
        var urlPoziv1 = $(this).attr("ajax-url");
        var urlPoziv2 = $(this).attr("href");
        var divRez = $(this).attr("ajax-rezultat");

        var urlPoziv;
        if (urlPoziv1 instanceof String)
            urlPoziv = urlPoziv1;
        else urlPoziv = urlPoziv2;
        $.get(urlPoziv, function (data, status) {
            $("#" + divRez).html(data);
        });

            
    });

  
}


$(document).ready(function () {
    DodajAjaxEvente();
});

$(document).ajaxComplete(function () {
    DodajAjaxEvente();
});