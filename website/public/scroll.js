/* Permite un deslizado suave hacia la seccion/vista que se selecciona desde el menu de navegacion */


$(document).ready(function(){
    $("nav ul li a").click(function(e){
        e.preventDefault();
        var target = $(this).attr("href");
        $('html, body').animate({
            scrollTop: $(target).offset().top
        }, 500);
    });
});
