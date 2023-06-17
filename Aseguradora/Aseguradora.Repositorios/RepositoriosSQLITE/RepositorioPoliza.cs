using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Repositorios;

public class RepositorioPoliza : IRepositorioPoliza{

    public void AgregarPoliza(Poliza poliza){
        using(var context = new AseguradoraContext()){
            var pAux = context.Vehiculos.SingleOrDefault(v => v.ID == poliza.VehiculoId);
            if(pAux == null) throw new Exception("No existe un vehiculo para dicha poliza");
            context.Add(poliza);
            context.SaveChanges();
        }
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