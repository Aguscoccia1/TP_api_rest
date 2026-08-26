namespace TpApiRest;

public abstract class Mascota
{
    private int id;
    private string nombre;

    private int edad;

    public int Id {get{ return this.id; } set { this.id = value; } }
    public string Nombre {get{ return this.nombre; } set { this.nombre = value; } }
    public int Edad {get{ return this.edad; } set { this.edad = value; } }

}
