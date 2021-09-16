using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el operador sea '+' '-' '*' o '/'
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Retorna el operador si es valido, si no lo es retorna el operador '+'</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador.Equals("+") || operador.Equals("-") || operador.Equals("*") || operador.Equals("/"))
                return operador;

            return "+";
        }


        /// <summary>
        /// Realiza el calculo seleccionado entre los dos numeros
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Indica la operacion a realizar</param>
        /// <returns>Resultado de la operacion</returns>
        public static double Operar(Operando num1, Operando num2, string operador)
        {
            operador = ValidarOperador(operador);

            switch (operador)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                default:
                    return 0;
            }
        }
    }
}
