using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class ListarTitularesUseCase  : TitularUseCase 
{
    public ListarTitularesUseCase(IRepositorioTitular repo): base(repo)
    {
    }
    public List<Titular> Ejecutar()
    {
        return Repositorio.ListarTitulares();
    }
}
