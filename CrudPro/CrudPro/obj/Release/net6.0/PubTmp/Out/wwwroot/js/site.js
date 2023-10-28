// Captura todas las opciones del menú
const menuItems = document.querySelectorAll('.menu li');

document.querySelector('.navbar-toggler').addEventListener('click', function () {
    document.querySelector('.lado-izquierdo').classList.toggle('expandir');
    document.querySelector('.navbar').classList.toggle('expandir-nav');
});


// Agrega un evento de clic a cada opción del menú
menuItems.forEach((item) => {
    item.addEventListener('click', () => {
        // Elimina la clase "active" de todas las opciones
        menuItems.forEach((menuItem) => {
            menuItem.classList.remove('active');
        });

        // Agrega la clase "active" a la opción clicada
        item.classList.add('active');
    });
});