public class EquiposService : IEquiposService
{
    private readonly HttpClient _httpClient;
    

    public EquiposService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<List<EquipoDto>> ObtenerEquipos()
    {
        try
        {                        
            var equipos = _httpClient.GetFromJsonAsync<List<EquipoDto>>("");
            return equipos;
        } catch (Exception e)
        {
            return null;
        }
    }
    public Task<List<EquipoDto>> ObtenerEquipo(int id)
    {
        return null;
    }
    public Task<RespuestaServicioDto> AgregarEquipo(EquipoDto equipo)
    {
        return null;
    }
    public Task<RespuestaServicioDto> ModificarEquipo(EquipoDto equipo)
    {
        return null;
    }
    public Task<RespuestaServicioDto> EliminarEquipos(EquipoDto equipo)
    {
        return null;
    }
}