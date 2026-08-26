using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace TpApiRest;


[ApiController]
[Route("[controller]")]
public class MascotaController : ControllerBase
{
    private static readonly List<Mascota> listaMascotas = new ()
    {
        new Perro {Id = 1, Nombre = "Firulais", Edad = 5, Raza = "Labrador" },
        new Gato {Id = 2, Nombre = "Luna", Edad = 3, Color = "Naranja" },
        new Perro {Id = 3, Nombre = "Rocky", Edad = 8, Raza = "Bulldog" },
        new Gato {Id = 4, Nombre = "Michi", Edad = 10, Color = "Blanco" },

    };  

    private readonly ILogger<MascotaController> _logger;

    public MascotaController(ILogger<MascotaController> logger)
    {
        _logger = logger;
    }



    [HttpGet]

    public IActionResult Get()
    {
        return Ok(listaMascotas);
    }


    [HttpGet("{id}")]

    public IActionResult Getbyid(int id)
    {
        foreach(Mascota m in listaMascotas)
        {
            if (m.Id == id)
            {
                return Ok(m);
            }
           
        }
       
        return NotFound("Mascota no encontrada");
           
    }


    [HttpPost("perro")]

    public IActionResult create([FromBody]Perro NuevoPerro)
    {
        listaMascotas.Add (NuevoPerro);
        return Ok("Perro registrado");
    }




    [HttpPost("gato")]

    public IActionResult create([FromBody]Gato NuevoGato)
    {
        listaMascotas.Add (NuevoGato);
        return Ok("Gato registrado");
    }
}