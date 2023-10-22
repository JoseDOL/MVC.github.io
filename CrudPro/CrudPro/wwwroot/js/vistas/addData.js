document.getElementById("fecha_nacimiento").addEventListener("change", function () {
    // Cálculo de la edad
    var birthDate = new Date(this.value);
    var today = new Date();
    var age = today.getFullYear() - birthDate.getFullYear();
    document.getElementById("edad").value = age;
});

