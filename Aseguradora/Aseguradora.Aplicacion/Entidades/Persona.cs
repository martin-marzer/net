namespace Aseguradora.Aplicacion.Entidades;

public abstract class Persona{
    public int ID{get; set;}
    public int DNI{get; set;}
    public string? Apellido{get; set;}
    public string? Nombre{get; set;}
    public string? Telefono {get; set;}

    public Persona(){}

    public override string ToString(){
        return $"{ID}: {DNI} {Apellido} {Nombre} {Telefono}";
    }
}