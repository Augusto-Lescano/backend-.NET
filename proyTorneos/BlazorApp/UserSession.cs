using DTOs;

public class UserSession
{
    public bool IsAdmin { get; private set; }
    public UsuarioDTO? UsuarioActual { get; private set; }

    public event Action? OnChange;

    public void SetUser(UsuarioDTO usuario)
    {
        UsuarioActual = usuario;
        IsAdmin = usuario.Admin;


        Console.WriteLine($"UserSession.SetUser - Usuario: {usuario.NombreUsuario}, Admin: {usuario.Admin}");


        NotifyChanged();
    }

    public void Logout()
    {
        Console.WriteLine($"UserSession.Logout - Cerrando sesión de: {UsuarioActual?.NombreUsuario}");


        UsuarioActual = null;
        IsAdmin = false;
        NotifyChanged();
    }

    private void NotifyChanged()
    {
        Console.WriteLine($"UserSession.NotifyChanged - Invocando OnChange");

        OnChange?.Invoke();
    }
}
