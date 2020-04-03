var $grid = $('#grid').isotope({
    itemSelector: '.grid-item',
    layoutMode: 'fitRows',
});

$('.sidebar-sticky ul li a').on('click', function () {
    $('.sidebar-sticky ul li a').removeClass('active');
    $(this).addClass('active');
    var filterValue = $(this).attr('data-filter');
    $grid.isotope({ filter: filterValue });

});