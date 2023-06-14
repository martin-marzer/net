using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class ListarPolizasUseCase  : PolizaUseCase 
{
    public ListarPolizasUseCase(IRepositorioPoliza repo): base(repo)
    {
    }
    public List<Poliza> Ejecutar()
    {
        return Repositorio.ListarPolizas();
    }
}
