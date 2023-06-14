namespace Aseguradora.Aplicacion.Entidades;

public class Tercero : Persona{ 
    public string NombreAseguradora {get; set;} = "No tiene Nombre de Aseguradora";
    public int SiniestroId {get;set;}

    public Tercero(){}
    public Tercero(int dni, string apellido, string nombre, string tel, string nombreAseguradora, int siniestroId) : base(dni,apellido,nombre,tel){
        NombreAseguradora = nombreAseguradora;
        SiniestroId = siniestroId;
    }

    public override string ToString(){
        return $"{base.ToString} {NombreAseguradora} {SiniestroId}";
    }

}