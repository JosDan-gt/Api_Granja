var url = 'http://localhost:56138/api/ControlVacunacion';


var vacunas = {
    Vacuna_Numero: '',
    Nombre_Vacuna: '',
    Cantidad_Vacunas: '',
    Tipo_Vacuna: '',
    Tiempo_Aplicacion: '',
    CostoPor_Vacuna: '',
    Fecha_Colocacion: '',
}

getVacunas()

function getVacunas() {
    
    fetch(url)
    .then(res => {
        if(!res.ok){
            throw new Error(res.statusText)
        }
        return res.json()

    })
    .then(data => {
        //console.log(data)

        var getVacunas = document.getElementById('vacunas')
        getVacunas.innerHTML = ''

        if (data.length > 0) {
            for(var i = 0; i < data.length; i++){
                
                getVacunas.innerHTML += `
                <tr>
                    <td>${data[i].Vacuna_Numero}</td>
                    <td>${data[i].Nombre_Vacuna}</td>
                    <td>${data[i].Cantidad_Vacunas}</td>
                    <td>${data[i].Tipo_Vacuna}</td>
                    <td>${data[i].Tiempo_Aplicacion}</td>
                    <td>${data[i].CostoPor_Vacuna}</td>
                    <td>${data[i].Fecha_Colocacion}</td>
                    <td>
                    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#verEmpleado" onclick="verVacunas(${data[i].Vacuna_Numero})">Ver</button>
                    <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#modEmpleado" onclick="verVacunasmod(${data[i].Vacuna_Numero})">Editar</button>
                    <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#elimEmpleado" onclick="verVacunaselim(${data[i].Vacuna_Numero})">Eliminar</button>
                    </td>
                </tr>`

            }
        }
    })

    .catch(err => {
        console.log(err)
    });


}

function verVacunas(id) {

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

        var nombreVacuna = document.getElementById('nombreVacuna')
        nombreVacuna.value = data.Nombre_Vacuna

        var cantidadVacuna = document.getElementById('cantidadVacuna')
        cantidadVacuna.value = data.Cantidad_Vacunas

        var tipoVacuna = document.getElementById('tipoVacuna')
        tipoVacuna.value = data.Tipo_Vacuna

        var tiempoVacuna = document.getElementById('tiempoVacuna')
        tiempoVacuna.value = data.Tiempo_Aplicacion

        var costoVacuna = document.getElementById('costoVacuna')
        costoVacuna.value = data.CostoPor_Vacuna

        var fechaVacuna = document.getElementById('fechaVacuna')
        fechaVacuna.value = data.Fecha_Colocacion

        var numeroVacuna = document.getElementById('numeroVacuna')
        numeroVacuna.value = data.Vacuna_Numero
        
    })
    .catch(err => {
        console.log(err)
    })
    
}

function verVacunasmod(id) {

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

        var numeroVacunaMod = document.getElementById('numeroVacunaMod')
        numeroVacunaMod.value = data.Vacuna_Numero

        var nombreVacunaMod = document.getElementById('nombreVacunaMod')
        nombreVacunaMod.value = data.Nombre_Vacuna

        var cantidadVacunaMod = document.getElementById('cantidadVacunaMod')
        cantidadVacunaMod.value = data.Cantidad_Vacunas

        var tipoVacunaMod = document.getElementById('tipoVacunaMod')
        tipoVacunaMod.value = data.Tipo_Vacuna

        var tiempoVacunaMod = document.getElementById('tiempoVacunaMod')
        tiempoVacunaMod.value = data.Tiempo_Aplicacion

        var costoVacunaMod = document.getElementById('costoVacunaMod')
        costoVacunaMod.value = data.CostoPor_Vacuna

        var fechaVacunaMod = document.getElementById('fechaVacunaMod')
        fechaVacunaMod.value = data.Fecha_Colocacion

        vacunas.Vacuna_Numero = data.Vacuna_Numero
        vacunas.Nombre_Vacuna = data.Nombre_Vacuna
        vacunas.Cantidad_Vacunas = data.Cantidad_Vacunas
        vacunas.Tipo_Vacuna = data.Tipo_Vacuna
        vacunas.Tiempo_Aplicacion = data.Tiempo_Aplicacion
        vacunas.CostoPor_Vacuna = data.CostoPor_Vacuna
        vacunas.Fecha_Colocacion = data.Fecha_Colocacion
    

        
    })
    .catch(err => {
        console.log(err)
    })
    
}

