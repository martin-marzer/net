using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Repositorios;
public class RepositorioTercero : IRepositorioTercero
{
    public Tercero? ObtenerTercero(int id){
        using(var context = new AseguradoraContext()){
            var tercero = context.Terceros.SingleOrDefault(t => t.ID == id);
            return tercero;
        }
    }
    public void AgregarTercero(Tercero tercero)
    {
        using (var context= new AseguradoraContext())
        {
             if(!context.Siniestros.Any(s=>s.ID==tercero.SiniestroId))throw new Exception("no existe ese Siniestro, no pudo ser agregado");
            context.Add(tercero);
            context.SaveChanges();
        }
    }

    public void ModificarTercero(Tercero terceroModificado)
    {
        using (var context= new AseguradoraContext())
        {
             var terceroEncontrado = context.Terceros.FirstOrDefault(s => s.ID == terceroModificado.ID);
            if (terceroEncontrado == null) throw new Exception("lo siento compadre, no existe ese Tercero, intenta de nuevo ");

            if(!context.Siniestros.Any(s => s.ID == terceroModificado.SiniestroId)) throw new Exception("el id del siniestro no es valido, intenta de nuevo ");

                terceroEncontrado.Apellido =  terceroModificado.Apellido;
                terceroEncontrado.Nombre = terceroModificado.Nombre;
                terceroEncontrado.DNI = terceroModificado.DNI;
                terceroEncontrado.Telefono = terceroModificado.Telefono;
                terceroEncontrado.NombreAseguradora = terceroModificado.NombreAseguradora;
                context.SaveChanges();
        }
    }

    public void EliminarTercero(int id)
    {
        using (var context= new AseguradoraContext())
        {
            var registro= context.Terceros.FirstOrDefault(r=>r.ID==id);//si no lo encuentra registro = null
            if(registro == null) throw new Exception("No se pudo eliminar, el tercero no existe");
            context.Terceros.Remove(registro);
            context.SaveChanges();
        }
    }

    public List<Tercero> ListarTerceros()
    {
        using (var context = new AseguradoraContext())
        {
            var ListaDeTerceros = context.Terceros.ToList();
            return ListaDeTerceros;
        }
    }
}