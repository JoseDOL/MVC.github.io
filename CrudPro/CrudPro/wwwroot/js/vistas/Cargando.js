(function () {
    $(function () {

        $('#btnEnviar').on('click', function () {
            $('#contenedor').show();
            $('#idCard').hide();
            setTimeout(function () {
                $('#contenedor').hide();
                $('#idCard').show();
            }, 8000);
        });
    });
}());