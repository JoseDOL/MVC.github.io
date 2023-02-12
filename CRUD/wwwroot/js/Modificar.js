function setEdad() {
    let fecha = document.getElementById("fecha1").value;
    if (fecha != "") {
        document.getElementById("edad2").value = calcularEdad1(fecha);
    } else {
        Swal.fire("Error", "Fecha no valida", "error")
    }
}


function calcularEdad1(fecha) {
    var hoy = new Date();
    var cumpleanos = new Date(fecha);
    var edad = hoy.getFullYear() - cumpleanos.getFullYear();
    var m = hoy.getMonth() - cumpleanos.getMonth();

    if (m < 0 || (m === 0 && hoy.getDate() < cumpleanos.getDate())) {
        edad--;
    }

    return edad;
}

