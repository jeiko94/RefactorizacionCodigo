namespace RefactorizacionCodigo
{
    public  class RepositorioUsuariosEnMemoria : IRepositorioUsuarios
    {
        private List<Usuario> usuarios = new List<Usuario>();

        public void Agregar(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public bool ExisteEmail(string email)
        {
            return usuarios.Exists(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
    }
}
