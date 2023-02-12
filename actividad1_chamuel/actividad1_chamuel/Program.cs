using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace actividad1_chamuel
{
    
    class Program
    {
        //Clase Punto
        public class Punto //Comienzo de clase Punto
        {
            private float _x;    //Atributos
            private float _y;

            public Punto(float x, float y)  //Constructor por parametro -> Para poder modificar los atributos privados
            {
                _x = x;
                _y = y;
            }

            public Punto()  //Constructor por defecto -> Para poder modificar los atributos privados 
            {
                _x = 0;
                _y = 0;
            }

            //metodos

            public void SetXY(float X, float Y) //Agarra el valor
            {                                    
                _x = X;
                _y = Y;
            }

            public float GetX()
            {
                return _x;  // usar el valor que almacena el artibuto(X)
            }
            public float GetY()
            {
                return _y;  // usar el valor que almacena el artibuto(y)
            }
        } //Fin de Punto   

        public class Clase_vector_chamuel //Clase vector
        {
            private Punto _origen; //Atributo de vector
            private Punto _fin;

            public Clase_vector_chamuel(Punto origen, Punto fin) //Constructor por parametro 
            {
                _origen = origen;
                _fin = fin;
            }

            public Clase_vector_chamuel()
            {
                _origen = new Punto(0, 0);
                _fin = new Punto(0, 0);
            }

            //Metodo
            public void MandarDatos(float origenX, float origenY, float finX, float finY) //Rellenar atributos(Funcion)
            {
                _origen.SetXY(origenX, origenY);
                _fin.SetXY(finX, finY);

            }
            //Sobrecarga Resta
            //sobrecarga hace que el prgrama entienda cuando hay vector - vector, hacer operaciones con clases
           
            public static Clase_vector_chamuel operator -(Clase_vector_chamuel Resta1, Clase_vector_chamuel Resta2)
            {
                Punto nuevo_origen = new Punto(Resta1._origen.GetX() - Resta2._origen.GetX(),
                                               Resta1._origen.GetY() - Resta2._origen.GetY());

                Punto nuevo_fin = new Punto(Resta1._fin.GetX() - Resta2._fin.GetX(),
                                            Resta1._fin.GetY() - Resta2._fin.GetY());

                return new Clase_vector_chamuel(nuevo_origen, nuevo_fin);
            }

            //Sobrecarga del operador de Multiplicación por un escalar
            public static Clase_vector_chamuel operator *(Clase_vector_chamuel Escalar1, float valor)
            {
                Punto nuevo_origen = new Punto(Escalar1._origen.GetX() * valor,
                                               Escalar1._origen.GetY() * valor);

                Punto nuevo_fin = new Punto(Escalar1._fin.GetX() * valor,
                                            Escalar1._fin.GetY() * valor);


                return new Clase_vector_chamuel(nuevo_origen, nuevo_fin); //Mando 2 puntos de nuevo vector
            }

            //sobrecarga del operador de Multiplicación por un vector siguiendo la definición de la multiplicación punto

            public static float operator *(Clase_vector_chamuel multiplicar1, Clase_vector_chamuel multiplicar2)
            {
                float multi = ((multiplicar1._origen.GetX() * multiplicar2._origen.GetX())
                        + (multiplicar1._origen.GetY() * multiplicar2._origen.GetY()
                            + multiplicar1._fin.GetX() * multiplicar2._fin.GetX())
                                + (multiplicar1._fin.GetY() * multiplicar2._fin.GetY()));
                
                return (multi);
            }

            //metodo
            public void Imprimir( ) //Imprimir
            {
                Console.WriteLine($"OrigenX {_origen.GetX()}\nOrigenY {_origen.GetY()}\nFinX {_fin.GetX()}\nFinY {_fin.GetY()}\n\n");
            }

        }//Fin clase 
        static void Main(string[] args)
        {   
            //Resta
            Clase_vector_chamuel Vector1 = new Clase_vector_chamuel(); //Creando atributo
            Vector1.MandarDatos(1,2,3,4);           //Mandar datos(parametro) de Resta1

            Clase_vector_chamuel Vector2 = new Clase_vector_chamuel(); //Creando atributo
            Vector2.MandarDatos(4,3,2,1);           //Mandar datos(parametro) de Resta1

            Clase_vector_chamuel Vector3 = new Clase_vector_chamuel();//Operacion
            Vector3 = Vector1 - Vector2; 

            Vector3.Imprimir();

            //Sobrecarga del operador de Multiplicación por un escalar

            Clase_vector_chamuel Vector4 = new Clase_vector_chamuel();
            Vector4 = Vector1 * 5;
            Vector4.Imprimir();

            //sobrecarga del operador de Multiplicación por un vector siguiendo la definición de la multiplicación punto
            float Resultado = Vector1 * Vector2;
            Console.WriteLine($"Resultado es : {Resultado}");

            Console.ReadKey();
        }
    }
}
