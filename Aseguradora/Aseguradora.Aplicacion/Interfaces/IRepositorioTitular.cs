using Aseguradora.Aplicacion.Entidades;
namespace Aseguradora.Aplicacion.Interfaces;

public interface IRepositorioTitular{

    void AgregarTitular(Titular titular);
    void ModificarTitular(Titular titular);
    void EliminarTitular(int ID);
    Titular? ObtenerTitular(int ID);
    List<Titular> ListarTitulares();
}