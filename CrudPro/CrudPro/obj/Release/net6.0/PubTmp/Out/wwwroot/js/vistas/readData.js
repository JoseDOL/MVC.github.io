
const Toast = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 3000,
    timerProgressBar: true,
    didOpen: (toast) => {
        toast.addEventListener('mouseenter', Swal.stopTimer)
        toast.addEventListener('mouseleave', Swal.resumeTimer)
    }
})


$(document).ready(function () {
    $('.dpi-cell').click(function () {
        var dpiValue = $(this).text().trim();
        var tempInput = $('<input>');
        $('body').append(tempInput);
        tempInput.val(dpiValue).select();
        document.execCommand('copy');
        tempInput.remove();
        Toast.fire({
            icon: 'success',
            title: 'DPI copiado al portapapeles: ' + dpiValue
        });
    });
});