document.getElementById("FechaNacimiento").addEventListener("change", function () {
    // Cálculo de la edad
    var birthDate = new Date(this.value);
    var today = new Date();
    var age = today.getFullYear() - birthDate.getFullYear();
    document.getElementById("Edad").value = age;
});

(function () {
    $(function () {

        $('#btnActualizar').on('click', function () {
            $('#contenedor').show();
            $('#idCard').hide();
            setTimeout(function () {
                $('#contenedor').hide();
                $('#idCard').show();
            }, 8000);
        });
    });
}());
