using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Aplicación
{
    class Program
    {
        static void Main(string[] args)
        {
            char op = 's';
            string archivo = "";
            int OP;
            string nombre;


            while (op == 's')
            {
                Console.WriteLine("Que desea hacer: \n1. Crear Archivo \n2. Escribir Archivo \n3. Visualizar contenido \n4. Borrar \n5. Salir  ");
                OP = int.Parse(Console.ReadLine());




                Console.Clear();

                if (OP == 1)
                {
                    StreamWriter ar;
                    Console.WriteLine("Que nombre le gustaría poner: ");
                    archivo = Console.ReadLine();
                    ar = File.CreateText(archivo + ".txt");
                    nombre = archivo;



                    ar.Close();
                }
                if (OP == 2)
                {
                    EscribirArchivo(archivo);


                }
                if (OP == 3)
                {
                    MostrarContenido(archivo);


                }
                if (OP == 4)
                {
                    Borrarcontacto(archivo);


                }


                Console.ReadKey();
                if (OP == 5)
                {
                    Console.WriteLine("Usted a deseado Salir");

                }
                Console.Clear();
                Console.WriteLine("Desea Continuar ['s/n']");
                op = char.Parse(Console.ReadLine());

            }



        }
        static void EscribirArchivo(string nombre)
        {

            StreamWriter ar;
            string agenda;
            Console.WriteLine("Ingrese nomnbre: ");
            agenda = Console.ReadLine() + "*";
            Console.WriteLine("Ingrese apellido: ");
            agenda = agenda + Console.ReadLine() + "*";
            Console.WriteLine("Télefono: ");
            agenda = agenda + Console.ReadLine() + "*";
            Console.WriteLine("Ingrese dirección: ");
            agenda = agenda + Console.ReadLine() + "*";
            ar = File.AppendText(nombre);
            ar.WriteLine(agenda);
            agenda = " ";
            Console.WriteLine("Contacto a buscar: ");
            string busqueda = Console.ReadLine();
            ar.Close();

            StreamReader l;

            l = File.OpenText(nombre);

            string linea;
            linea = l.ReadLine();
            while (linea != null)
            {
                string[] vec = linea.Split('*');


                if (vec[0] == busqueda)
                {
                    Console.Write("Contacto encontrado: " + vec[0] + "*" + vec[1] + "*" + vec[2] + "*" + vec[3]);
                }
                linea = l.ReadLine();

            }
            l.Close();

        }
        static void MostrarContenido(string ruta)
        {
            StreamReader ar;
            ar = File.OpenText(ruta);
            Console.WriteLine(ar.ReadToEnd());
            ar.Close();
        }

        static void Borrarcontacto(string nombre)
        {
            StreamWriter are;
            string agenda = "";

            string temp = "temp.txt";

            string borrar;
            Console.WriteLine("Que contacto desea borrar: ");
            borrar = Console.ReadLine();
            are = File.CreateText(temp);
            are.Close();

            StreamReader l;
            l = File.OpenText(nombre);
            string linea;
            linea = l.ReadLine();


            StreamWriter Tar;
            Tar = File.CreateText(temp);
            //*string tar;
            //*tar = Tar.ReadLine();

            while (linea != null)
            {
                string[] vec = linea.Split('*');
                if (vec[0] != borrar)
                {
                    Console.WriteLine("Contactos no eliminados: " + vec[0] + "*" + vec[1] + "*" + vec[2] + "*" + vec[3]);
                }
                linea = l.ReadLine();
            }

            are.Close();

            Tar.Close();
            l.Close();
        }
    }
    
}
