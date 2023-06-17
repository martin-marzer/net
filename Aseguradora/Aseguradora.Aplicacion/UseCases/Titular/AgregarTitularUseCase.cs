using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class AgregarTitularUseCase  : TitularUseCase 
{
    public AgregarTitularUseCase(IRepositorioTitular repo) : base(repo)
    {
    }
    public void Ejecutar(Titular titular)
    {
        Repositorio.AgregarTitular(titular);
    }
}
