namespace Aseguradora.Aplicacion.Entidades;

public class Siniestro { 
    public int ID {get; set;} = -1; 
    public string DireccionDelHecho {get; set;} = "No tiene direccion";
    public string DescripciónDelAccidente {get; set;} = "No tiene descripcion";
    public DateTime FechaDeingreso {get;set;}
    public DateTime FechaDeOcurrencia {get;set;}
    public int PolizaId {get;set;}
    public List<Tercero>? terceros {get;set;}

    public Siniestro(){}
    public Siniestro(int polizaId, String direccion, String email,String direccionDelHecho, String descripciónDelAccidente, 
                    DateTime fechaDeOcurrencia){
        PolizaId=polizaId;
        DireccionDelHecho=direccionDelHecho;
        DescripciónDelAccidente = descripciónDelAccidente;
        FechaDeingreso=DateTime.Now;
        FechaDeOcurrencia=fechaDeOcurrencia;
    }

    public override String ToString(){
        return $"ID: {ID}, PolizaId: {PolizaId}, DireccionDelHecho: {DireccionDelHecho}, DescripciónDelAccidente: {DescripciónDelAccidente}, "+
        $"FechaDeingreso: {FechaDeingreso}, FechaDeOcurrencia: {FechaDeOcurrencia}";
    }

}