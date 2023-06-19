namespace Aseguradora.Aplicacion.Entidades;

public class Tercero : Persona{ 
    public string? NombreAseguradora {get; set;}
    public int SiniestroId {get;set;}

    public Tercero(){}

    public override string ToString(){
        return $"{base.ToString} {NombreAseguradora} {SiniestroId}";
    }

}