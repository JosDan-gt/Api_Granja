
var url = 'http://localhost:56138/api/ControlEmpleados'

var empleado = {
    Id_Empleado: '',
    Nombre_Empleado: '',
    Apellido_Empleado: '',
    Direccion_Empleado: '',
    Puesto_Empleado: '',
    edad_Empleado: '',
    Telefono_Empleado: '',
    Salario_Empleado: '',
    Solvencia_Salario: ''
}

getEmpleados()

function getEmpleados() {
    
    fetch(url)
    .then(res => {
        if(!res.ok){
            throw new Error(res.statusText)
        }
        return res.json()

    })
    .then(data => {
        //console.log(data)

        var getEmpleados = document.getElementById('empleado')
        getEmpleados.innerHTML = ''

        if (data.length > 0) {
            for(var i = 0; i < data.length; i++){
                
                getEmpleados.innerHTML += `
                <tr>
                    <td>${data[i].Id_Empleado}</td>
                    <td>${data[i].Nombre_Empleado}</td>
                    <td>${data[i].Apellido_Empleado}</td>
                    <td>${data[i].Direccion_Empleado}</td>
                    <td>${data[i].Puesto_Empleado}</td>
                    <td>
                    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#verEmpleado" onclick="verEmpleado(${data[i].Id_Empleado})">Ver</button>
                    <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#modEmpleado" onclick="verEmpleadomod(${data[i].Id_Empleado})">Editar</button>
                    <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#elimEmpleado" data-idempleado="${data[i].Id_Empleado}">Eliminar</button>
                    </td>
                </tr>`

            }
        }
    })

    .catch(err => {
        console.log(err)
    });


}

function verEmpleado(id) {

    var newUrl = url + '/' + id
    //console.log(newUrl)
    
    fetch(newUrl)
    .then(res => {
        if(!res.ok){
            throw new Error(res.statusText)
        }
        return res.json()
    })
    .then(data => {
        console.log(data)

        var nombreEmpleado = document.getElementById('nombreEmpleado')
        nombreEmpleado.value = data.Nombre_Empleado

        var apellidoEmpleado = document.getElementById('apellidoEmpleado')
        apellidoEmpleado.value = data.Apellido_Empleado

        var direccionEmpleado = document.getElementById('direccionEmpleado')
        direccionEmpleado.value = data.Direccion_Empleado

        var puestoEmpleado = document.getElementById('puestoEmpleado')
        puestoEmpleado.value = data.Puesto_Empleado

        var edadEmpleado = document.getElementById('edadEmpleado')
        edadEmpleado.value = data.Edad_Empleado

        var telefonoEmpleado = document.getElementById('telefonoEmpleado')
        telefonoEmpleado.value = data.Telefono_Empleado

        var salarioEmpleado = document.getElementById('salarioEmpleado')
        salarioEmpleado.value = data.Salario_Empleado
        
    })
    .catch(err => {
        console.log(err)
    })
    
}

function verEmpleadomod(id) {

    var newUrl = url + '/' + id
    //console.log(newUrl)
    
    fetch(newUrl)
    .then(res => {
        if(!res.ok){
            throw new Error(res.statusText)
        }
        return res.json()
    })
    .then(data => {
        //console.log(data)

        var nombreEmpleado = document.getElementById('nombreEmpleadoMod')
        nombreEmpleado.value = data.Nombre_Empleado

        var apellidoEmpleado = document.getElementById('apellidoEmpleadoMod')
        apellidoEmpleado.value = data.Apellido_Empleado

        var direccionEmpleado = document.getElementById('direccionEmpleadoMod')
        direccionEmpleado.value = data.Direccion_Empleado

        var puestoEmpleado = document.getElementById('puestoEmpleadoMod')
        puestoEmpleado.value = data.Puesto_Empleado

        var edadEmpleado = document.getElementById('edadEmpleadoMod')
        edadEmpleado.value = data.Edad_Empleado

        var telefonoEmpleado = document.getElementById('telefonoEmpleadoMod')
        telefonoEmpleado.value = data.Telefono_Empleado

        var salarioEmpleado = document.getElementById('salarioEmpleadoMod')
        salarioEmpleado.value = data.Salario_Empleado

        empleado.Id_Empleado = data.Id_Empleado
        empleado.Nombre_Empleado = data.Nombre_Empleado
        empleado.Apellido_Empleado = data.Apellido_Empleado
        empleado.Direccion_Empleado = data.Direccion_Empleado
        empleado.Puesto_Empleado = data.Puesto_Empleado
        empleado.edad_Empleado = data.Edad_Empleado
        empleado.Telefono_Empleado = data.Telefono_Empleado
        empleado.Salario_Empleado = data.Salario_Empleado
        empleado.Solvencia_Salario = data.Solvencia_Salario

        
    })
    .catch(err => {
        console.log(err)
    })
    
}

