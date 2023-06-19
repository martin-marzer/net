using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class ObtenerTerceroUseCase  : TerceroUseCase 
{
    public ObtenerTerceroUseCase(IRepositorioTercero repo) : base(repo)
    {
    }
    public Tercero? Ejecutar(int id)
    {
        return Repositorio.ObtenerTercero(id);
    }
}