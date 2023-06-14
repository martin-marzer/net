using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class AgregarSiniestroUseCase  : SiniestroUseCase 
{
    public AgregarSiniestroUseCase(IRepositorioSiniestro repo) : base(repo)
    {
    }
    public void Ejecutar(Siniestro siniestro)
    {
        Repositorio.AgregarSiniestro(siniestro);
    }
}
