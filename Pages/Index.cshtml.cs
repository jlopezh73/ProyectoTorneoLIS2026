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

    public void OnPost()
    {
        cargarEquipos();
        agregarEquipo();
    }

    private void cargarEquipos()
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
    }

    private void agregarEquipo()
    {
        equipo.Id = equipos.Max(e => e.Id) + 1;
        equipos.Add(equipo);
    }

    private void eliminarEquipo()
    {
        var equipoEli = equipos.First(e => e.Id == equipo.Id);
        equipos.Remove(equipoEli);
    }

    private void modificarEquipo()
    {
        var equipoModi = equipos.First(e => e.Id == equipo.Id);
        equipoModi.Id = equipo.Id;
        equipoModi.Nombre = equipo.Nombre;
        equipoModi.Representante = equipo.Representante;
        equipoModi.Telefono = equipo.Telefono;
    }
}
