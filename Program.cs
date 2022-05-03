using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Recursividad {
  class Program {
    public static void Main(String[] args) {
      // ****************************** Kevin **************************************************************
      // En esta parte instanciamos un nuevo objeto para realizar la conversion
      // de Prefijo a Posfijo
      var nuevaConversion = new Conversion();
      // Ingresamos la expresion prefija para convertir a posfija
      string prefijo = "*+ABC";
      nuevaConversion.prefijoAPosfijo(prefijo);
      // ***************************************************************************************************
      // ****************************** Carlos *************************************************************
      // Pasamos por parametro la expresion en infijo para convertirlo a Prefijo y PostFijo
      infijoPrefijoPostfijo("(2+3)*5");
      static void infijoPrefijoPostfijo (string infijo) {
        string expresion = infijo;
        int tamaño = expresion.Length;
        //CREAMOS EL ARREGLO PARA SEPARAR POR CARACTERES
        string[] expresionSeparada = new string[tamaño];

        //CONVERTIR A PREFIJO
        //CREAMOS EL ARREGLO DONDE SE ALMACENARÁ EL RESULTADO
        string[] resultado = new string[tamaño];
        //LLENAMOS EL ARREGLO SEPARANDO LA PALABRA INGRESADA
        for (int i = 0; i < tamaño; i++) {
          expresionSeparada[i] = expresion[i].ToString();
        }
        //CREAMOS LA PILA DE OPERADORES
        Stack operadores = new Stack();
        //RECORREMOS EL ARRAY expresionSeparada DE DERECHA A IZQUIERDA
        int cont = 0;
        bool vaciarPila = true;
        for (int i = tamaño; i > 0; i--) {
          string caracter = expresionSeparada[i - 1];
          //Console.Write(caracter);

          //GUARDAMOS EN ARRAY resultado SI ES OPERANDO O GUARDAMOS EN PILA operadores SI ES OPERADOR 
          if (caracter.Equals("+") || caracter.Equals("-") || caracter.Equals("*") || caracter.Equals("/") || caracter.Equals(")")) {
            operadores.Push(caracter);
          }
          else if (caracter.Equals("(")) {
            //SI EL CARACTER ES '(' VACIAMOS LO QUE HAYA EN LA PILA HASTA ENCONTRAR EL CARACTER ')'
            string current = "(";
            vaciarPila = true;
            while (vaciarPila) {
              current = operadores.Pop().ToString();
              if (current.Equals(")") && operadores.Count >= 0) {
                vaciarPila = false;
              }
              else {
                resultado[cont] = current;
                cont++;
              }
            }
          }
          else {
            resultado[cont] = caracter;
            cont++;
          }
        }
        //TODOS LOS ELEMENTOS SOBRANTES EN LA PILA operadores SE GUARDAN EN EL ARREGLO resultado
        for (int i = 0; i < operadores.Count; i++) {
          resultado[cont] = operadores.Pop().ToString();
          cont++;
        }
        //MOSTRAMOS EL ARREGLO RESULTADO
        Console.WriteLine();
        Console.WriteLine("PREFIJO: ");
        for (int i = resultado.Length - 1; i >= 0; i--) {
          Console.Write(resultado[i]); 
        }

        //CONVERTIR A POSTFIJO
        //CREAMOS EL ARREGLO DONDE SE ALMACENARÁ EL RESULTADO
        string[] resultado2 = new string[tamaño];
        //CREAMOS LA PILA DE OPERADORES
        Stack operadores2 = new Stack();
        //RECORREMOS EL ARRAY expresionSeparada DE IZQUIERDA A DERECHA
        int cont2 = 0;
        bool vaciarPila2 = true;
        for (int i = 0; i < tamaño; i++) {
          string caracter2 = expresionSeparada[i];
          //Console.Write(caracter);

          //GUARDAMOS EN ARRAY resultado SI ES OPERANDO O GUARDAMOS EN PILA operadores SI ES OPERADOR 
          if (caracter2.Equals("+") || caracter2.Equals("-") || caracter2.Equals("*") || caracter2.Equals("/") || caracter2.Equals("(")) {
            operadores2.Push(caracter2);
          }
          else if (caracter2.Equals(")")) {
            //SI EL CARACTER ES ')' VACIAMOS LO QUE HAYA EN LA PILA HASTA ENCONTRAR EL CARACTER '('
            string current2 = ")";
            vaciarPila2 = true;
            while (vaciarPila2) {
              current2 = operadores2.Pop().ToString();
              if (current2.Equals("(") && operadores2.Count >= 0) {
                vaciarPila2 = false;
              }
              else {
                resultado2[cont2] = current2;
                cont2++;
              }
            }
          }
          else {
            resultado2[cont2] = caracter2;
            cont2++;
          }
        }
        //TODOS LOS ELEMENTOS SOBRANTES EN LA PILA operadores SE GUARDAN EN EL ARREGLO resultado
        for (int i = 0; i < operadores2.Count; i++) {
          resultado2[cont2] = operadores2.Pop().ToString();
          cont2++;
        }
        //MOSTRAMOS EL ARREGLO RESULTADO
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("POSTFIJO: ");
        for (int i = 0; i < resultado2.Length; i++) {
          Console.Write(resultado2[i]);
        }


        //RESOLVER LA EXPRESIÓN MATEMÁTICA
        Console.WriteLine();
        Console.WriteLine("El resultado de " + expresion + " es igual a ");
        
        static double Evaluar(String expression) {
          //Creo un DataTable
          System.Data.DataTable table = new System.Data.DataTable();
          //Realizo el cálculo..
          object result = table.Compute(expression, string.Empty);
          //Lo devuelvo convertido a Double
          return Convert.ToDouble(result);
        }
        var result = Evaluar(expresion);
        Console.WriteLine(result);
        Console.ReadLine();
      }
      // ***************************************************************************************************
      // ****************************** Jhonatan ***********************************************************
      // ***************************************************************************************************

    }
  }
}