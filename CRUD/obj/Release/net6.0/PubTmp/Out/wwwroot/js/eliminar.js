var miUrl = 'Eliminar';
var seletion = 0;
var oneTbody = document.querySelector("#elim tbody"), //Cuerpo de la primera tabla
    //twoTbody = document.querySelector("#two tbody"), //Cuerpo de la segunda tabla
    elim1 = document.querySelector("#copy"), //Botón que copiará los datos de las filas seleccionadas
    seleccion = [], //Arreglo que almacenará a las filas seleccionadas
    seleccionar = function (event) { //Función a ejecutarse para seleccionar una fila
        if (event.target.tagName == "TD") { //Si se pulsó una celda
            var fila = event.target.parentNode; //Se almacena en una variable a la fila que la contiene
            //Si no está seleccionada
            if (fila.dataset.selected < 1 && seletion == 0 && seleccion.length == 0) {
                fila.style.backgroundColor = "#00C8F5"; //Se la pinta de rojo
                fila.style.color = "white"; //Con un texto en blanco
                fila.dataset.selected = 1; //Se asigna el valor 1 al pseudoatributo "data-selected"
                seleccion.push(fila); //Se añade la fila al arreglo de filas seleccionadas
                seletion++;
            }
            //Si está seleccionada
            else if (seleccion.length == 1 && fila.dataset.selected > 0) {
                fila.style.backgroundColor = ""; //Se retira el color de fondo
                fila.style.color = ""; //Y el del texto
                fila.dataset.selected = 0; //El valor del pseudoatributo retorna a 0
                seleccion.splice(seleccion.indexOf(fila), 1); //Se elimina la fila del arreglo
                seletion = 0;
            }
            //console.log(seleccion[0].querySelectorAll("td")[0].innerText)
        }
    },
    felim1 = function (event) {

        if (seleccion.length) {
            Swal.fire({
                title: 'Confirmacion',
                text: "¿Desea Realmente Eliminar El Usuario?",
                icon: 'question',
                showCancelButton: true,
                confirmButtonText: 'Eliminar',
            }).then((result) => {
                /* Read more about isConfirmed, isDenied below */
                if (result.isConfirmed) {
                    $.ajax({
                        url: miUrl,
                        method: "POST",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(seleccion[0].querySelectorAll("td")[0].innerText),
                        success: function (response) {
                            location.reload();
                        },
                        async: true,
                        error: function (req, status, error) { alert(status); }
                    });
                    
                }
            })

        }
        else {
            Swal.fire("Error", "Seleccione un Registro a Eliminar", "error")
            //alert("Seleccione un Registro a Eliminar")
        }
    }

//Cuando se produzca el evento "click" en la primera tabla, se ejecutará la función "callback"
oneTbody.addEventListener("click", seleccionar, false);

//Cuando se pulse el botón, se ejecutará el siguiente conjunto de instrucciones
elim1.addEventListener("click", felim1, false);