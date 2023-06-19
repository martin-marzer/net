namespace Aseguradora.Aplicacion.Entidades;
public class Poliza
{
    public int ID {get; set;}
    public double ValorAsegurado {get;set;}
    public string? Franquicia {get;set;}
    public string? TipoDeCobertura {get;set;}
    public DateTime FechaDeInicioDeVigencia {get;set;}
    public DateTime FechaDeFinDeVigencia {get;set;}
    public int VehiculoId {get;set;}
    public List<Siniestro> Siniestros {get;set;} = new List<Siniestro>();

    public Poliza(){}

    public override String ToString(){
        return $"ID: {ID}, VehiculoId: {VehiculoId}, valorAsegurado: {ValorAsegurado}, "+ 
        $"franquicia: {Franquicia}, tipoDeCobertura: {TipoDeCobertura}, fechaDeInicioDeVigencia: {FechaDeInicioDeVigencia}, "+
        $"fechaDeFinDeVigencia: {FechaDeFinDeVigencia}";
    }
}