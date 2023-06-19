using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class ObtenerSiniestroUseCase  : SiniestroUseCase 
{
    public ObtenerSiniestroUseCase(IRepositorioSiniestro repo) : base(repo)
    {
    }
    public Siniestro? Ejecutar(int id)
    {
        return Repositorio.ObtenerSiniestro(id);
    }
}