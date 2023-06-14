using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class AgregarTerceroUseCase  : TerceroUseCase 
{
    public AgregarTerceroUseCase(IRepositorioTercero repo) : base(repo)
    {
    }
    public void Ejecutar(Tercero tercero)
    {
        Repositorio.AgregarTercero(tercero);
    }
}
