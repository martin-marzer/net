using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
namespace Aseguradora.Repositorios;
public class RepositorioVehiculo:IRepositorioVehiculo
{
    public Vehiculo? ObtenerVehiculo(int id){
        using(var context = new AseguradoraContext()){
            var vehiculo = context.Vehiculos.SingleOrDefault(t => t.ID == id);
            return vehiculo;
        }
    }
    public void AgregarVehiculo(Vehiculo vehiculo)
    {
        using (var context= new AseguradoraContext())
        {
            if(context.Vehiculos.Any(v=>v.Dominio==vehiculo.Dominio))throw new Exception("probablemente ya exista ese vehiculo");
            if(!context.Titulares.Any(t=>t.ID==vehiculo.TitularId))throw new Exception("no existe ese titular no pudo ser agregado");
            context.Add(vehiculo);
            context.SaveChanges();
        }
    }

    public void ModificarVehiculo(Vehiculo vehiculo)
    {
        using (var context= new AseguradoraContext())
        {
            var registro= context.Vehiculos.FirstOrDefault(r=>r.ID==vehiculo.ID);//si no lo encuentra registro = null
            if(registro==null)throw new Exception("El vehiculo no existe");
            registro.Dominio=vehiculo.Dominio;
            registro.Marca=vehiculo.Marca;
            registro.AnioFabricacion=vehiculo.AnioFabricacion;
            context.SaveChanges();
            
        }
    }

    public void EliminarVehiculo(int id)
    {
        using (var context= new AseguradoraContext())
        {
            var registro= context.Vehiculos.FirstOrDefault(r=>r.ID==id);//si no lo encuentra registro = null
            if(registro!=null)
            {
                context.Vehiculos.Remove(registro);
                context.SaveChanges();
            }
        }
    }

    public List<Vehiculo> ListarVehiculos()
    {
        using (var dbContext = new AseguradoraContext())
        {
            var ListaDeVehiculos = dbContext.Vehiculos.ToList();
            return ListaDeVehiculos;
        }
    }
}