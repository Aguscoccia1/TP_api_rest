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


    [HttpGet("/Mascota/mayores-a/{edad}")]

    public IActionResult GerByEdad(int edad)
    {
        List<Mascota> mascotasMayores = new();
        foreach(Mascota m in listaMascotas)
        {
            if (m.Edad > edad)
            {
                mascotasMayores.Add(m);
            }
           
        }
       
        return Ok(mascotasMayores);
           
    }


    [HttpGet("/Mascota/tipo/{tipo}")]

    public IActionResult GetByTipo(string tipo)
    {
        List<Mascota> mascotasTipo = new();
        foreach(Mascota m in listaMascotas)
        {
            if (tipo.ToLower() == "perro" && m is Perro)
            {
                mascotasTipo.Add(m);
            }
            else if (tipo.ToLower() == "gato" && m is Gato)
            {
                mascotasTipo.Add(m);
            }
        }
       
        return Ok(mascotasTipo);
           
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


    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {
        foreach (Mascota p in listaMascotas)
        {
            if(p.Id == id)
            {
                listaMascotas.Remove(p);
                return Ok ("Mascota eliminada");
            }
        }


        return NotFound("Mascota no encontrada");
    }


    [HttpPut("{id}")]

    public IActionResult updateMascota (int id, [FromBody] Mascota MascotaActualizada)
    {
        foreach (Mascota m in listaMascotas )
        {
           
            if(m.Id == id && m is Gato gato && MascotaActualizada is Gato Gatoactualizado)
            {
                gato.Nombre = Gatoactualizado.Nombre;
                gato.Edad = Gatoactualizado.Edad;
                gato.Color = Gatoactualizado.Color;


                return Ok("Gato actualizado");
            }
            else if (m.Id == id && m is Perro perro && MascotaActualizada is Perro Perroactualizado)
            {
                perro.Nombre = Perroactualizado.Nombre;
                perro.Edad = Perroactualizado.Edad;
                perro.Raza = Perroactualizado.Raza;


                return Ok("Perro actualizado");
            }
        }

        return NotFound("Mascota no encontrada");
    }
}