using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
namespace Aseguradora.Repositorios;
public class RepositorioVehiculo:IRepositorioVehiculo
{
    public void AgregarVehiculo(Vehiculo vehiculo)
    {
        using (var context= new AseguradoraContext())
        {
            var registro= context.Titulares.FirstOrDefault(r=>r.ID==vehiculo.ID);//si no lo encuentra registro = null
            if(registro!=null)
            {
                context.Add(vehiculo);
                context.SaveChanges();
            }else Console.WriteLine("No se pudo agregar el vehiculo.");
            
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