using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Biblia
{
    public class RFC
    {
        

            // Método que valida si el RFC tiene el formato correcto
            public static bool PruebaRFC(string RFC)
            {
            // Método que corrige errores
            RFC = RFC.ToUpper();

            //Expresion para el formato
            string regla = @"^[A-ZÑ&]{3}[A-Z]{1}\d{6}[A-Z0-9]{3}$";

            // Comprueba si el RFC cumple la regla
            return Regex.IsMatch(RFC, regla);
            }
 
        
        }
    
}
