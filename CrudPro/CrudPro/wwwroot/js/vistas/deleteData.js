document.addEventListener('DOMContentLoaded', function () {
    const btnEliminar = document.getElementById('btnEliminar');

    btnEliminar.addEventListener('click', function (e) {
        e.preventDefault(); // Previene el envío del formulario

        Swal.fire({
            title: '¿Estás seguro?',
            text: '¿Deseas eliminar los datos?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sí, eliminar',
            cancelButtonText: 'Cancelar'
        }).then((result) => {
            if (result.isConfirmed) {
                // Aquí puedes agregar el código para enviar el formulario o realizar la eliminación
                document.getElementById('deleteForm').submit(); // Envía el formulario
            }
        });
    });
});