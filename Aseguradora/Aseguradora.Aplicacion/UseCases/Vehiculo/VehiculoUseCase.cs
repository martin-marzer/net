using Aseguradora.Aplicacion.Interfaces;
namespace Aseguradora.Aplicacion.UseCases;
public abstract class VehiculoUseCase
{
    protected IRepositorioVehiculo Repositorio { get; private set; }
    public VehiculoUseCase(IRepositorioVehiculo repositorio)
    {
        this.Repositorio = repositorio;
    }
}