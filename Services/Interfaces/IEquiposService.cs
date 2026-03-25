public interface IEquiposService
{

    public Task<List<EquipoDto>> ObtenerEquipos();
    public Task<List<EquipoDto>> ObtenerEquipo(int id);
    public Task<RespuestaServicioDto> AgregarEquipo(EquipoDto equipo) ;
    public Task<RespuestaServicioDto> ModificarEquipo(EquipoDto equipo);
    public Task<RespuestaServicioDto> EliminarEquipos(EquipoDto equipo);
}