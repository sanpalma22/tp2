using System.Collections.Generic;
Dictionary<int, Persona> dicGente = new Dictionary<int, Persona>();
int menu;
do
{
    menu = ingresarMenu("Eliga una opcion");
    Console.Clear();
    switch (menu)
    {
        case 1:
            CargarPersona();
            break;
        case 2:
            obtenerEstadisticas();
            break;
        case 3:
            buscarPersona();
            break;
        case 4:
            modificarMail();
            break;
        case 5:
            break;
        default:
            Console.WriteLine("No existe esa opción en el menú");
            break;
    }
    if (menu != 5)
    {
        Console.WriteLine("Pulse una tecla para continuar");
        Console.ReadKey();
    }
    Console.Clear();
} while (menu != 5);

int ingresarMenu(string mensaje)
{
    int menu;
    Console.WriteLine(mensaje);
    Console.WriteLine("1- Cargar Nueva Persona");
    Console.WriteLine("2- Obtener Estadísticas del Censo");
    Console.WriteLine("3- Buscar Persona");
    Console.WriteLine("4- Modificar Mail de una Persona.");
    Console.WriteLine("5- Salir");
    menu = int.Parse(Console.ReadLine());
    return menu;
}
void CargarPersona()
{
    int dni;
    bool dniVerificado;
    do
    {
        dni = ingresarEntero("Ingrese el DNI");
        dniVerificado = validarExistenciaDni(dni);
    } while (!dniVerificado);
    string ape = ingresarTexto("Ingrese su apellido").ToUpper();
    string nom = ingresarTexto("Ingrese el nombre").ToUpper();
    DateTime fNac = ingresarFecha("Ingrese su fecha de nacimiento. dd/mm/aaaa");
    string email = ingresarTexto("Ingrese el su E-Mail").ToLower();
    Persona unaPersona = new Persona(dni, ape, nom, fNac, email);
    dicGente.Add(dni, unaPersona);
    Console.WriteLine("Se ha creado la persona {0} y se ha agregado a la lista.", nom + " " + ape);
}
int ingresarEntero(string v)
{
    int num;
    Console.WriteLine(v);
    num = int.Parse(Console.ReadLine());
    return num;
}
string ingresarTexto(string v)
{
    string text;
    Console.WriteLine(v);
    text = Console.ReadLine();
    return text;
}
DateTime ingresarFecha(string v)
{
    DateTime fecha;
    string fechaString = ingresarTexto(v);
    while (!DateTime.TryParse(fechaString, out fecha))
    {
        fechaString = ingresarTexto("Fecha inexistente, " + v);
    }
    return fecha;
}

bool validarExistenciaDni(int key)
{

    bool keyPosible;
    keyPosible = dicGente.ContainsKey(key) == false;
    if (!keyPosible) Console.WriteLine("Ese DNI ya está ingresado");
    return keyPosible;
}

void obtenerEstadisticas()
{
    if (dicGente.Count > 0)
    {
        int contVotantes = 0;
        float promEdad, edadSumada = 0;
        foreach (Persona item in dicGente.Values)
        {
            if (item.Edad >= 16) contVotantes++;
            edadSumada += item.Edad;
        }
        promEdad = edadSumada / dicGente.Count;
        Math.Round(promEdad, 1);
        Console.WriteLine("Estadisticas del censo:");
        Console.WriteLine("Cantidad de personas: " + dicGente.Count);
        Console.WriteLine("Cantidad de personas habilitadas para votar: " + contVotantes);
        Console.WriteLine("Promedio de edad: {0} años", promEdad);
    }
    else Console.WriteLine("Aún no se ingresaron personas");
}

void buscarPersona()
{
    int dniIngresado = ingresarEntero("Ingrese el DNI de la prersona que desea buscar");
    if (dicGente.ContainsKey(dniIngresado))
    {
        Persona item = dicGente[dniIngresado];
        Console.WriteLine("DNI: " + item.DNI);
        Console.WriteLine("Nombre completo: " + item.Nombre + " " + item.Apellido);
        Console.WriteLine("Fecha de nacimiento: " + item.FechaNacimiento.ToShortDateString());
        Console.WriteLine("Edad: " + item.Edad);
        Console.WriteLine("EMail: " + item.Email);
        string puedeVotar;
        if (item.Edad >= 16) puedeVotar = "SI";
        else puedeVotar = "NO";
        Console.WriteLine("¿Puede votar?: " + puedeVotar);
    }
    else Console.WriteLine("DNI no ingresado en el sistema");
}
void modificarMail()
{
    int dniIngresado = ingresarEntero("Ingrese el DNI de la prersona que desea cambiar el EMail");
    if (dicGente.ContainsKey(dniIngresado))
    {
        dicGente[dniIngresado].Email = ingresarTexto("Ingrese el nuevo EMail");
        Console.WriteLine("EMail actualizado");
    }
    else Console.WriteLine("DNI no ingresado en el sistema");
}
