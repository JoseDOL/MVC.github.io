var miUrlAct = 'Activar';
var seletionAct = 0;
var oneTbodyAct = document.querySelector("#Activ tbody"), //Cuerpo de la primera tabla
    //twoTbody = document.querySelector("#two tbody"), //Cuerpo de la segunda tabla
    btnact = document.querySelector("#btn-activ"), //Botón que copiará los datos de las filas seleccionadas
    seleccionAct = [], //Arreglo que almacenará a las filas seleccionadas
    seleccionarAct = function (event) { //Función a ejecutarse para seleccionarAct una fila
        if (event.target.tagName == "TD") { //Si se pulsó una celda
            var fila = event.target.parentNode; //Se almacena en una variable a la fila que la contiene
            //Si no está seleccionada
            if (fila.dataset.selected < 1 && seletionAct == 0 && seleccionAct.length == 0) {
                fila.style.backgroundColor = "#8DE91E"; //Se la pinta de rojo
                fila.style.color = "white"; //Con un texto en blanco
                fila.dataset.selected = 1; //Se asigna el valor 1 al pseudoatributo "data-selected"
                seleccionAct.push(fila); //Se añade la fila al arreglo de filas seleccionadas
                seletionAct++;
            }
            //Si está seleccionada
            else if (seleccionAct.length == 1 && fila.dataset.selected > 0) {
                fila.style.backgroundColor = ""; //Se retira el color de fondo
                fila.style.color = ""; //Y el del texto
                fila.dataset.selected = 0; //El valor del pseudoatributo retorna a 0
                seleccionAct.splice(seleccionAct.indexOf(fila), 1); //Se elimina la fila del arreglo
                seletionAct = 0;
            }
            //console.log(seleccionAct[0].querySelectorAll("td")[0].innerText)
        }
    },
    fActiv = function (event) {

        if (seleccionAct.length) {
            Swal.fire({
                title: 'Confirmacion',
                text: "Desea Realmente Activar El Usuario?",
                icon: 'question',
                showCancelButton: true,
                confirmButtonText: 'Activar',
            }).then((result) => {
                /* Read more about isConfirmed, isDenied below */
                if (result.isConfirmed) {
                    $.ajax({
                        url: miUrlAct,
                        method: "POST",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(seleccionAct[0].querySelectorAll("td")[0].innerText),
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
            Swal.fire("Error", "Seleccione un Registro a Activar", "error")
            //alert("Seleccione un Registro a Eliminar")
        }
    }

//Cuando se produzca el evento "click" en la primera tabla, se ejecutará la función "callback"
oneTbodyAct.addEventListener("click", seleccionarAct, false);

//Cuando se pulse el botón, se ejecutará el siguiente conjunto de instrucciones
btnact.addEventListener("click", fActiv, false);


