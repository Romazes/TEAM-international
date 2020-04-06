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
(function () {
    'use strict';
    window.addEventListener('load', function () {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName('needs-validation');
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();

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