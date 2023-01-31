using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCalculadora
{
    public class Calculadora
    {
        private char[] delimitador = new char[] { ',', ';','|' };

        public int Add(string values)
        {
            if (string.IsNullOrEmpty(values))
                return 0;

            if (values.IndexOfAny(delimitador) < 0)
                throw new Exception("El caracter utilizado como separador no es valido.");

            return values.Split(delimitador)
                .Select(v => ParseValue(v))
                .Sum();
        }

        private int ParseValue(string v)
        {
            int parsedValue = 0;

            if (!int.TryParse(v, out parsedValue))
                throw new Exception($"{v} El valor no se puede convertir en un numero entero.");

            if (parsedValue < 0)
                throw new Exception("el valor debe ser positivo.");

            if (parsedValue > 100)
                return 0;

            return parsedValue;
        }
    }
}
