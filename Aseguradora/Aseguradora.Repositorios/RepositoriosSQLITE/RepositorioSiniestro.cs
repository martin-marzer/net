using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Repositorios;

public class RepositorioSiniestro : IRepositorioSiniestro 
{   
    public Siniestro? ObtenerSiniestro(int id){
        using(var context = new AseguradoraContext()){
            var siniestro = context.Siniestros.SingleOrDefault(t => t.ID == id);
            return siniestro;
        }
    }
    public void AgregarSiniestro(Siniestro siniestro)
    {
        using (var context = new AseguradoraContext())
        {
            var poliza = context.Polizas.FirstOrDefault(p => p.ID == siniestro.PolizaId);
            if (poliza == null) throw new Exception("lo siento compadre, no existe ese id de poliza, intenta de nuevo ");

            if (poliza.FechaDeFinDeVigencia <= siniestro.FechaDeOcurrencia) throw new Exception($"no podes registrar el siniestro de la fecha {siniestro.FechaDeOcurrencia}  porque tu seguro ya vencio {poliza.FechaDeFinDeVigencia}");
            
            context.Add(siniestro);
            context.SaveChanges();
        }
    }

    public void ModificarSiniestro(Siniestro siniestroModificado)
    {
        
        using (var context = new AseguradoraContext())
        {
            var siniestroEncontrado = context.Siniestros.FirstOrDefault(s => s.ID == siniestroModificado.ID);
            if (siniestroEncontrado == null) throw new Exception("lo siento compadre, no existe ese siniestro, intenta de nuevo ");
            
            if(!context.Polizas.Any(v => v.ID == siniestroModificado.PolizaId)) throw new Exception("el id de la poliza no es valido, intenta de nuevo ");

            siniestroEncontrado.DireccionDelHecho =  siniestroModificado.DireccionDelHecho;
            siniestroEncontrado.DescripcionDelAccidente = siniestroModificado.DescripcionDelAccidente;
            siniestroEncontrado.FechaDeingreso = siniestroModificado.FechaDeingreso;
            siniestroEncontrado.FechaDeOcurrencia = siniestroModificado.FechaDeOcurrencia;

            context.SaveChanges();
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