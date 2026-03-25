$(document).ready(function() {
    $("#btnAgregar").on("click", agregarEquipo);
    $("#btnEliminarEquipo").on("click", eliminarEquipo);
    $("#guardar").on("click", guardarEquipo);
});


function agregarEquipo() {
    $("#idEquipo").val("0");
    $("#nombre").val("");
    $("#representante").val("");
    $("#telefono").val("");
    $("#dialogoEquipo").modal("show");
}

function editarEquipo(id) {
    $.ajax({
        url: "/Index?handler=Equipo&id="+id,
        success: function(data) {
            console.log(data);
            $("#idEquipo").val(data.id);
            $("#nombre").val(data.nombre);
            $("#representante").val(data.representante);
            $("#telefono").val(data.telefono);
            $("#dialogoEquipo").modal("show");
        }        
    });
    
}

function guardarEquipo() {
    $('#formaEquipo').validate();

    if ($('#formaEquipo').valid() === true) {
        $("#idEquipo").prop("disabled",false);    
        $("#formaEquipo").submit();       
    } 
}

let idEquipoEliminar;
function mostrarDialogoEliminar(idEquipo, nombreEquipo) {
    $("#nombreEquipoEliminar").html(nombreEquipo);
    idEquipoEliminar = idEquipo;
    $("#dialogoEliminar").modal("show");
}

function eliminarEquipo() {
    $.ajax({
        url: "/Index?handler=Eliminar&id="+idEquipoEliminar,
        success: function(data) {            
            alert("Equipo eliminado de forma satisfactoria");
            document.location = "/Index";
        }        
    });
    
}