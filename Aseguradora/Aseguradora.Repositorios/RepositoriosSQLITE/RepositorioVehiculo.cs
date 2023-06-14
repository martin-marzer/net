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
            if(registro!=null)
            {
                /////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Ingrese el nuevo valor para dominio (deje en blanco para mantener el valor actual):");
                string? nuevoDominio= Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevoDominio))
                {
                    registro.Dominio = nuevoDominio;
                }


                /////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Ingrese el nuevo valor para la marca (deje en blanco para mantener el valor actual):");
                string? nuevaMarca = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevaMarca))
                {
                    registro.Marca = nuevaMarca;
                }


                /////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Ingrese el nuevo valor para el año de fabricacion (deje en blanco para mantener el valor actual):");
                string? entrada= Console.ReadLine();
                
                int nuevoAnioFabricacion;

                bool exito= int.TryParse(entrada,out nuevoAnioFabricacion);
                if(!exito)
                {
                    nuevoAnioFabricacion=0;
                }  //si no se pudo convertir se le coloca el valor 0.
                
                
                if ((nuevoAnioFabricacion>=1769) && (nuevoAnioFabricacion<=DateTime.Now.Year)) //en 1769 se fabrico el primer vehiculo a vapor
                {
                    registro.AnioFabricacion = nuevoAnioFabricacion;
                }else Console.WriteLine("Año de fabricacion no válido, no se pudo modificar.");


                /////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Ingrese el nuevo valor para el id del titular (deje en blanco para mantener el valor actual):");
                entrada = Console.ReadLine();
                int nuevoIDtitular;

                exito= int.TryParse(entrada,out nuevoIDtitular);
                if(!exito)
                {
                    nuevoIDtitular=0;
                } 
                var registroT= context.Titulares.FirstOrDefault(r=>r.ID==nuevoIDtitular); //busca si el titular con la id nueva existe
                if (nuevoIDtitular>0 && registro!=null)
                {
                    registro.TitularId = nuevoIDtitular;

                }else Console.WriteLine("ID del titular no válido, no se pudo modificar.");

                
                context.SaveChanges();
            }
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