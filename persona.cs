using System;
class Persona
{
    public int DNI { get; private set; }
    public string Apellido { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Email { get; set; }
    public int Edad { get; set; }

    public Persona(int dni = 0, string ape = "", string nom = "", DateTime fNac = new DateTime(), string email = "")
    {
        DNI = dni;
        Apellido = ape;
        Nombre = nom;
        FechaNacimiento = fNac;
        Email = email;
        Edad=MiEdad();
    }
    public int MiEdad()
    {
        DateTime FechaNacimientoHoy = new DateTime(DateTime.Today.Year, FechaNacimiento.Month, FechaNacimiento.Day);
        if (FechaNacimientoHoy < DateTime.Today) Edad = DateTime.Today.Year - FechaNacimiento.Year;
        else Edad = DateTime.Today.Year - FechaNacimiento.Year - 1;
        return Edad;
    }
}