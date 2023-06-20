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
            if(context.Vehiculos.Any(v=>v.Dominio==vehiculo.Dominio))throw new Exception("El vehiculo ya existe");
            if(!context.Titulares.Any(t=>t.ID==vehiculo.TitularId))throw new Exception("No existe el titular especificado, no pudo ser agregado");
            if(tieneCamposVacios(vehiculo))throw new Exception("Debe completar todos los campos");
            context.Add(vehiculo);
            context.SaveChanges();
        }
    }

    private bool tieneCamposVacios(Vehiculo vehiculo)
    {
        return string.IsNullOrEmpty(vehiculo.Dominio) || string.IsNullOrEmpty(vehiculo.Marca);
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
            var registro = context.Vehiculos.SingleOrDefault(v => v.ID == id);
            if(registro == null) throw new Exception("El vehiculo no existe");

            context.Vehiculos.Remove(registro);
            context.SaveChanges();
            
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