function DodajAjaxEvente() {
    $("button[ajax-poziv='da']").click(function (event) {
        $(this).attr("ajax-poziv", "dodan");

        event.preventDefault();
        var urlZaPoziv = $(this).attr("ajax-url");
        var divZaRezultat = $(this).attr("ajax-rezultat");

        $.get(urlZaPoziv, function (data, status) {
            $("#" + divZaRezultat).html(data);
        });
    });

    $("a[ajax-poziv='da']").click(function (event) {
        $(this).attr("ajax-poziv", "dodan");
        event.preventDefault();
        var urlZaPoziv1 = $(this).attr("ajax-url");
        var urlZaPoziv2 = $(this).attr("href");
        var divZaRezultat = $(this).attr("ajax-rezultat");
        var xx = document.getElementById("ajax-rezultat");
        

        var urlZaPoziv;

        if (urlZaPoziv1 instanceof String)
            urlZaPoziv = urlZaPoziv1;
        else
            urlZaPoziv = urlZaPoziv2;

        $.get(urlZaPoziv, function (data, status) {
            

            $("#" + divZaRezultat).html(data).css({ "display": "block" });
        });
  
    });

   

    $("form[ajax-poziv='da']").submit(function (event) {
        $(this).attr("ajax-poziv", "dodan");
        event.preventDefault();
        var urlZaPoziv1 = $(this).attr("ajax-url");
        var urlZaPoziv2 = $(this).attr("action");
        var divZaRezultat = $(this).attr("ajax-rezultat");

        var urlZaPoziv;
        if (urlZaPoziv1 instanceof String)
            urlZaPoziv = urlZaPoziv1;
        else
            urlZaPoziv = urlZaPoziv2;

        var form = $(this);

        $.ajax({
            type: "POST",
            url: urlZaPoziv,
            data: form.serialize(),
            success: function (data) {
                $("#" + divZaRezultat).html(data);
            }
        });
    });
    
}
function Notifikacije() {
    $.ajax({
        url: "/Notifikacija/GetBrojNotifikacija",
        type: "GET",
        data: { KorisnikID: $("#hiddenID").val() }, 
        success: function (result) {
            $("#Notifikacija").html("<span>" + result + "</span>");
        }
    })

    $.ajax({
        url: "/Notifikacija/Index",
        type: "GET",
        data: { LogiraniKorisnikID: $("#hiddenID").val() },
        success: function (result) {
            $("#NotifikacijaText").html("<html>"+result+"</html>");
        }
    })
    

   
    
}



$(document).ready(function () {
    
    DodajAjaxEvente();
    Notifikacije();
    
});

$(document).ajaxComplete(function () {
    
    DodajAjaxEvente();
});


window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        document.getElementById("BtnVrh").style.display = "block";
    } else {
        document.getElementById("BtnVrh").style.display = "none";
    }
}


function VrhFunkcija() {
    document.body.scrollTop = 0; 
    document.documentElement.scrollTop = 0; 
} 

function prikaziDiv(y) {
    var x = document.getElementById(y);
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
    
}

function sakrijDiv(y) {
    var x = document.getElementById(y);
   
        x.style.display = "none";
    
}
function change() 
{
    var elem = document.getElementById("btnFilter");
    if (elem.value == "Prikazi filtere") { elem.innerHTML = "Sakrij filtere"; elem.value = "Sakrij filtere"; }
   
    else{
        elem.innerHTML = "Prikazi filtere"; elem.value = "Prikazi filtere";
    }
}

$(document).ready(function () {
    $('#btnFilter').click(function () {
        $('#FILTERI').toggle("slow");
        change();
    });
})



function klikx () {
 
    window.scrollTo(0, $('#divRez1').offset().top);
}

function KLIK() {
    window.scrollTo(0, $('#divRez2').offset().top);
}



function scroll_to_Bott(div) {
    

    $('html, body').animate({
        scrollTop: $('footer').offset().top
        
    }, 'slow');

}