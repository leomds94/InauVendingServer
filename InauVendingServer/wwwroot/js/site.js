var navOpened = false;

function openNav() {
    document.getElementById("sidenavs").style.width = "250px";
    document.getElementById("main").style.marginLeft = "250px";
    document.body.style.backgroundColor = "rgba(0,0,0,0.4)";
    navOpened = true;
}

function closeNav() {
    document.getElementById("sidenavs").style.width = "0";
    document.getElementById("main").style.marginLeft = "0";
    document.body.style.backgroundColor = "white";
    navOpened = false;
}

$("#opennav").click(function (e) {
    if (!navOpened) {
        openNav();
    }
    else {
        closeNav();
    }
    e.stopImmediatePropagation();
    e.preventDefault();
});

$("#main").click(function () {
    if (navOpened) {
        closeNav();
    }
});

//$('.money').priceFormat();
$('.money').mask("R$" + " 000.000,00", { reverse: true, placeholder: "R$0,00" });
$('.date_time').mask('00/00/0000 00:00', { placeholder: "__/__/____ __:__" });


$(document).on('change', '#OwnerId', function () {
    var value = $(this).val();
    if (value == "addNovo") {

    }
})

$(document).on('blur', '#prodImage', function (event) {
    event.preventDefault();

    // Pega o elemento de "impressão"
    $('#result').html(
        // Define o HTML dele como um novo element
        // img com src do valor do input
        $('<img />').attr('src', this.value)
    );

});