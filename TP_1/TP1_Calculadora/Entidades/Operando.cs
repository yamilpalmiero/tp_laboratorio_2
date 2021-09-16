using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;


        /// <summary>
        /// Constructor sin parametros que inicializa el numero con el valor cero.
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor que recibe un valor Double para inicializar el atributo numero
        /// </summary>
        /// <param name="numero">Valor con que se inicializa el atributo numero</param>
        public Operando(double numero)
            : this()
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor que recibe una cadena para inicializar el atributo numero
        /// </summary>
        /// <param name="strNumero">Cadena para inicializar el atributo numero</param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }



        /// <summary>
        /// Asigna un valor al atributo numero, previa validacion 
        /// </summary>
        public string Numero
        {
            set { this.numero = ValidarOperando(value); }
        }


        /// <summary>
        /// Comprueba que el valor recibido sea numerico
        /// </summary>
        /// <param name="strNumero">Numero a validar</param>
        /// <returns>El numero si es numerico, si no lo es, cero</returns>
        private static double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double operando))
                return operando;

            return 0;
        }

        /// <summary>
        /// Valida que la cadena recibida este compuesta solo por caracteres '0' o '1'
        /// </summary>
        /// <param name="binario">Cadena a validar</param>
        /// <returns>Verdadero si es un numero binario, falso si no lo es</returns>
        private static bool EsBinario(string binario)
        {
            bool esBinario = true;

            foreach (char i in binario)
            {
                if (i != '0' && i != '1')
                {
                    esBinario = false;
                }
            }
            return esBinario;
        }

        /// <summary>
        /// Valida que el valor recibido sea binario y lo convierte a decimal
        /// </summary>
        /// <param name="binario">Cadena a validar</param>
        /// <returns>Retorna el numero convertido a decimal y si no se puede devuelve un mensaje de error</returns>
        public string BinarioDecimal(string binario)
        {
            char[] arrayBinario = binario.ToCharArray();//Guardo el string numero binario en un array de char
            double numeroDecimal = 0;

            Array.Reverse(arrayBinario);

            if (EsBinario(binario))
            {
                for (int i = 0; i < arrayBinario.Length; i++)
                {
                    if (arrayBinario[i] == '1')//Si es 1 le sumo 2 elevado a i al acumulador
                        numeroDecimal += (double)Math.Pow(2, i);
                }
                return numeroDecimal.ToString();
            }

            return "Valor inválido";
        }

        /// <summary>
        /// Convierte el valor recibido en binario
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Retorna el numero convertido a binario y si no se puede devuelve un mensaje de error</returns>
        public string DecimalBinario(double numero)
        {
            string binario = string.Empty;
            int numeroEntero = (int)Math.Abs(numero);//Trabajo solo con el valor absoluto y entero del double recibido

            if (numeroEntero == 0)
                binario = "0";
            else
                while (numeroEntero > 0)
                {
                    binario = (int)numeroEntero % 2 + binario;
                    numeroEntero = (int)numeroEntero / 2;
                }

            return binario;
        }

        /// <summary>
        /// Convierte la cadena recibida en binario
        /// </summary>
        /// <param name="numero">Cadena a convertir</param>
        /// <returns>Retorna el numero convertido a binario y si no se puede devuelve un mensaje de error</returns>
        public string DecimalBinario(string numero)
        {
            if (double.TryParse(numero, out double numeroDouble))
                return DecimalBinario(numeroDouble);

            return "Valor invalido";
        }



        /// <summary>
        /// Realiza la resta entre dos Operandos
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Segundo Operando</param>
        /// <returns>Resultado de la resta</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Realiza la multiplicacion entre dos Operandos
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Segundo Operando</param>
        /// <returns>Producto obtenido</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Realiza la division entre dos Operandos
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Segundo Operando</param>
        /// <returns>Cociente obtenido</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
                return double.MinValue;

            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Realiza la suma entre dos Operandos
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Segundo Operando</param>
        /// <returns>Resultado de la suma</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
    }
}
