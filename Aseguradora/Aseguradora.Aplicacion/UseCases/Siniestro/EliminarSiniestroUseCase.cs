using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class EliminarSiniestroUseCase : SiniestroUseCase
{
    public EliminarSiniestroUseCase(IRepositorioSiniestro repo) : base(repo)
    {
    }
    public void Ejecutar(int ID)
    {
        Repositorio.EliminarSiniestro(ID);
    }
}
