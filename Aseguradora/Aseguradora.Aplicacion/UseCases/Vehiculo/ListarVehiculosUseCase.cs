using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class ListarVehiculosUseCase  : VehiculoUseCase 
{
    public ListarVehiculosUseCase(IRepositorioVehiculo repo): base(repo)
    {
    }
    public List<Vehiculo> Ejecutar()
    {
        return Repositorio.ListarVehiculos();
    }
}
