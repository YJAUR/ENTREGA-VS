using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using Evaluacion.Modelo;


namespace Evaluacion
{
    class Program
    {
        static Validaciones Verficar = new Validaciones(); //intaciar la clase para crear objeto
        static List<Estudiante> ListaEstudiante = new List<Estudiante>();



        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);

            //LeerArchivoXml();

            Menuprincipal();





        }
        static void Menuprincipal()
        { // ------ inicio del menu----

            int OpcMen;

            string temporal;
            do
            {
                //Listo de menu
                bool EntradaValida = false;
                Console.Clear();
                //gui.Marco(1, 80, 10, 30);
                //gui.BorrarLinea(40, 22, 80);
                //gui.logo();
                //gui.Marco(1, 110, 1, 8);
                Console.SetCursorPosition(2, 2); Console.Write("*** Menu Principal *** ");
                //gui.Linea(40, 60, 10);
                Console.SetCursorPosition(1, 4); Console.Write("1. Insertar ");
                Console.SetCursorPosition(13, 4); Console.Write("2. Listar ");
                Console.SetCursorPosition(23, 4); Console.Write("3. Buscar ");
                Console.SetCursorPosition(33, 4); Console.Write("4. Eliminar ");
                Console.SetCursorPosition(48, 4); Console.Write("5. Editar  ");
                //Console.SetCursorPosition(84, 6); Console.Write("6. Guardar   ");
                Console.SetCursorPosition(69, 4); Console.Write("0. Salir");


                do
                {

                    //   gui.Marco(98, 108, 2, 4);

                    //   gui.BorrarLinea(84, 3, 80);
                    Console.SetCursorPosition(2, 6); Console.Write("Escoja Opcion: ");
                    temporal = Console.ReadLine();
                    if (!Verficar.Vacio(temporal))
                        if (Verficar.TipoNumero(temporal))
                            EntradaValida = true;
                } while (!EntradaValida);


                OpcMen = Convert.ToInt32(temporal);

                switch (OpcMen)
                {
                    case 1:
                        string sig = "n";
                        do
                        {

                            InsertarEstudiantes();
                            //       gui.BorrarLinea(37, 13, 64);
                            Console.SetCursorPosition(10, 19); Console.Write("Desea ingresar otro estudiante: s/n");
                            sig = Console.ReadLine();
                            if (!Verficar.Vacio(sig))
                                if (Verficar.sino(sig))
                                    EntradaValida = true;


                        } while (sig.Equals("s"));

                        break;
                    case 2:
                        ListarEstudiantes();
                        break;
                    case 3:
                        BuscarEstudiantes();
                        break;
                    case 4:
                        EliminarEstudiante();
                        break;
                    case 5:
                        EditarEstudiante();
                        break;
                    //case 6:
                    //    EscrirArchivoXml();
                    //    break;
                    case 0:
                        {
                            //  gui.BorrarLinea(40, 22, 80);
                            Console.SetCursorPosition(40, 22); Console.Write(" ... Gracias por usar el programa");
                            // EscrirArchivoXml();
                        }
                        break;
                    default:
                        {
                            //   gui.BorrarLinea(40, 22, 80);
                            Console.SetCursorPosition(40, 22); Console.Write(" Opcion Invalida");
                        }
                        break;

                }
                //  gui.BorrarLinea(40, 23, 80);
                Console.SetCursorPosition(40, 23); Console.Write("presione cualquier tecla para continuar");
                Console.ReadKey();


            } while (OpcMen > 0);

        }//---- fin el menu


        //Ingresar los estudiantes
        static void InsertarEstudiantes()
        {
            var datos = new tallersena588Context();


            bool EntradaValidaCodigo = false;
            bool EntradaValidaCorreo = false;
            bool EntradaValidaNota1 = false;
            bool EntradaValidaNota2 = false;
            bool EntradaValidaNota3 = false;



            string codigo;
            string nombre = "";
            string correo;
            string nota1;
            string nota2;
            string nota3;


            Console.Clear();
            //  gui.Marco(1, 110, 1, 30);
            Console.SetCursorPosition(40, 5); Console.WriteLine("Insertar Estudiante");
            //  gui.Linea(40, 6, 30);

            // .................................... ..validaciones
            do // pedir el codigo
            {
                //   gui.BorrarLinea(34, 8, 64);
                Console.SetCursorPosition(10, 8); Console.Write("Digite Codigo Estudiante: ");
                codigo = Console.ReadLine();
                if (!Verficar.Vacio(codigo))
                    if (Verficar.TipoNumero(codigo))
                        if (Verficar.Numcaracteres(codigo))
                            EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);
            // inicia el if del existe
            var cod = uint.Parse(codigo);
            var existe = datos.Estudiantes.Find(cod);


            if (existe == null)
            {
                bool EntradaValidaNombre = false;
                do // pedir el nombre
                {
                    //  gui.BorrarLinea(33, 9, 64);
                    Console.SetCursorPosition(10, 9); Console.Write("Digite Nombre Estudiante: ");
                    nombre = Console.ReadLine();
                    if (!Verficar.Vacio(nombre))
                        if (Verficar.TipoTexto(nombre))
                            EntradaValidaNombre = true;
                } while (!EntradaValidaNombre);

                do // pedir el correo
                {
                    //    gui.BorrarLinea(37, 10, 64);
                    Console.SetCursorPosition(10, 10); Console.Write("Digite el correo del estudiante: ");
                    correo = Console.ReadLine();
                    if (!Verficar.Vacio(correo))
                        if (Verficar.Tipocorreo(correo))
                            EntradaValidaCorreo = true;
                } while (!EntradaValidaCorreo);


                do // pedir notas
                {
                    //   gui.BorrarLinea(37, 11, 64);
                    Console.SetCursorPosition(10, 11); Console.Write("Digite la nota 1: ");
                    nota1 = Console.ReadLine();
                    if (!Verficar.Vacio(nota1))
                        if (Verficar.TipoNumero(nota1))
                            EntradaValidaNota1 = true;
                } while (!EntradaValidaNota1);
                do // pedir notas
                {
                    //    gui.BorrarLinea(37, 12, 64);
                    Console.SetCursorPosition(10, 12); Console.Write("Digite la nota 2: ");
                    nota2 = Console.ReadLine();
                    if (!Verficar.Vacio(nota2))
                        if (Verficar.TipoNumero(nota2))
                            EntradaValidaNota2 = true;
                } while (!EntradaValidaNota2);
                do // pedir notas
                {
                    //    gui.BorrarLinea(37, 13, 64);
                    Console.SetCursorPosition(10, 13); Console.Write("Digite la nota 3: ");
                    nota3 = Console.ReadLine();
                    if (!Verficar.Vacio(nota3))
                        if (Verficar.TipoNumero(nota3))

                            EntradaValidaNota3 = true;
                } while (!EntradaValidaNota3);



                //..........................................



                // creo el objeto  myEstudiante



                Estudiantes myEstudiante = new Estudiantes();

                myEstudiante.Codigo = uint.Parse(codigo);
                myEstudiante.Nombre = nombre;
                myEstudiante.Correo = correo;
                myEstudiante.Nota1 = Double.Parse(nota1);
                myEstudiante.Nota2 = Double.Parse(nota2);
                myEstudiante.Nota3 = Double.Parse(nota3);


                datos.Add(myEstudiante);
                datos.SaveChanges();



                //ListaEstudiante.Add(myEstudiante);
            }
            else
                Console.WriteLine("el codigo existe");

        }
        // cierra el si exisete 

        //listado 
        static void ListarEstudiantes()
        {

            Console.Clear();
            //   gui.Marco(1, 110, 1, 30);
            Console.SetCursorPosition(40, 2); Console.Write(" lista estudiantes");
            //int altura = 6;
            //   gui.Linea(3, 107, 3);

            Console.SetCursorPosition(6, 12); Console.Write("CODIGO");
            Console.SetCursorPosition(6, 13); Console.Write("NOMBRE");
            Console.SetCursorPosition(6, 14); Console.Write("CORREO");
            Console.SetCursorPosition(6, 14); Console.Write("NOTA1.");
            Console.SetCursorPosition(6, 16); Console.Write("NOTA2");
            Console.SetCursorPosition(6, 17); Console.Write("NOTA3");
            Console.SetCursorPosition(6, 18); Console.Write("PROMEDIO");


            //Objetos de estudiantes

            var datos = new tallersena588Context();
            var lisEst = datos.Estudiantes.ToList();
            foreach (var ObjetoEstudiante in lisEst)

            {
                var c = "";
                var p = (ObjetoEstudiante.Nota1 + ObjetoEstudiante.Nota2 + ObjetoEstudiante.Nota3) / 3;

                if (p >= 3.5)
                    c = "Aprobado";
                else
                    c = "Rebrobado";

                Console.SetCursorPosition(16, 12); Console.Write(ObjetoEstudiante.Codigo);
                Console.SetCursorPosition(16, 13); Console.Write(ObjetoEstudiante.Nombre);
                Console.SetCursorPosition(16, 14); Console.Write(ObjetoEstudiante.Correo);
                Console.SetCursorPosition(16, 15); Console.Write(ObjetoEstudiante.Nota1);
                Console.SetCursorPosition(16, 16); Console.Write(ObjetoEstudiante.Nota2);
                Console.SetCursorPosition(16, 17); Console.Write(ObjetoEstudiante.Nota3);
                Console.SetCursorPosition(16, 18); Console.Write(p);
                Console.SetCursorPosition(16, 19); Console.Write(c);

                //altura++;
            }

        }
        static void BuscarEstudiantes()
        {


            var datos = new tallersena588Context();

            string codigo = "";

            bool EntradaValidaCodigo = false;

            Console.Clear();
            //  gui.Marco(1, 110, 1, 25);
            Console.SetCursorPosition(40, 5); Console.WriteLine("bucar Estudiante");
            //  gui.Linea(40, 6, 30);

            do // pedir el codigo
            {
                //    gui.BorrarLinea(34, 8, 64);
                Console.SetCursorPosition(10, 8); Console.Write("Digite Codigo Estudiantes");
                codigo = Console.ReadLine();
                if (!Verficar.Vacio(codigo))
                    if (Verficar.TipoNumero(codigo))
                        if (Verficar.Numcaracteres(codigo))
                            EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);
            var db = new tallersena588Context();
            var existe = db.Estudiantes.Find(uint.Parse(codigo));


            if (existe != null)
            {
                var myEstudiante = datos.Estudiantes.FirstOrDefault(e => e.Codigo == uint.Parse(codigo));


                int altura = 11;
                //   gui.Linea(3, 107, 9);
                // gui.Linea(3, 107, 12);

                Console.SetCursorPosition(6, 13); Console.Write("CODIGO");
                Console.SetCursorPosition(6, 14); Console.Write("NOMBRE");
                Console.SetCursorPosition(6, 15); Console.Write("CORREO");
                Console.SetCursorPosition(6, 16); Console.Write("NOTA1.");
                Console.SetCursorPosition(6, 17); Console.Write("NOTA2");
                Console.SetCursorPosition(6, 18); Console.Write("NOTA3");
                Console.SetCursorPosition(6, 19); Console.Write("PROMEDIO");




                var lisEst = datos.Estudiantes.ToList();
                var c = "";
                var p = (myEstudiante.Nota1 + myEstudiante.Nota2 + myEstudiante.Nota3) / 3;
                if (p >= 3.5)
                    c = "Aprobado";
                else
                    c = "ReProbado";

                Console.SetCursorPosition(16, 13); Console.Write(myEstudiante.Codigo);
                Console.SetCursorPosition(16, 14); Console.Write(myEstudiante.Nombre);
                Console.SetCursorPosition(16, 15); Console.Write(myEstudiante.Correo);
                Console.SetCursorPosition(16, 16); Console.Write(myEstudiante.Nota1);
                Console.SetCursorPosition(16, 17); Console.Write(myEstudiante.Nota2);
                Console.SetCursorPosition(16, 18); Console.Write(myEstudiante.Nota3);
                Console.SetCursorPosition(16, 19); Console.Write(p);
                Console.SetCursorPosition(16, 20); Console.Write(c);
                //altura++;



            }
            else
            {
                //   gui.BorrarLinea(40, 22, 80);
                Console.SetCursorPosition(40, 22); Console.Write(" El usuario del codigo " + codigo + " No existe");
            }





        }



        static bool Existe(int cod)
        {
            bool aux = false;

            foreach (Estudiante myEstudiante in ListaEstudiante)
            {
                if (myEstudiante.Codigo == cod)
                    aux = true;
            }
            return aux;
        }

        static Estudiante ObtenerDatos(int cod)
        {
            foreach (Estudiante myEstudiante in ListaEstudiante)
            {
                if (myEstudiante.Codigo == cod)
                    return myEstudiante;
            }
            return null;

        }



        static void EditarEstudiante()
        {

            bool EntradaValidaCodigo = false;
            bool EntradaValidaNombre = false;
            bool EntradaValidaCorreo = false;
            bool EntradaValidaNota1 = false;
            bool EntradaValidaNota2 = false;
            bool EntradaValidaNota3 = false;


            string codigo;
            string nombre;
            string correo;
            string nota1;
            string nota2;
            string nota3;

            Console.Clear();
            //   gui.Marco(1, 110, 1, 25);
            Console.SetCursorPosition(40, 5); Console.WriteLine(" Editar  Estudiante");
            //   gui.Linea(40, 6, 30);

            do // pedir el codigo
            {
                //    gui.BorrarLinea(34, 8, 64);
                Console.SetCursorPosition(9, 8); Console.Write("Digite Codigo Estudiantes a Editar  ");
                codigo = Console.ReadLine();
                if (!Verficar.Vacio(codigo))
                    if (Verficar.TipoNumero(codigo))
                        EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);

            var datos = new tallersena588Context();
            var existe = datos.Estudiantes.Find(uint.Parse(codigo));

            if (existe != null)
            {
                Console.SetCursorPosition(4, 4); Console.Write("CODIGO");
                Console.SetCursorPosition(10, 4); Console.Write("NOMBRE");
                Console.SetCursorPosition(24, 4); Console.Write("CORREO");
                Console.SetCursorPosition(36, 4); Console.Write("NOTA1.");
                Console.SetCursorPosition(45, 4); Console.Write("NOTA2");
                Console.SetCursorPosition(60, 4); Console.Write("NOTA3");
                Console.SetCursorPosition(70, 4); Console.Write("PROMEDIO");

                var myEstudiante = datos.Estudiantes.FirstOrDefault(e => e.Codigo == uint.Parse(codigo));
                var c = "";
                var p = (myEstudiante.Nota1 + myEstudiante.Nota2 + myEstudiante.Nota3) / 3;

                if (p >= 3.5)
                    c = "Aprobado";
                else
                    c = "Rebrobado";
                Console.SetCursorPosition(15, 12); Console.Write(myEstudiante.Codigo);
                Console.SetCursorPosition(15, 13); Console.Write(myEstudiante.Nombre);
                Console.SetCursorPosition(15, 14); Console.Write(myEstudiante.Correo);
                Console.SetCursorPosition(15, 15); Console.Write(myEstudiante.Nota1);
                Console.SetCursorPosition(15, 16); Console.Write(myEstudiante.Nota2);
                Console.SetCursorPosition(15, 17); Console.Write(myEstudiante.Nota3);
                Console.SetCursorPosition(15, 18); Console.Write(p);
                Console.SetCursorPosition(15, 19); Console.Write(c);


                Console.SetCursorPosition(65, 12); Console.Write("Digite los nuevos registros");
                do // pedir el nombre
                {
                    //  gui.BorrarLinea(33, 9, 64);
                    Console.SetCursorPosition(65, 13); Console.Write("Digite Nombre Estudiante: ");
                    nombre = Console.ReadLine();
                    if (!Verficar.Vacio(nombre))
                    {
                        if (Verficar.TipoTexto(nombre))
                        {
                            EntradaValidaNombre = true;
                        }

                    }
                    else
                    {
                        EntradaValidaNombre = true;
                    }

                } while (!EntradaValidaNombre);

                do // pedir el correo
                {
                    //    gui.BorrarLinea(37, 10, 64);
                    Console.SetCursorPosition(10, 10); Console.Write("Digite el correo del estudiante: ");
                    correo = Console.ReadLine();
                    if (!Verficar.Vacio(correo))
                    {
                        if (Verficar.Tipocorreo(correo))
                        {
                            EntradaValidaCorreo = true;
                        }

                    }
                    else
                    {
                        EntradaValidaCorreo = true;
                    }
                } while (!EntradaValidaCorreo);


                do // pedir notas
                {
                    //  gui.BorrarLinea(37, 11, 64);
                    Console.SetCursorPosition(10, 11); Console.Write("Digite la nota 1: ");
                    nota1 = Console.ReadLine();

                    if (!Verficar.Vacio(nota1))
                    {
                        if (Verficar.TipoNumero(nota1))
                        {
                            EntradaValidaNota1 = true;
                        }

                    }
                    else
                    {
                        EntradaValidaNota1 = true;
                    }

                } while (!EntradaValidaNota1);
                do // pedir notas
                {
                    //   gui.BorrarLinea(37, 12, 64);
                    Console.SetCursorPosition(10, 12); Console.Write("Digite la nota 2: ");
                    nota2 = Console.ReadLine();
                    if (!Verficar.Vacio(nota2))
                    {
                        if (Verficar.TipoNumero(nota2))
                        {
                            EntradaValidaNota2 = true;
                        }

                    }
                    else
                    {
                        EntradaValidaNota2 = true;
                    }
                } while (!EntradaValidaNota2);
                do // pedir notas
                {
                    //   gui.BorrarLinea(37, 13, 64);
                    Console.SetCursorPosition(10, 13); Console.Write("Digite la nota 3: ");
                    nota3 = Console.ReadLine();
                    if (!Verficar.Vacio(nota3))
                    {
                        if (Verficar.TipoNumero(nota3))
                        {
                            EntradaValidaNota3 = true;
                        }

                    }
                    else
                    {
                        EntradaValidaNota3 = true;
                    }

                } while (!EntradaValidaNota3);

                //--------------------------

                if (!Verficar.Vacio(nombre))
                {
                    myEstudiante.Nombre = nombre;
                }
                if (!Verficar.Vacio(correo))
                {
                    myEstudiante.Correo = correo;
                }

                if (!Verficar.Vacio(nota1))
                {
                    myEstudiante.Nota1 = double.Parse(nota1);
                }
                if (!Verficar.Vacio(nota2))
                {
                    myEstudiante.Nota2 = double.Parse(nota2);
                }
                if (!Verficar.Vacio(nota3))
                {
                    myEstudiante.Nota3 = double.Parse(nota3);
                }


                datos.Estudiantes.Update(myEstudiante);

                datos.SaveChanges();

                Console.SetCursorPosition(40, 22); Console.WriteLine("Registro EDITADO  Correctamente");

            }


            else
            {
                //   gui.BorrarLinea(40, 22, 80);
                Console.SetCursorPosition(40, 22); Console.Write(" El usuario del codigo " + codigo + " No existe");

            }


        }


        //borrar datos 
        static void EliminarEstudiante()
        {
            string codigo;
            var datos = new tallersena588Context();
            // var cod = uint.Parse(codigo);


            bool EntradaValidaCodigo = false;

            Console.Clear();
            // gui.Marco(1, 110, 1, 25);
            Console.SetCursorPosition(40, 5); Console.WriteLine(" Eliminar Estudiante");
            //  gui.Linea(40, 6, 30);

            do // pedir el codigo
            {
                //   gui.BorrarLinea(34, 8, 64);
                Console.SetCursorPosition(10, 8); Console.Write("Digite Codigo Estudiantes a Eliminar ");
                codigo = Console.ReadLine();
                if (!Verficar.Vacio(codigo))
                    if (Verficar.TipoNumero(codigo))
                        EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);
            var db = new tallersena588Context();
            var existe = db.Estudiantes.Find(uint.Parse(codigo));


            if (existe != null)
            {
                var myEstudiante = datos.Estudiantes.FirstOrDefault(e => e.Codigo == uint.Parse(codigo));
                var c = "";
                var p = (myEstudiante.Nota1 + myEstudiante.Nota2 + myEstudiante.Nota3) / 3;
                if (p >= 3.5)
                    c = "Aprobado";
                else
                    c = "Rebrobado";
                Console.SetCursorPosition(15, 12); Console.Write(myEstudiante.Codigo);
                Console.SetCursorPosition(15, 13); Console.Write(myEstudiante.Nombre);
                Console.SetCursorPosition(15, 14); Console.Write(myEstudiante.Correo);
                Console.SetCursorPosition(15, 15); Console.Write(myEstudiante.Nota1);
                Console.SetCursorPosition(15, 16); Console.Write(myEstudiante.Nota2);
                Console.SetCursorPosition(15, 17); Console.Write(myEstudiante.Nota3);
                Console.SetCursorPosition(15, 18); Console.Write(p);
                Console.SetCursorPosition(15, 19); Console.Write(c);



                string confirmar = "n";
                //  gui.BorrarLinea(40, 22, 80);
                Console.SetCursorPosition(30, 21); Console.WriteLine($"Realmete desea borrar los datos de {myEstudiante.Nombre} s/n");
                confirmar = Console.ReadLine();
                if (confirmar == "s")
                {
                    datos.Estudiantes.Remove(myEstudiante);
                    datos.SaveChanges();

                    //    gui.BorrarLinea(40, 22, 80);
                    Console.SetCursorPosition(40, 22); Console.WriteLine("el registro fue borrado correctamente ");

                }

                else
                {
                    //   gui.BorrarLinea(40, 22, 80);
                    Console.SetCursorPosition(40, 22); Console.Write(" El usuario del codigo " + codigo + " No existe");
                }
            }
        }

        static void Menuimpr()
        {
            //Lista de menu solo para imprimer en cualquir pantalla solo si se desea  

            Console.Clear();
            //   gui.Marco(1, 110, 10, 25);
            //   gui.BorrarLinea(40, 22, 80);
            //   gui.logo();
            //   gui.Marco(1, 110, 1, 8);
            Console.SetCursorPosition(2, 2); Console.Write("*** Menu Principal *** ");
            //   gui.Linea(40, 60, 10);
            Console.SetCursorPosition(1, 4); Console.Write("1.Insertar");
            Console.SetCursorPosition(13, 4); Console.Write("2.Listar");
            Console.SetCursorPosition(23, 4); Console.Write("3.Buscar");
            Console.SetCursorPosition(33, 4); Console.Write("4.Eliminar");
            Console.SetCursorPosition(46, 4); Console.Write("5.Editar");
            Console.SetCursorPosition(58, 4); Console.Write("6.Guardar");
            Console.SetCursorPosition(69, 4); Console.Write("0.Salir");
        }
    }
}

