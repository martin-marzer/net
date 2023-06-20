using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Repositorios;

public class RepositorioPoliza : IRepositorioPoliza
{
    public Poliza? ObtenerPoliza(int id){
        using(var context = new AseguradoraContext()){
            var poliza = context.Polizas.SingleOrDefault(t => t.ID == id);
            return poliza;
        }
    }
    public void AgregarPoliza(Poliza poliza){
        using(var context = new AseguradoraContext()){
            if(!context.Vehiculos.Any(v=>v.ID==poliza.VehiculoId))throw new Exception("No existe ese id de vehiculo");
            if(tieneCamposVacios(poliza))throw new Exception("Debe completar todos los campos");
            context.Add(poliza);
            context.SaveChanges();
        }
    }

    private bool tieneCamposVacios(Poliza poliza)
    {
        return string.IsNullOrEmpty(poliza.Franquicia) || string.IsNullOrEmpty(poliza.TipoDeCobertura);
    }

    public void ModificarPoliza(Poliza poliza){
        using(var context = new AseguradoraContext()){
            var pBuscar = context.Polizas.SingleOrDefault(p => p.ID == poliza.ID);
            if(pBuscar == null) throw new Exception("La poliza no existe");
            pBuscar.FechaDeFinDeVigencia = poliza.FechaDeFinDeVigencia;
            pBuscar.FechaDeInicioDeVigencia = poliza.FechaDeInicioDeVigencia;
            pBuscar.Franquicia = poliza.Franquicia;
            pBuscar.TipoDeCobertura = poliza.TipoDeCobertura;
            pBuscar.ValorAsegurado = poliza.ValorAsegurado;
            context.SaveChanges();
        }
    }

    public void EliminarPoliza(int id){
        using(var context = new AseguradoraContext()){
            var poliza = context.Polizas.SingleOrDefault(p => p.ID == id);
            if(poliza == null) throw new Exception("La poliza a eliminar no existe");
            context.Remove(poliza);
            context.SaveChanges();
        }
    }

    public List<Poliza> ListarPolizas(){
        using(var context = new AseguradoraContext()){
            var polizas = context.Polizas.ToList();
            return polizas;
        }
    }
}