using System.Runtime.CompilerServices;

namespace RefactorizacionCodigo
{
    public class ControladorUsuarios
    {
        private List<Usuario> usuarios = new List<Usuario>();

        public void RegistrarUsuario(string nombre, string email, string password)
        {
            ValidarEntradas(nombre, email, password);
            VerificarDisponibilidadEmail(email);

            Usuario nuevoUsuario = CrearUsuario(nombre, email, password);
            usuarios.Add(nuevoUsuario);
        }

        public void ValidarEntradas(string nombre, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre es obligatorio.", nameof(nombre));
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("El email es obligatorio,", nameof(email));
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("La contraseña es obligatoria.", nameof(password));
            }
        }

        private void VerificarDisponibilidadEmail(string email)
        {
            if (usuarios.Exists(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
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
