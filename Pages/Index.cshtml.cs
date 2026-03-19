using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Torneo2026LIS.Pages;

public class IndexModel : PageModel
{
    public List<Equipo> equipos { get; set; }

    [BindProperty]
    public Equipo equipo { get; set; }

    public void OnGet()
    {
        cargarEquipos();
        equipo = new Equipo();

    }
    
    public ActionResult OnGetEquipo(int id)
    {
        cargarEquipos();
        return new JsonResult(equipos.Where(e => e.Id == id).FirstOrDefault());
    }

    public void OnPost()
    {
        cargarEquipos();
        if (equipo.Id == 0)
            agregarEquipo();
        else
            modificarEquipo();
    }
    

    private void cargarEquipos()
    {
        var cadJson = HttpContext.Session.GetString("equipos");
        if (cadJson == null)
        {
            equipos = new List<Equipo>()
            {
                new Equipo() {Id=1,
                            Nombre="Club América",
                            Representante="Pedro Sánchez",
                            Telefono="5523896712"},
                new Equipo() {Id=2,
                            Nombre="Club Chivas del Guadalajara",
                            Representante="Martha Higareda",
                            Telefono="7823490876"},
                new Equipo() {Id=3,
                            Nombre="Club Cruz Azul",
                            Representante="Martín Porras",
                            Telefono="5500996212"},
                new Equipo() {Id=4,
                            Nombre="Club Pumas",
                            Representante="Hugo Sánchez",
                            Telefono="5578289312"},
            };

            guardarEquiposSesion();
        } else
        {
            equipos = System.Text.Json.JsonSerializer.Deserialize<List<Equipo>>(cadJson);
        }
    }

    private void agregarEquipo()
    {
        equipo.Id = equipos.Max(e => e.Id) + 1;
        equipos.Add(equipo);
        //guardarEquiposSesion();
    }

    private void guardarEquiposSesion()
    {
        String cadJson = System.Text.Json.JsonSerializer.Serialize<List<Equipo>>(equipos);
        HttpContext.Session.SetString("equipos", cadJson);
    }

    private void eliminarEquipo()
    {
        var equipoEli = equipos.First(e => e.Id == equipo.Id);
        equipos.Remove(equipoEli);
        guardarEquiposSesion();
    }

    private void modificarEquipo()
    {
        var equipoModi = equipos.First(e => e.Id == equipo.Id);
        equipoModi.Id = equipo.Id;
        equipoModi.Nombre = equipo.Nombre;
        equipoModi.Representante = equipo.Representante;
        equipoModi.Telefono = equipo.Telefono;
        guardarEquiposSesion();
    }
}
