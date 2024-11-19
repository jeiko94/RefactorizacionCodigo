Codigo a refactorizar:

public void Registrar(string nombre, string email, string password)
{
    if (nombre != null && email != null && password != null)
    {
        if (!usuarios.Exists(u => u.Email == email))
        {
            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.Nombre = nombre;
            nuevoUsuario.Email = email;
            nuevoUsuario.Password = password;
            usuarios.Add(nuevoUsuario);
            Console.WriteLine("Usuario registrado.");
        }
        else
        {
            Console.WriteLine("El email ya está en uso.");
        }
    }
    else
    {
        Console.WriteLine("Todos los campos son obligatorios.");
    }
}
