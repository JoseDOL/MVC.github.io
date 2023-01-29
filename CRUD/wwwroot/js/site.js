// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let startDate = document.getElementById('fecha')
let fechaNac = document.getElementById('edad1')

if (startDate) {
    startDate.addEventListener('change', (e) => {
        let startDateVal = e.target.value
        fechaNac.value = calcularEdad(startDateVal)
    })
}




function calcularEdad(fecha) {
    var hoy = new Date();
    var cumpleanos = new Date(fecha);
    var edad = hoy.getFullYear() - cumpleanos.getFullYear();
    var m = hoy.getMonth() - cumpleanos.getMonth();

    if (m < 0 || (m === 0 && hoy.getDate() < cumpleanos.getDate())) {
        edad--;
    }

    return edad;
}