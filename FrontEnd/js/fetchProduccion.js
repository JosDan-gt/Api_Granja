

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
            console.log(data2);

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
                        <td>${data2[i].Cantidad_Cajas}</td>
                        <td>${data2[i].Fecha_Control}</td>
                        <td>
                        <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#verproduccion" onclick="verProduccion(${data2[i].DiaControl_Numero})">Ver</button>
                        <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#modProduccion" onclick="verProduccionmod(${data2[i].DiaControl_Numero})">Editar</button>
                        </td>
                    </tr>`

                }
            }

        })

        .catch(error => {
            console.log(error)
        });
}

function verProduccion(id) {

    var newUrl = url2 + '/' + id;
    //console.log(newUrl)
    
    fetch(newUrl)
    .then(response2 => {
        if(!response2.ok){
            throw new Error(response2.statusText)
        }
        return response2.json()
    })
    .then(data2 => {
        console.log(data2)

        var huevosDia = document.getElementById('huevosDia')
        huevosDia.value = data2.Huevos_PorDia

        var cantPeque = document.getElementById('cantPeque')
        cantPeque.value = data2.CantidadCartones_Pequeno

        var cantMed = document.getElementById('cantMed')
        cantMed.value = data2.CantidadCartones_Mediano

        var cantGrand = document.getElementById('cantGrand')
        cantGrand.value = data2.CantidadCartones_Grande

        var cantJumb = document.getElementById('cantJumb')
        cantJumb.value = data2.CantidadCartones_Jumbo

        var cantGall = document.getElementById('cantGall')
        cantGall.value = data2.Cantidad_Gallinas

        var cantCajas = document.getElementById('cantCajas')
        cantCajas.value = data2.Cantidad_Cajas

        var cantPerd = document.getElementById('cantPerd')
        cantPerd.value = data2.Cantidad_Perdida
        
        var fecha = document.getElementById('fecha2')
        fecha.value = data2.Fecha_Control
        
    })
    .catch(err => {
        console.log(err)
    })
    
}



function verProduccionmod(id) {

    var newUrl = url2 + '/' + id
    console.log(newUrl)
    
    fetch(newUrl)
    .then(response2 => {
        if(!response2.ok){
            throw new Error(response2.statusText)
        }
        return response2.json()
    })
    .then(data2 => {
        console.log(data2)

        var huevosDia = document.getElementById('huevosDiaMod')
        huevosDia.value = data2.Huevos_PorDia

        var cantPeque = document.getElementById('cantPequeMod')
        cantPeque.value = data2.CantidadCartones_Pequeno

        var cantMed = document.getElementById('cantMedMod')
        cantMed.value = data2.CantidadCartones_Mediano

        var cantGrand = document.getElementById('cantGrandMod')
        cantGrand.value = data2.CantidadCartones_Grande

        var cantJumb = document.getElementById('cantJumbMod')
        cantJumb.value = data2.CantidadCartones_Jumbo

        var cantGall = document.getElementById('cantGallMod')
        cantGall.value = data2.Cantidad_Gallinas

        var cantCajas = document.getElementById('cantCajasMod')
        cantCajas.value = data2.Cantidad_Cajas

        var cantPerd = document.getElementById('cantPerdMod')
        cantPerd.value = data2.Cantidad_Perdida
        
        var fecha = document.getElementById('fechaMod')
        fecha.value = data2.Fecha_Control

        produccion.Huevos_PorDia = data2.Huevos_PorDia
        produccion.CantidadCartones_Pequeno = data2.CantidadCartones_Pequeno
        produccion.CantidadCartones_Mediano = data2.CantidadCartones_Mediano
        produccion.CantidadCartones_Grande = data2.CantidadCartones_Grande
        produccion.CantidadCartones_Jumbo = data2.CantidadCartones_Jumbo
        produccion.Cantidad_Gallinas = data2.Cantidad_Gallinas
        produccion.Cantidad_Cajas = data2.Cantidad_Cajas
        produccion.Cantidad_Perdida = data2.Cantidad_Perdida
        produccion.Fecha_Control = data2.Fecha_Control

        
    })
    .catch(err => {
        console.log(err)
    })
    
}


function modificarProduccion(){

    var newUrl = url2 + '/' + produccion.DiaControl_Numero

    console.log(JSON.stringify(produccion))
    console.log(newUrl)

    // var nombreEmpleado = document.getElementById('nombreEmpleadoMod').value
    // var apellidoEmpleado = document.getElementById('apellidoEmpleadoMod').value
    // var direccionEmpleado = document.getElementById('direccionEmpleadoMod').value
    // var puestoEmpleado = document.getElementById('puestoEmpleadoMod').value
    // var edadEmpleado = document.getElementById('edadEmpleadoMod').value
    // var telefonoEmpleado = document.getElementById('telefonoEmpleadoMod').value
    // var salarioEmpleado = document.getElementById('salarioEmpleadoMod').value

    // empleadoFinal = {
    //     "Id_Empleado": empleado.Id_Empleado,
    //     "Nombre_Empleado": nombreEmpleado,
    //     "Apellido_Empleado": apellidoEmpleado,
    //     "Direccion_Empleado": direccionEmpleado,
    //     "Puesto_Empleado": puestoEmpleado,
    //     "Edad_Empleado": edadEmpleado,
    //     "Telefono_Empleado": telefonoEmpleado,
    //     "Salario_Empleado": salarioEmpleado,
    //     "Solvencia_Salario": empleado.Solvencia_Salario
    //}

    // fetch(newUrl, {
    //     method: 'PUT',
    //     body: JSON.stringify(empleadoFinal),
    //     headers: {
    //         'Content-Type': 'application/json'
    //     }
    // })
    // .then(res => res.json())
    // .then(data => {

    //     alert(data)
    //     getEmpleados()

    // })
    // .catch(error => {
    //     console.error('Error:', error)
    // })

}
