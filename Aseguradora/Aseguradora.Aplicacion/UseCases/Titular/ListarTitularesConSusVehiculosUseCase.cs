using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class ListarTitularesConSusVehiculosUseCase : TitularUseCase{

    
    public ListarTitularesConSusVehiculosUseCase(IRepositorioTitular repo) : base(repo)
    {}

    public List<Titular> Ejecutar()
    {
        return Repositorio.ListarTitularesConSusVehiculos();
    }
}