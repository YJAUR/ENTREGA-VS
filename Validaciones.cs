using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Evaluacion
{
    class Validaciones
    {
        public bool Vacio(string texto)
        {
            if (texto.Equals(""))
            {
                Console.SetCursorPosition(40, 22); Console.Write(" El texto no puede ser vacio");
                return true;
            }
            else
                return false;

        }

        public bool TipoNumero(string texto)
        {
            Regex regla = new Regex("[0-9]{1,9}(\\.[0-9]{0,2})?$");

            if (regla.IsMatch(texto))
                return true;
            else
            {
                Console.SetCursorPosition(40, 22); Console.Write(" La Entrada debe ser numerica");
                return false;
            }
        }


        public bool TipoTexto(string texto)
        {
            Regex regla = new Regex(@"^[\p{L} .']+$");

            if (regla.IsMatch(texto))
                return true;
            else
            {
                Console.SetCursorPosition(40, 22); Console.Write(" La Entrada debe ser texto ");
                return false;
            }
        }

        public bool sino(string texto)
        {
            if (texto == "s" || texto == "S" || texto == "N" || texto == "n")
                return true;
            else
            {
                Console.SetCursorPosition(40, 22); Console.Write(" La Entrada debe ser S o N  ");
                return false;
            }
        }
        public bool Tipocorreo(string texto)
        {
            Regex regla = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");

            if (regla.IsMatch(texto))
                return true;
            else
            {
                Console.SetCursorPosition(40, 22); Console.Write(" correo electronico no valido");
                return false;
            }
        }

        //public string Concepto(double Promedio)
        //{
        //    if (Promedio >= 3.5)
        //        return "Aprobado";
        //    else
        //        return "Reprobado";

        //}

        public bool Numcaracteres(string texto)
        {
            Regex regla = new Regex("^[0-9]{4}$");

            if (regla.IsMatch(texto))
                return true;
            else
            {
                Console.SetCursorPosition(40, 22); Console.Write(" EL codigo tiene que tener 4 caracteres");
                return false;
            }
        }
    
    }
}
