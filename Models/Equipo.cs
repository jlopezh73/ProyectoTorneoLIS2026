using System.ComponentModel.DataAnnotations;
public class Equipo
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Debe teclear un nombre de equipo")]
    public String Nombre { get; set; }

    [Required(ErrorMessage = "Debe proporcionar el nombre del representante")]
    public String Representante { get; set; }
    [Required(ErrorMessage = "Debe proporcionar el teléfono del representante")]
    public String Telefono { get; set; }

}

