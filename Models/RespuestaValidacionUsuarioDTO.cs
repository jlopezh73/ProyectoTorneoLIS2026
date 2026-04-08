
public class RespuestaValidacionUsuarioDTO
{
    public bool correcto {get; set;}
    public UsuarioDTO? usuario {get; set;}
    public string token {get; set;}
}