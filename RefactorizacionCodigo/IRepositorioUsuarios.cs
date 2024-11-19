namespace RefactorizacionCodigo
{
    public interface IRepositorioUsuarios
    {
        void Agregar(Usuario usuario);
        bool ExisteEmail(string email);
    }
}
