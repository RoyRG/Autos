﻿let urlCentral = "https://localhost:44331/api/Lotes";
let row;
var Obtener = () => {
    fetch(urlCentral)
        .then(response => response.json())
        .then(function (data) {
            document.getElementById("tblLote").innerHTML = "";
            data.map(function (item) {
                var tabla = document.getElementById("tblLote");
                var tr = document.createElement("tr");
                var colId = document.createElement("th");
                var colLote = document.createElement("th");
                var actualizar = document.createElement("th");
                var eliminar = document.createElement("th");
                colId.innerHTML = item.id;
                colLote.innerHTML = item.nombre;
                actualizar.innerHTML += '<input type="button" value ="' + "Actualizar" + ' "class="btn btn-success editar edit-modal btn btn-warning botonEditar" data-target= "#imodal" data-toggle="modal" onclick="CargaId()">';
                eliminar.innerHTML += '<input type="button" value ="' + "Borrar" + ' "class="btn btn-danger editar edit-modal botonEliminar"  data-target= "#eliminar" data-toggle="modal" onclick="CargaId()">';
                tabla.appendChild(tr);
                tr.appendChild(colId).style.display = 'none';
                tr.appendChild(colLote);
                tr.appendChild(actualizar);
                tr.appendChild(eliminar);
            });
        })
        .catch(err => console.log(err));
}
const Agregar = async () => {

    let loteAgrega = document.getElementById("txtLoteA").value;
    let _data = {
        nombre: `${loteAgrega}`,
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
    location.reload();
}
const Modificar = async () => {

    let id1 = row;
    let loteModifica = document.getElementById("txtLote").value;
    
    let _data = {
        id: `${id1}`,
        nombre: `${loteModifica}`,

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
    location.reload();
}

var CargaId = () => {

    $(document).on('click', '.botonEditar', function (e) {
        row = $(this).parents('tr').children().eq(0).text();
        console.log(row);
    });
    
    $(document).on('click', '.botonEliminar', function (e) {
        row1 = $(this).parent().parent().children().first().text();
        console.log(row);
    });
    CargaTexto();
}
var CargaTexto = () => {
    $(document).on('click', '.botonEditar', function (e) {
        nom = $(this).parents('tr').children().eq(1).text();
        document.getElementById("txtLote").value = `${nom}`;
    });
}
