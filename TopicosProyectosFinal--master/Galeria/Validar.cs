using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblia
{
    public class Validar
    {
            public static bool Numeros(string Texto)
            {
                //recorre el texto para ver si solo son numeros
                foreach (char c in Texto)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;// Si hay algun caracter que no es una numero, retorna false
                    }

                }
                return true;  // Si todos los caracteres son numeros, retorna true

            }

            public static bool Letras(string Texto)
            {
                //recorre el texto para ver si solo son letras
                foreach (char c in Texto)
                {
                    if (!char.IsLetter(c))
                    {
                        return false;// Si hay algun caracter que no es una letra, retorna false
                    }
                }
                    return true;  // Si todos los caracteres son letras, retorna true
            }

        }

    
}

