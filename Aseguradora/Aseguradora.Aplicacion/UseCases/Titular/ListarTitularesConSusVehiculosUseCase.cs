using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class ListarTitularesConSusVehiculosUseCase : TitularUseCase{
    private readonly IRepositorioVehiculo _repoVehiculos;
    
    public ListarTitularesConSusVehiculosUseCase(IRepositorioTitular repo, IRepositorioVehiculo repoVehiculo) : base(repo)
    {
        this._repoVehiculos = repoVehiculo;
    }

    public List<Titular> Ejecutar(int DNI)
    {
        List<Titular> listaTitulares = Repositorio.ListarTitulares(); //Obtengo todos los titulares
        List<Vehiculo> listaVehiculos = _repoVehiculos.ListarVehiculos(); //Obtengo todos los vehiculos
        foreach(Titular titular in listaTitulares){
            foreach(Vehiculo v in listaVehiculos){
                if(v.TitularId == titular.ID) //Si encuentro un vehiculo que corresponde al titular actual
                    titular.listaVehiculos.Add(v); //Agrego el vehiculo que coincide a la lista de vehiculos
            }                                      //del titular
        }
        return listaTitulares;
    }
}