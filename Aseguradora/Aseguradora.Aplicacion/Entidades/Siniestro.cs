namespace Aseguradora.Aplicacion.Entidades;

public class Siniestro { 
    public int ID {get; set;}
    public string? DireccionDelHecho {get; set;}
    public string? DescripciónDelAccidente {get; set;}
    public DateTime FechaDeingreso {get;set;}
    public DateTime FechaDeOcurrencia {get;set;}
    public int PolizaId {get;set;}
    public List<Tercero> Terceros {get;set;} = new List<Tercero>();

    public Siniestro(){}

    public override String ToString(){
        return $"ID: {ID}, PolizaId: {PolizaId}, DireccionDelHecho: {DireccionDelHecho}, DescripciónDelAccidente: {DescripciónDelAccidente}, "+
        $"FechaDeingreso: {FechaDeingreso}, FechaDeOcurrencia: {FechaDeOcurrencia}";
    }

}