function modificarVacunas(){

    var newUrl = url + '/' + vacunas.Vacuna_Numero

    console.log(JSON.stringify(vacunas))
    //console.log(newUrl)

    var nombreVacuna = document.getElementById('nombreVacunaMod').value
    var cantidadVacuna = document.getElementById('cantidadVacunaMod').value
    var tipoVacuna = document.getElementById('tipoVacunaMod').value
    var tiempoVacuna = document.getElementById('tiempoVacunaMod').value
    var costoVacuna = document.getElementById('costoVacunaMod').value
    var fechaVacuna = document.getElementById('fechaVacunaMod').value

    vacunaFinal = {
        "Vacuna_Numero": vacunas.Vacuna_Numero,
        "Nombre_Vacuna": nombreVacuna,
        "Cantidad_Vacunas": cantidadVacuna,
        "Tipo_Vacuna": tipoVacuna,
        "Tiempo_Aplicacion": tiempoVacuna,
        "CostoPor_Vacuna": costoVacuna,
        "Fecha_Colocacion": fechaVacuna,
    }

    fetch(newUrl, {
        method: 'PUT',
        body: JSON.stringify(vacunaFinal),
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(res => res.json())
    .then(data => {

        alert(data)
        getVacunas()

    })
    .catch(error => {
        console.error('Error:', error)
    })

}

function verVacunaselim(id) {

    var newUrl = url + '/' + id

    fetch(newUrl)
    .then(res => {
        if(!res.ok){
            throw new Error(res.statusText)
        }
        return res.json()
    })
    .then(data => {
        //console.log(data)

        vacunas.Vacuna_Numero = data.Vacuna_Numero
        vacunas.Nombre_Vacuna = data.Nombre_Vacuna
        vacunas.Cantidad_Vacunas = data.Cantidad_Vacunas
        vacunas.Tipo_Vacuna = data.Tipo_Vacuna
        vacunas.Tiempo_Aplicacion = data.Tiempo_Aplicacion
        vacunas.CostoPor_Vacuna = data.CostoPor_Vacuna
        vacunas.Fecha_Colocacion = data.Fecha_Colocacion
        
    })
    .catch(err => {
        console.log(err)
    })

}

var VacunasElimina = {}

function eliminarEmpleado() {

    var newUrl = url + '/' + vacunas.Vacuna_Numero
    //console.log(newUrl)

    VacunasElimina = {
        "Vacuna_Numero": vacunas.Vacuna_Numero,
    }
    
    console.log(JSON.stringify(VacunasElimina))

    fetch(newUrl, {
        method: 'DELETE',
        body: JSON.stringify(VacunasElimina),
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(res => {

        if(!res.ok){
            throw new Error(res.statusText)
        }

        var modalEliminar = new bootstrap.Modal(document.getElementById('elimVacunas'));
        modalEliminar.hide();

        alert('Vacunas eliminado')

        getVacunas()

        
    })
    .catch(error => {
        console.log('ERROR', error);
    });

}

function agregarEmpleado() {

        document.getElementById('numeroVacunaAdd').innerHTML = ''
    
        var numeroVacuna = document.getElementById('numeroVacunaAdd').value
        var apellidoEmpleado = document.getElementById('apellidoEmpleadoAdd').value
        var direccionEmpleado = document.getElementById('direccionEmpleadoAdd').value
        var puestoEmpleado = document.getElementById('puestoEmpleadoAdd').value
        var edadEmpleado = document.getElementById('edadEmpleadoAdd').value
        var telefonoEmpleado = document.getElementById('telefonoEmpleadoAdd').value
        var salarioEmpleado = document.getElementById('salarioEmpleadoAdd').value
    
        empleadoFinal = {
            "Nombre_Empleado": numeroVacuna,
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
