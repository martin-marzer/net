namespace Aseguradora.Aplicacion.Entidades;

public class Vehiculo
{
    public int ID {get;set;}
    public string? Dominio {get;set;}
    public string? Marca {get;set;}
    public int AnioFabricacion {get;set;}
    public int TitularId {get;set;}
    public List<Poliza> Polizas {get;set;} = new List<Poliza>();


    public Vehiculo(){}

    public override string ToString()
    {
        return $"ID del vehiculo {ID}, Año Fabricacion {AnioFabricacion}, Marca {Marca}, Dominio {Dominio}, ID del titular {TitularId} ";
    }
}