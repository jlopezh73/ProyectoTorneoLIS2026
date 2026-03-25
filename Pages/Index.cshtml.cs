using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Torneo2026LIS.Pages;

public class IndexModel : PageModel
{
    public List<EquipoDto> equipos { get; set; }

    [BindProperty]
    public EquipoDto equipo { get; set; }

    public void OnGet()
    {
        cargarEquipos();
        equipo = new EquipoDto();
    }

    public ActionResult OnGetEquipo(int id)
    {
        cargarEquipos();
        return new JsonResult(equipos.Where(e => e.Id == id).FirstOrDefault());
    }

    public ActionResult OnGetEliminar(int id)
    {
        cargarEquipos();
        eliminarEquipo(id);
        return new JsonResult(new { resultado = true });
    }

    public void OnPost()
    {
        if (equipo.Id == 0)
            agregarEquipo();
        else
            modificarEquipo();

        cargarEquipos();
    }


    private void cargarEquipos()
    {
        HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://localhost:5261/api/equipos");
        equipos = httpClient.GetFromJsonAsync<List<EquipoDto>>("").Result;
        
    }

    private void agregarEquipo()
    {
        HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://localhost:5261/api/equipos");
        var resultado = httpClient.PostAsJsonAsync<EquipoDto>("", equipo).Result;
    }

    
    private void eliminarEquipo(int id)
    {
        var equipoEli = equipos.First(e => e.Id == id);
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

/*
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    dotnet add package MySql.EntityFrameworkCore
    dotnet tool install -g dotnet-ef
*/
