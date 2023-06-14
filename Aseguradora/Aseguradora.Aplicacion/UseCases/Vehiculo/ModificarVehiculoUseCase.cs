using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class ModificarVehiculoUseCase : VehiculoUseCase
{
    public ModificarVehiculoUseCase(IRepositorioVehiculo repo) : base(repo)
    {
    }
    public void Ejecutar(Vehiculo vehiculo)
    {
        Repositorio.ModificarVehiculo(vehiculo);
    }
}
