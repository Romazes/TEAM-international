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

function sweetClick() {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this imaginary file!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                swal("Poof! Your imaginary file has been deleted!", {
                    icon: "success",
                })
                return true;
            } else {
                swal("Your imaginary file is safe!");
                return false;
            }
        });
};