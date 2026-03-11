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

function guardarEquipo() {
    $('#formaEquipo').validate();

    if ($('#formaEquipo').valid() === true) {
        $("#formaEquipo").submit();       
    } 
}