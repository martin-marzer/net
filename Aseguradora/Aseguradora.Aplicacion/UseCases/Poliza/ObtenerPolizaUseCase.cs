using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class ObtenerPolizaUseCase  : PolizaUseCase 
{
    public ObtenerPolizaUseCase(IRepositorioPoliza repo) : base(repo)
    {
    }
    public Poliza? Ejecutar(int id)
    {
        return Repositorio.ObtenerPoliza(id);
    }
}