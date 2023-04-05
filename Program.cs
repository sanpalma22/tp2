using System.Collections.Generic;
internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<int, Persona> dicGente = new Dictionary<int, Persona>();
        int menu, cont = 0, acumEdad = 0;
        bool dniVerificado;
        menu = ingresarMenu("Eliga una opcion");
        while (menu > 0 && menu < 5)
        {
            switch (menu)
            {
                case 1:
                    CargarPersona();
                    break;
                case 2:
                    obtenerEstadisticas(dicGente);
                    break;

            }
            menu = ingresarMenu("Eliga una opcion");
        }



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

        void obtenerEstadisticas(Dictionary<int, Persona> dicGente)
        {
            Console.WriteLine("Estadisticas del censo:");
            Console.WriteLine("Cantidad de personas: " + dicGente.Count);
            Console.WriteLine("Cantidad de personas habilitadas para votar: "+ );

            foreach(Persona){
                if()
            }
        }
    }
}