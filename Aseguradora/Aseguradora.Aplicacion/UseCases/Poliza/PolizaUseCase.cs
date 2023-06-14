using Aseguradora.Aplicacion.Interfaces;
namespace Aseguradora.Aplicacion.UseCases;
public abstract class PolizaUseCase
{
    protected IRepositorioPoliza Repositorio { get; private set; }
    public PolizaUseCase(IRepositorioPoliza repositorio)
    {
        this.Repositorio = repositorio;
    }
}