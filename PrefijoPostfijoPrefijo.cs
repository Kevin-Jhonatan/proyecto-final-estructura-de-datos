namespace Recursividad
{
  // La clase de Nodo de pila o nodo para la pila
  public class NodoDePila {
    public String dato;
    public NodoDePila siguiente;
    public NodoDePila(String dato, NodoDePila tope){
      this.dato = dato;
      this.siguiente = tope;
    }
  }
  // La clase Pila donde se apila y desapila
  public class MiPila {
    public NodoDePila tope;
    public int contar;
    public MiPila() {
      this.tope = null;
      this.contar = 0;
    }
    // Nos retorna el numero de elementos de la pila
    public int tamañoPila() {
      return this.contar;
    }
    // Vemos si nuestra pila esta vicia
    public bool pilaVacia() {
      bool vacia = false;
      if (this.tamañoPila() > 0) {
        vacia = false;
        return vacia;
      }
      else {
        vacia = true;
        return vacia;
      }
    }
    // Apilamos un nuevo elemento a la pila Este es el 
    // ******* Push ******* 
    public void apilar(string dato) {
      // Instanciamos un nuevo nodo de pila y seteamos o asignamos su valor a tope
      this.tope = new NodoDePila(dato, this.tope);
      this.contar++;
    }
    // Apilamos un nuevo tope a la pila
    // ***** pop *****
    public String apilarTope() {
      var temporal = "";
      if (this.pilaVacia() == false) {
        // Obtenemos en valor del tope y le asignamos a temporal su valor
        temporal = this.tope.dato;
        this.tope = this.tope.siguiente;
        this.contar--;
      }
      return temporal;
    }
    // Lo usamos para obtener el elemento superior de la pila
    public String desapilarTope() {
      if (!this.pilaVacia()) {
        return this.tope.dato;
      }
      else {
        return "";
      }
    }
  }
  // La clase para la Conversion de prefijo a postfijo
  public class Conversion {
    // Comprovamos o verificamos si en valor de texto que es un char es igual a operador
    public bool esOperador(char texto) {
      bool soyOperador = false;
      if (texto == '+' || texto == '-' || texto == '*' || texto == '/' || texto == '^' || texto == '%') {
        soyOperador = true;
        return soyOperador;
      }
      return soyOperador;
    }
    // Comprovamos o verificamos si en valor de texto que es un char es igual a operando
    public bool esOperando(char texto) {
      bool soyOperando = false;
      if ((texto >= '0' && texto <= '9') || (texto >= 'a' && texto <= 'z') || (texto >= 'A' && texto <= 'Z')) {
        soyOperando = true;
        return soyOperando;
      }
      return soyOperando;
    }
    // Aqui realizamos la conversion de prefijo a postfijo
    public void prefijoApostfijo(string prefijo) {
      // Obtenemos el tamaño del prefijo ingresado y lo asignamos a tamañoPila
      var tamañoPila = prefijo.Length;
      // Instanciamos un nuevo objeto -> nuevaPila con la clase MiPila 
      var nuevaPila = new MiPila();
      // Aqui declaramos variables que nos ayudaran a almacenar el resultado actual
      var auxiliar = "";
      var operacion1 = "";
      var operacion2 = "";
      bool esValido = true;
      for (int i = tamañoPila - 1; i >= 0; i--) {
        // Verificamos si el elemento del prefijo es operador en cada posicion
        if (this.esOperador(prefijo[i])) {
          // Cuando se encuentra un operador vemos si tiene 2 operandos o solo 1
          if (nuevaPila.tamañoPila() > 1) {
            operacion1 = nuevaPila.apilarTope();
            operacion2 = nuevaPila.apilarTope();
            auxiliar = operacion1 + operacion2 + prefijo[i];
            nuevaPila.apilar(auxiliar);
          }
          else {
            esValido = false;
          }
        }
        else if (this.esOperando(prefijo[i])) {
          // De igual forma verificamos si es operando
          auxiliar = prefijo[i].ToString();
          nuevaPila.apilar(auxiliar);
        }
        else {
          // Si el operador u operando no es valido retornamos esValido = false;
          esValido = false;
        }
      }
      if (esValido == false) {
        // En caso nuestro prefijo este mal formulado imprimimos un mensaje
        // indicando que el prefijo ingresado en invalido y mostramos lo que ingreso
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Prefijo invalido : " + prefijo);
      }
      else {
        // En esta parte imprimimos los resultados ya obtenidos osea la expresion en postfijo
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("************ Conversión de Prefijo a Postfijo exitosa ************");
        Console.WriteLine("Antes   -> Prefijo   : " + prefijo);
        Console.WriteLine("Despues -> Postfijo  : " + nuevaPila.apilarTope());
        Console.WriteLine("******************************************************************");
      }
    }
    // Aqui realizamos la conversion de postfijo a prefijo
    public void postfijoAPrefijo(string postfijo) {
      // Obtenemos el tamaño del prefijo ingresado y lo asignamos a tamañoPila
      var tamañoPila = postfijo.Length;
      // Instanciamos un nuevo objeto -> nuevaPila con la clase MiPila 
      var nuevaPila = new MiPila();
      // Aqui declaramos variables que nos ayudaran a almacenar el resultado actual
      var auxiliar = "";
      var esValido = true;
      for (var i = 0; i < tamañoPila && esValido; i++) {
        // Verificamos si el elemento del prefijo es operador en cada posicion
        if (this.esOperador(postfijo[i])) {
          // Cuando se encuentra un operador vemos si tiene 2 operandos o solo 1
          if (nuevaPila.tamañoPila() > 1) {
            auxiliar = nuevaPila.apilarTope();
            auxiliar = nuevaPila.apilarTope() + auxiliar;
            auxiliar = postfijo[i] + auxiliar;
            nuevaPila.apilar(auxiliar);
          }
          else {
            esValido = false;
          }
        }
        else if (this.esOperando(postfijo[i])) {
          // De igual forma verificamos si es operando
          auxiliar = postfijo[i].ToString();
          nuevaPila.apilar(auxiliar);
        }
        else {
          // Si el operador u operando no es valido retornamos esValido = false;
          esValido = false;
        }
      }
      if (esValido == false) {
        // En caso nuestro postfijo este mal formulado imprimimos un mensaje
        // indicando que el postfijo ingresado en invalido y mostramos lo que ingreso
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Postfijo invalido : " + postfijo);
      }
      else {
        // En esta parte imprimimos los resultados ya obtenidos osea la expresion en prefijo
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("************ Conversión de Postfijo a Prefijo exitosa ************");
        Console.WriteLine("Antes   -> Postfijo  : " + postfijo);
        Console.WriteLine("Despues -> Prefijo   : " + nuevaPila.apilarTope());
        Console.WriteLine("******************************************************************");
      }
    }
  }
}