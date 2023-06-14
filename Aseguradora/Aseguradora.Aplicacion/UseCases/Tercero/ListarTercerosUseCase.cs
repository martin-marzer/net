using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class ListarTercerosUseCase  : TerceroUseCase 
{
    public ListarTercerosUseCase(IRepositorioTercero repo): base(repo)
    {
    }
    public List<Tercero> Ejecutar()
    {
        return Repositorio.ListarTerceros();
    }
}
