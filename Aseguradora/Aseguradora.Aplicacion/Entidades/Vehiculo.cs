namespace Aseguradora.Aplicacion.Entidades;

public class Vehiculo
{
    public int ID {get;set;} = -1;
    public string Dominio {get;set;} = "No tiene dominio";
    public string Marca {get;set;} = "No tiene marca";
    public int AnioFabricacion {get;set;}
    public int TitularId {get;set;}


    public Vehiculo(){}
    public Vehiculo(string dominio, string marca, int anio, int idTitular)
    {
        Dominio = dominio;
        Marca = marca;
        AnioFabricacion = anio;
        TitularId = idTitular;
    }

    public override string ToString()
    {
        return $"ID del vehiculo {ID}, Año Fabricacion {AnioFabricacion}, Marca {Marca}, Dominio {Dominio}, ID del titular {TitularId} ";
    }
}