function modificarEmpleado(){

    var newUrl = url + '/' + empleado.Id_Empleado

    console.log(JSON.stringify(empleado))
    //console.log(newUrl)

    var nombreEmpleado = document.getElementById('nombreEmpleadoMod').value
    var apellidoEmpleado = document.getElementById('apellidoEmpleadoMod').value
    var direccionEmpleado = document.getElementById('direccionEmpleadoMod').value
    var puestoEmpleado = document.getElementById('puestoEmpleadoMod').value
    var edadEmpleado = document.getElementById('edadEmpleadoMod').value
    var telefonoEmpleado = document.getElementById('telefonoEmpleadoMod').value
    var salarioEmpleado = document.getElementById('salarioEmpleadoMod').value

    empleadoFinal = {
        "Id_Empleado": empleado.Id_Empleado,
        "Nombre_Empleado": nombreEmpleado,
        "Apellido_Empleado": apellidoEmpleado,
        "Direccion_Empleado": direccionEmpleado,
        "Puesto_Empleado": puestoEmpleado,
        "Edad_Empleado": edadEmpleado,
        "Telefono_Empleado": telefonoEmpleado,
        "Salario_Empleado": salarioEmpleado,
        "Solvencia_Salario": empleado.Solvencia_Salario
    }

    fetch(newUrl, {
        method: 'PUT',
        body: JSON.stringify(empleadoFinal),
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(res => res.json())
    .then(data => {

        alert(data)
        getEmpleados()

    })
    .catch(error => {
        console.error('Error:', error)
    })

}

function eliminarEmpleado() {

    // Obtén el botón por su clase o selector
    const botonEliminar = document.querySelector('.btn-danger');

    // Accede al valor de data-idempleado utilizando el método getAttribute
    const idEmpleado = botonEliminar.getAttribute('data-idempleado');

    var newUrl = url + '/' + idEmpleado
    console.log(empleado)

    empleadoElimina = {
        "Id_Empleado": idEmpleado,
        "Solvencia_Salario": 0
    }
    

    console.log(JSON.stringify(empleadoElimina))
/*
    fetch(newUrl, {
        method: 'DELETE',
        body: JSON.stringify(empleadoElimina),
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(res => {

        if(!res.ok){
            throw new Error(res.statusText)
        }

        var modalEliminar = new bootstrap.Modal(document.getElementById('elimEmpleado'));
        modalEliminar.hide();

        alert('Empleado eliminado')

        getEmpleados()

        
    })
    .catch(error => {
        console.log('ERROR', error);
    });
*/
}

function agregarEmpleado() {

        document.getElementById('nombreEmpleadoAdd').innerHTML = ''
    
        var nombreEmpleado = document.getElementById('nombreEmpleadoAdd').value
        var apellidoEmpleado = document.getElementById('apellidoEmpleadoAdd').value
        var direccionEmpleado = document.getElementById('direccionEmpleadoAdd').value
        var puestoEmpleado = document.getElementById('puestoEmpleadoAdd').value
        var edadEmpleado = document.getElementById('edadEmpleadoAdd').value
        var telefonoEmpleado = document.getElementById('telefonoEmpleadoAdd').value
        var salarioEmpleado = document.getElementById('salarioEmpleadoAdd').value
    
        empleadoFinal = {
            "Nombre_Empleado": nombreEmpleado,
            "Apellido_Empleado": apellidoEmpleado,
            "Direccion_Empleado": direccionEmpleado,
            "Puesto_Empleado": puestoEmpleado,
            "Edad_Empleado": edadEmpleado,
            "Telefono_Empleado": telefonoEmpleado,
            "Salario_Empleado": salarioEmpleado,
            "Solvencia_Salario": 1
        }
    
        console.log(JSON.stringify(empleadoFinal))
    
        fetch(url, {
            method: 'POST',
            body: JSON.stringify(empleadoFinal),
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(res => res.json())
        .then(data => {
    
            alert(data)
            getEmpleados()

            window.location.reload()
    
        })
        .catch(error => {
            console.error('Error:', error)
        })
}
