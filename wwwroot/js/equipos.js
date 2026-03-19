$(document).ready(function() {
    $("#btnAgregar").on("click", agregarEquipo);
    $("#guardar").on("click", guardarEquipo);
});


function agregarEquipo() {
    $("#idEquipo").val("");
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