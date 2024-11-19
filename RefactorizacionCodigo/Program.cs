using RefactorizacionCodigo;

class Program
{
    static void Main(string[] args)
    {
        IRepositorioUsuarios repositorioUsuarios = new RepositorioUsuariosEnMemoria();
        ControladorUsuarios controlador = new ControladorUsuarios(repositorioUsuarios);

        try
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("1. Ingresar usuarios.");
                Console.WriteLine("0. Salir.");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:                        
                        Console.WriteLine("Ingrese el nombre: ");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el Email: ");
                        string email = Console.ReadLine();
                        Console.WriteLine("Ingrese su contraseña: ");
                        string password = Console.ReadLine();

                        controlador.RegistrarUsuario(nombre, email, password);
                        Console.WriteLine("Usuario registrado con éxito.");
                    break;

                    case 0:
                        salir = true;
                        Console.WriteLine("Hasta luego.");
                    break;

                    default:
                        Console.WriteLine("Opcion invalida");
                    break;
                }

            }
            
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

