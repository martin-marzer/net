namespace Aseguradora.Aplicacion.Entidades;

public class Titular : Persona{ 
    public string? Direccion {get; set;}
    public string? Email {get; set;}

    public List<Vehiculo> Vehiculos {get; set;} = new List<Vehiculo>(); //Se guardan los vehiculos pertenecientes al titular

    public Titular(){}

    public override string ToString(){
        return $"{base.ToString} {Direccion} {Email}";
    }

}