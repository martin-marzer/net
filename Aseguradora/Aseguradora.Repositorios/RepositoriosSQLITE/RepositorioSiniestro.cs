using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Repositorios;

class RepositorioSiniestro : IRepositorioSiniestro
{    public void AgregarSiniestro(Siniestro siniestro)
    {
        using (var context = new AseguradoraContext())
        {
            var poliza = context.Polizas.FirstOrDefault(p => p.ID == siniestro.PolizaId);
            if (poliza != null) {
                if (poliza.FechaDeFinDeVigencia < siniestro.FechaDeOcurrencia){
                    context.Add(siniestro);
                    context.SaveChanges();
                } else Console.WriteLine($"no podes registrar el siniestro de la fecha {siniestro.FechaDeOcurrencia}  porque tu seguro vencio el dia {poliza.FechaDeFinDeVigencia}");
            } else Console.WriteLine("lo siento compadre, no existe ese id de poliza, intenta de nuevo ");
        }
    }

    public void ModificarSiniestro(Siniestro siniestroABuscar)
    {
        
        using (var context = new AseguradoraContext())
        {
            var existePolizaID = context.Polizas.Any(p => p.ID == siniestroABuscar.PolizaId);
            if (existePolizaID) {
                var siniestroEncontrado = context.Siniestros.FirstOrDefault(s => s.ID == siniestroABuscar.ID);
                if (siniestroEncontrado != null) {

                    siniestroEncontrado.DireccionDelHecho = siniestroABuscar.DireccionDelHecho;
                    siniestroEncontrado.DescripciónDelAccidente = siniestroABuscar.DescripciónDelAccidente;
                    siniestroEncontrado.FechaDeingreso = siniestroABuscar.FechaDeingreso;
                    siniestroEncontrado.FechaDeOcurrencia = siniestroABuscar.FechaDeOcurrencia;
                    siniestroEncontrado.PolizaId = siniestroABuscar.PolizaId;

                    context.SaveChanges();        
                } else Console.WriteLine("lo siento compadre, no existe el siniestro con ese ID, intenta de nuevo ");
            }  else Console.WriteLine("lo siento compadre, el Id de poliza que queres poner no existe, creala antes.");
            
        }
    }





    public void EliminarSiniestro(int ID)
    {
        using (var context = new AseguradoraContext())
        {
            var siniestroElim = context.Siniestros.FirstOrDefault(s => s.ID == ID);
            if (siniestroElim != null) {
                context.RemoveRange(siniestroElim);
                context.SaveChanges();        
            } else Console.WriteLine("lo siento compadre, no existe el siniestro con ese ID, intenta de nuevo ");
        }
    }


    public List<Siniestro> ListarSiniestros()
    {
        using (var context = new AseguradoraContext())
        {
            var listaSiniestros = context.Siniestros.ToList();
            return listaSiniestros;
        }
        
    }
}