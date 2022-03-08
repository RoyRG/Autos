﻿let urlCentral = "https://localhost:44331/api/Autos";
let row;
var Obtener = () => {
    fetch(urlCentral)
        .then(response => response.json())
        .then(function (data) {
            document.getElementById("tblAutos").innerHTML = "";
            data.map(function (item) {
                var tabla = document.getElementById("tblAutos");
                var tr = document.createElement("tr");
                var colId = document.createElement("th");
                var colIdModelo = document.createElement("th");
                var colIdEstado = document.createElement("th");
                var colIdLote = document.createElement("th");
                var colmodelo = document.createElement("th");
                var colestado = document.createElement("th");
                var collote = document.createElement("th");
                var actualizar = document.createElement("th");
                var eliminar = document.createElement("th");
                colId.innerHTML = item.id_Auto;
                colIdModelo.innerHTML = item.id_Modelo;
                colIdEstado.innerHTML = item.id_Estado;
                colIdLote.innerHTML = item.id_Lote;
                colmodelo.innerHTML = item.modelo;
                colestado.innerHTML = item.estado;
                collote.innerHTML = item.lote;
                //Creación de los botones dinámicos
                actualizar.innerHTML += '<input type="button" value ="' + "Actualizar" +' "class="btn btn-success editar edit-modal btn btn-warning botonEditar" data-target= "#imodal" data-toggle="modal" onclick="CargaCombos()">';
                eliminar.innerHTML += '<input type="button" value ="' + "Borrar" +' "class="btn btn-danger editar edit-modal botonEliminar"  data-target= "#eliminar" data-toggle="modal" onclick="CargaCombos()">';
                tabla.appendChild(tr);
                tr.appendChild(colId).style.display = 'none';
                tr.appendChild(colIdModelo).style.display = 'none';
                tr.appendChild(colIdEstado).style.display = 'none';
                tr.appendChild(colIdLote).style.display = 'none';
                tr.appendChild(colmodelo);
                tr.appendChild(colestado);
                tr.appendChild(collote);
                tr.appendChild(actualizar);
                tr.appendChild(eliminar);
            });
        })
        .catch(err => console.log(err));
}
const Agregar = async () => {

    let modeloAgrega = document.getElementById("cmbModeloA").value;
    let añoAgrega = document.getElementById("txtFechaA").value;
    let estadoAgrega = document.getElementById("cmbEstadoA").value;
    let loteAgrega = document.getElementById("cmbLoteA").value;
    let _data = {

       
        Modelo: `${modeloAgrega}`,
        Estado: `${estadoAgrega}`,
        Lote: `${loteAgrega}`,
        Año: `${añoAgrega}`,
    };

    let response = await fetch(urlCentral, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(_data)
    }).then(() => {
        window.location.reload();
    });

    let result = await response.json();
    alert(result.message);
}
//Función modificar del api
const Modificar = async () => {
  
    let id1 = row;
    let modeloModifica = document.getElementById("cmbModelo").value;
    let añoModifica = document.getElementById("txtFecha").value;
    let estadoModifica = document.getElementById("cmbEstado").value;
    let loteModifica= document.getElementById("cmbLote").value;
    let _data = {
        Id_Auto: `${id1}`,
        Modelo: `${modeloModifica}`,
        Estado: `${estadoModifica}`,
        Lote: `${loteModifica}`,
        Año: `${añoModifica}`,
    };
    let response = await fetch(urlCentral, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(_data)
    }).then(() => {
        window.location.reload();
    });
   
    let result = await response.json();
    alert(result.message);

}
//Función eliminar del api
const Eliminar = async () => {

    var url1 = new URL(urlCentral),
        params = { id: row1 }
    Object.keys(params).forEach(key => url1.searchParams.append(key, params[key]))
    fetch(url1);

    let response = await fetch(url1, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        }
    }).then(() => {
        window.location.reload();
    });

    let result = await response.json();
    alert(result.message);
   
}
//Llenado de los select para los combos del modal para modificar
var CargaCombos = () => {
    //Obtención del id para la respuesta json
    $(document).on('click', '.botonEditar', function (e) {
        row = $(this).parents('tr').children().eq(0).text();
         mod = $(this).parents('tr').children().eq(1).text();
         est = $(this).parents('tr').children().eq(2).text();
         lot = $(this).parents('tr').children().eq(3).text();
        console.log(row);
        console.log(mod);
        console.log(est);
        console.log(lot);
    });
    $(document).on('click', '.botonEliminar', function (e) {
        row1 = $(this).parents('tr').children().eq(0).text();
        console.log(row);
    });

    fetch("https://localhost:44331/api/Modelos")
        .then(response => response.json())
        .then(function (data) {
            document.getElementById("cmbModelo").innerHTML = "";
            var cmbModelo = document.getElementById("cmbModelo");
            data.map(function (item) {
                var option = document.createElement("option");
                option.value = item.id;
                option.text = item.nombre;
                cmbModelo.appendChild(option);

                $('#cmbModelo').val(`${mod}`);


            });

        })
        .catch(err => console.log(err));
    fetch("https://localhost:44331/api/Estado")
        .then(response => response.json())
        .then(function (data) {
            document.getElementById("cmbEstado").innerHTML = "";
            var cmbEstado = document.getElementById("cmbEstado");
            
            data.map(function (item) {
                var option = document.createElement("option");
                option.value = item.id;
                option.text = item.nombre;
                cmbEstado.appendChild(option);

                $('#cmbEstado').val(`${est}`);
            });


        })
        .catch(err => console.log(err));
    fetch("https://localhost:44331/api/Lotes")
        .then(response => response.json())
        .then(function (data) {
            document.getElementById("cmbLote").innerHTML = "";
            var cmbLote = document.getElementById("cmbLote");
       
            data.map(function (item) {
                var option = document.createElement("option");
                option.value = item.id;
                option.text = item.nombre;
                cmbLote.appendChild(option);

                $('#cmbLote').val(`${lot}`);
            });


        })


        .catch(err => console.log(err));
};
//Llenado de los select para los combos del modal para agregar
var CargaCombosAgrega = () => {
    fetch("https://localhost:44331/api/Modelos")
        .then(response => response.json())
        .then(function (data) {
            document.getElementById("cmbModeloA").innerHTML = "";
            var cmbModelo = document.getElementById("cmbModeloA");
            var modlA = document.createElement("option");
            modlA.text = "Selecciona un modelo";
            cmbModelo.appendChild(modlA).disabled = true;
            data.map(function (item) {
                var option = document.createElement("option");
                option.value = item.id;
                option.text = item.nombre;
                cmbModelo.appendChild(option);
            });


        })


        .catch(err => console.log(err));
    fetch("https://localhost:44331/api/Estado")
        .then(response => response.json())
        .then(function (data) {
            document.getElementById("cmbEstadoA").innerHTML = "";
            var cmbEstado = document.getElementById("cmbEstadoA");
            var estA = document.createElement("option");
            estA.text = "Selecciona un estado";
            cmbEstado.appendChild(estA).disabled = true;
            data.map(function (item) {
                var option = document.createElement("option");
                option.value = item.id;
                option.text = item.nombre;
                cmbEstado.appendChild(option);
            });


        })


        .catch(err => console.log(err));
    fetch("https://localhost:44331/api/Lotes")
        .then(response => response.json())
        .then(function (data) {
            document.getElementById("cmbLoteA").innerHTML = "";
            var cmbLote = document.getElementById("cmbLoteA");
            var lotA = document.createElement("option");
            lotA.text = "Selecciona un lote";
            cmbLote.appendChild(lotA).disabled = true;
            data.map(function (item) {
                var option = document.createElement("option");
                option.value = item.id;
                option.text = item.nombre;
                cmbLote.appendChild(option);
            });


        })


        .catch(err => console.log(err));
};