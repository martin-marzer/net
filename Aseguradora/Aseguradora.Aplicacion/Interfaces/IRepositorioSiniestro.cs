using Aseguradora.Aplicacion.Entidades;
namespace Aseguradora.Aplicacion.Interfaces;

public interface IRepositorioSiniestro
{
    void AgregarSiniestro(Siniestro siniestro);
    void ModificarSiniestro(Siniestro siniestro);
    void EliminarSiniestro(int ID);
    Siniestro? ObtenerSiniestro(int ID);
    List<Siniestro> ListarSiniestros();
}