using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class ObtenerVehiculoUseCase  : VehiculoUseCase 
{
    public ObtenerVehiculoUseCase(IRepositorioVehiculo repo) : base(repo)
    {
    }
    public Vehiculo? Ejecutar(int id)
    {
        return Repositorio.ObtenerVehiculo(id);
    }
}