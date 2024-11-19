using Moq;
using RefactorizacionCodigo;

namespace Test
{
    public class ControladorUsuariosTests
    {

        [Fact]
        public void RegistrarUsuario_RegistroExitoso()
        {
            //Arrange
            var mockRepositorio = new Mock<IRepositorioUsuarios>();
            var controlador = new ControladorUsuarios(mockRepositorio.Object);

            string nombre = "juan perez";
            string email = "j@ejemplo.com";
            string password = "123";

            //Act
            controlador.RegistrarUsuario(nombre, email, password);

            mockRepositorio.Verify(r => r.Agregar(It.Is<Usuario>(
                u => u.Nombre == nombre &&
                     u.Email == email &&
                     u.Password != null)), // La contraseña debería estar encriptada, Si la contraseña es encriptada, no podremos comparar el valor directamente. Podemos verificar que no sea nula o que cumpla con algún criterio.
                Times.Once);

        }

        [Fact]
        public void RegistrarUsuario_EmailYaExistente_LanzaInvalidOperationException()
        {
            //Arrange
            var mockRepositorio = new Mock<IRepositorioUsuarios>();
            var controlador = new ControladorUsuarios(mockRepositorio.Object);

            string nombre = "Maria perez";
            string email = "m@gmail.com";
            string password = "123";

            mockRepositorio.Setup(r => r.ExisteEmail(email)).Returns(true);

            //Act && Assert
            var exception = Assert.Throws<InvalidOperationException>(() =>
                controlador.RegistrarUsuario(nombre, email, password));

            Assert.Equal("El email ya esta en uso.", exception.Message);
        }

        [Theory]
        [InlineData(null, "user@ejemplo.com", "password123", "El nombre es obligatorio")]
        [InlineData("yeisson", null, "password123", "El email es obligatorio")]
        [InlineData("yeisson", "user@ejemplo.com", null, "La contraseña es obligatoria")]
        public void RegistrarUsuario_CamposInvalidos_LanzaArgumentException(string nombre, string email, string password, string mensajeEsperado)
        {
            //Arrange
            var mockRepositorio = new Mock<IRepositorioUsuarios>();
            var controlador = new ControladorUsuarios(mockRepositorio.Object);

            //Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                controlador.RegistrarUsuario(nombre, email, password));

            Assert.Equal(mensajeEsperado, exception.Message);
        }
    }
}