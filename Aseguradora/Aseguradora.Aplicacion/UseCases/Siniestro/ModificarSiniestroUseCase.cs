using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class ModificarSiniestroUseCase : SiniestroUseCase
{
    public ModificarSiniestroUseCase(IRepositorioSiniestro repo) : base(repo)
    {
    }
    public void Ejecutar(Siniestro siniestro)
    {
        Repositorio.ModificarSiniestro(siniestro);
    }
}
