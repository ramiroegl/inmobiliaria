namespace Inmobiliaria.Domain.Clientes;

public class Cliente(string nombres, string apellidos, string identidad)
{
  public string Nombres { get; set; } = nombres;
  public string Apellidos { get; set; } = apellidos;
  public string Identidad { get; set; } = identidad;
}
