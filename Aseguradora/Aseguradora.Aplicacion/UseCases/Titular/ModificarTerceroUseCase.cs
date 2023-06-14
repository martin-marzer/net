using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class ModificarTitularUseCase : TitularUseCase
{
    public ModificarTitularUseCase(IRepositorioTitular repo) : base(repo)
    {
    }
    public void Ejecutar(Titular titular)
    {
        Repositorio.ModificarTitular(titular);
    }
}
