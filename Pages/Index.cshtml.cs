using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Torneo2026LIS.Pages;

public class IndexModel : PageModel
{
    public List<EquipoDto> equipos { get; set; }

    [BindProperty]
    public EquipoDto equipo { get; set; }
    private IEquiposService equiposService;

    public IndexModel(IEquiposService _equiposService)
    {
        equiposService = _equiposService;
    }

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
        try
        {
            /*HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5261/api/equipos");
            equipos = httpClient.GetFromJsonAsync<List<EquipoDto>>("").Result;*/
            equipos = equiposService.ObtenerEquipos().Result;
        } catch (Exception e) {
            equipos = new List<EquipoDto>();
        }
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
        HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://localhost:5261/api/equipos");
        var resultado = httpClient.PutAsJsonAsync<EquipoDto>($"/", equipo).Result;
    }
}

/*
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    dotnet add package MySql.EntityFrameworkCore
    dotnet tool install -g dotnet-ef
*/
