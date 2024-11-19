namespace RefactorizacionCodigo
{
    public class ControladorUsuarios
    {
        private IRepositorioUsuarios _repositorio;

        public ControladorUsuarios(IRepositorioUsuarios repositorio)
        {
            _repositorio = repositorio;
        }

        public void RegistrarUsuario(string nombre, string email, string password)
        {
            ValidarEntradas(nombre, email, password);
            VerificarDisponibilidadEmail(email);

            Usuario nuevoUsuario = CrearUsuario(nombre, email, password);
            _repositorio.Agregar(nuevoUsuario);
        }

        public void ValidarEntradas(string nombre, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre es obligatorio");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("El email es obligatorio");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("La contraseña es obligatoria");
            }
        }

        private void VerificarDisponibilidadEmail(string email)
        {
            if (_repositorio.ExisteEmail(email))
            {
                throw new InvalidOperationException("El email ya esta en uso.");
            }
        }

        private Usuario CrearUsuario(string nombre, string email, string password)
        {
            return new Usuario
            {
                Nombre = nombre,
                Email = email,
                Password = password,
            };
        }
    }
}