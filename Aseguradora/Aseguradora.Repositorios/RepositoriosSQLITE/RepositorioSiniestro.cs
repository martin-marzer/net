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
            if (poliza == null) throw new Exception("El id de la poliza no es valido");
            if(tieneCamposVacios(siniestro))throw new Exception("Debe completar todos los campos");
            if (poliza.FechaDeFinDeVigencia <= siniestro.FechaDeOcurrencia) throw new Exception($"No se puede registrar el siniestro de la fecha {siniestro.FechaDeOcurrencia}  porque tu seguro ya vencio en {poliza.FechaDeFinDeVigencia}");
            
            context.Add(siniestro);
            context.SaveChanges();
        }
    }
    
    private bool tieneCamposVacios(Siniestro siniestro)
    {
        return string.IsNullOrEmpty(siniestro.DescripcionDelAccidente) || string.IsNullOrEmpty(siniestro.DireccionDelHecho);
    }

    public void ModificarSiniestro(Siniestro siniestroModificado)
    {
        
        using (var context = new AseguradoraContext())
        {
            var siniestroEncontrado = context.Siniestros.FirstOrDefault(s => s.ID == siniestroModificado.ID);
            if (siniestroEncontrado == null) throw new Exception("El siniestro no existe");
            
            if(!context.Polizas.Any(v => v.ID == siniestroModificado.PolizaId)) throw new Exception("El id de la poliza no es valido");

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
            } else Console.WriteLine("No existe ese siniestro");
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