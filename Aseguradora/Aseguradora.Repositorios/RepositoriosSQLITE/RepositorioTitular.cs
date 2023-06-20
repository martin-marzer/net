using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aseguradora.Repositorios;

public class RepositorioTitular : IRepositorioTitular{

    
    public Titular? ObtenerTitular(int id){
        using(var context = new AseguradoraContext()){
            var titular = context.Titulares.SingleOrDefault(t => t.ID == id);
            return titular;
        }
    }
    public void AgregarTitular(Titular titular){
        using(var context = new AseguradoraContext()){
            var tAux = context.Titulares.SingleOrDefault(t => t.DNI == titular.DNI);
            if(tAux != null)throw new Exception("El titular ya existe, no pudo ser agregado");
            if(tieneCamposVacios(titular))throw new Exception("Debe completar todos los campos");
            context.Add(titular);
            context.SaveChanges();
        }   
    }

    private bool tieneCamposVacios(Titular titular)
    {
        return string.IsNullOrEmpty(titular.Nombre) || string.IsNullOrEmpty(titular.Apellido) || string.IsNullOrEmpty(titular.Telefono) ||
        string.IsNullOrEmpty(titular.Email) || string.IsNullOrEmpty(titular.Direccion); 
    }

    public void ModificarTitular(Titular titular){
        using(var context = new AseguradoraContext()){
            var tAux = context.Titulares.SingleOrDefault(t => t.ID == titular.ID);
            if(tAux == null) throw new Exception("El titular no existe");
            tAux.Apellido = titular.Apellido;
            tAux.Direccion = titular.Direccion;
            tAux.DNI = titular.DNI;
            tAux.Email = titular.Email;
            tAux.Nombre = titular.Nombre;
            tAux.Telefono = titular.Telefono;
            context.SaveChanges();
        }
    }

    public void EliminarTitular(int id){
        using(var context = new AseguradoraContext()){
            var tAux = context.Titulares.SingleOrDefault(t => t.ID == id);
            if(tAux == null) throw new Exception("El titular no existe");
            context.Remove(tAux);
            context.SaveChanges();
        }
    }

    public List<Titular> ListarTitulares(){
        using(var context = new AseguradoraContext()){
            var titulares = context.Titulares.ToList();
            return titulares;
        }
    }

    public List<Titular> ListarTitularesConSusVehiculos()
    {
        using(var context = new AseguradoraContext())
        {
            return context.Titulares.Include(t => t.Vehiculos).ToList();
        }
    }

    
}