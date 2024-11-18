using RefactorizacionCodigo;

class Program
{
    static void Main(string[] args)
    {
        ControladorUsuarios controlador = new ControladorUsuarios();

        try
        {
            controlador.RegistrarUsuario("Juan Pérez", "juan.perez@gmail.com", "password123");
            Console.WriteLine("Usuario registrado con éxito.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex) 
        {
            Console.WriteLine($"Error inesperado: {ex.Message}");
        }
    }
}

