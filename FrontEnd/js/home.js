$(document).ready(function(){

    $('.parallax').parallax();
    $('.carousel').carousel();

    document.getElementById("btn").addEventListener("click", () => {
        window.location.href = "checkout.html";
    });
});

setInterval(function() {
    $('.carousel').carousel('next');
}, 4000);

$('.carousel.carousel-slider').carousel({
    fullWidth: true
});       
