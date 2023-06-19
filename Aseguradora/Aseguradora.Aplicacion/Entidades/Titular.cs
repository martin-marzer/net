namespace Aseguradora.Aplicacion.Entidades;

public class Titular : Persona{ 
    public string? Direccion {get; set;}
    public string? Email {get; set;}

    public List<Vehiculo> listaVehiculos {get; set;} = new List<Vehiculo>(); //Se guardan los vehiculos pertenecientes al titular

    public Titular(){}
    public Titular(int dni, string apellido, string nombre, string tel, string direccion, string email) : base(dni,apellido,nombre, tel){
        Direccion = direccion;
        Email = email;
    }

    public override string ToString(){
        return $"{base.ToString} {Direccion} {Email}";
    }

}