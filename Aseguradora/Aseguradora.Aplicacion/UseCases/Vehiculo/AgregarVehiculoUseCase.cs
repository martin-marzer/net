using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class AgregarVehiculoUseCase  : VehiculoUseCase 
{
    public AgregarVehiculoUseCase(IRepositorioVehiculo repo) : base(repo)
    {
    }
    public void Ejecutar(Vehiculo vehiculo)
    {
        Repositorio.AgregarVehiculo(vehiculo);
    }
}
