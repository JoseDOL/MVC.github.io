(function () {
    $(function () {

        $('#btn-crear').on('click', function () {
            $('#carga').show();
            setTimeout(function () {

                $('#carga').hide();
            }, 3000);
        });
    });
}());