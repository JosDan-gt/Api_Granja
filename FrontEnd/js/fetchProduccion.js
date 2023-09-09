

var url2 = 'http://localhost:56138/api/ControlProduccion'

var produccion = {
    DiaControl_Numero: '',
    Huevos_PorDia: '',
    CantidadCartones_Pequeno: '',
    CantidadCartones_Mediano: '',
    CantidadCartones_Grande: '',
    CantidadCartones_Jumbo: '',
    Cantidad_Gallinas: '',
    Cantidad_Cajas: '',
    Cantidad_Perdida: '',
    Fecha_Control: ''
}

getProduccion();

function getProduccion() {

    fetch(url2)
        .then(response2 => {
            if (!response2.ok) {
                throw new Error(response2.statusText);
            }
            return response2.json();
        })
        .then(data2 => {
            // console.log(data2);

            var getEmpleados = document.getElementById('produccion');
            getEmpleados.innerHTML = ''

            if (data2.length > 0) {
                for (var i = 0; i < data2.length; i++) {

                    getEmpleados.innerHTML += `
                    <tr>
                        <td>${data2[i].DiaControl_Numero}</td>
                        <td>${data2[i].Huevos_PorDia}</td>
                        <td>${data2[i].CantidadCartones_Pequeno}</td>
                        <td>${data2[i].CantidadCartones_Mediano}</td>
                        <td>${data2[i].CantidadCartones_Grande}</td>
                        <td>${data2[i].CantidadCartones_Jumbo}</td>
                        <td>${data2[i].Cantidad_Gallinas}</td>
                        <td>${data2[i].Cantidad_Cajas}</td>
                        <td>${data2[i].Cantidad_Perdida}</td>
                        <td>${data2[i].Fecha_Control}</td>
                        <td>
                        <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#verEmpleado" onclick="verEmpleado(${data2[i].DiaControl_Numero})">Ver</button>
                        <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#modEmpleado" onclick="verEmpleadomod(${data2[i].DiaControl_Numero})">Editar</button>
                        <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#elimEmpleado" onclick="verEmpleadoelim(${data2[i].DiaControl_Numero})">Eliminar</button>
                        </td>
                    </tr>`

                }
            }

        })

        .catch(error => {
            console.log(error)
        });
}

