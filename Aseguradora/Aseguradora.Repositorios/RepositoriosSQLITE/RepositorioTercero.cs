using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Repositorios;
public class RepositorioTercero : IRepositorioTercero
{
    public void AgregarTercero(Tercero tercero)
    {
        using (var context= new AseguradoraContext())
        {
            context.Add(tercero);
            context.SaveChanges();
        }
    }

    public void ModificarTercero(Tercero tercero)
    {
        using (var context= new AseguradoraContext())
        {
            var registro= context.Terceros.FirstOrDefault(r=>r.ID==tercero.ID);//si no lo encuentra registro = null
            if(registro!=null)
            {
                /////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Ingrese el nuevo valor para el apellido (deje en blanco para mantener el valor actual):");
                string? nuevoApellido= Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevoApellido))
                {
                    registro.Apellido = nuevoApellido;
                }else Console.WriteLine("Apellido no valido");


                /////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Ingrese el nuevo valor para el nombre (deje en blanco para mantener el valor actual):");
                string? nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevoNombre))
                {
                    registro.Nombre = nuevoNombre;
                }else Console.WriteLine("Nombre no valido");

                /////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Ingrese el nuevo valor para el nombre de la aseguradora (deje en blanco para mantener el valor actual):");
                string? nuevoNombreAseguradora = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevoNombreAseguradora))
                {
                    registro.NombreAseguradora = nuevoNombreAseguradora;
                }else Console.WriteLine("Nombre de la aseguradora no valido");


                /////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Ingrese el nuevo valor para el DNI (deje en blanco para mantener el valor actual):");
                string? entrada= Console.ReadLine();
                
                int nuevoDNI;

                bool exito= int.TryParse(entrada,out nuevoDNI);
                if(!exito)
                {
                    nuevoDNI=0;
                }  //si no se pudo convertir se le coloca el valor 0.
                
                
                if (nuevoDNI>0)
                {
                    registro.DNI = nuevoDNI;
                }else Console.WriteLine("DNI no válido, no se pudo modificar.");


                /////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Ingrese el nuevo valor para el id del siniestro (deje en blanco para mantener el valor actual):");
                entrada = Console.ReadLine();
                int nuevoIDsiniestro;

                exito= int.TryParse(entrada,out nuevoIDsiniestro);
                if(!exito)
                {
                    nuevoIDsiniestro=0;
                } 
                var registroS= context.Siniestros.FirstOrDefault(r=>r.ID==nuevoIDsiniestro); //busca si el siniestro con la id nueva existe
                if (nuevoIDsiniestro>0 && registroS!=null)
                {
                    registro.SiniestroId = nuevoIDsiniestro;

                }else Console.WriteLine("ID del siniestro no válido, no se pudo modificar.");

                
                context.SaveChanges();
            }
        }
    }

    public void EliminarTercero(int id)
    {
        using (var context= new AseguradoraContext())
        {
            var registro= context.Terceros.FirstOrDefault(r=>r.ID==id);//si no lo encuentra registro = null
            if(registro!=null)
            {
                context.Terceros.Remove(registro);
                context.SaveChanges();
            }
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