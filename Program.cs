using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using ControlProgresos2.Personajes;

namespace ControlProgresos2
{
    static class Constantes
    {
        public enum TipoPersonaje { 
            Guerrero = 1,
            Mago = 2,
            Arquero = 3,
            Artesano = 4
        };
        public static DateTime hoy = DateTime.Now;
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Personaje> personajes = new List<Personaje>();
            int cond = 0; int indice = 0;
            var rand = new Random();
            Console.WriteLine("¡JUEGO DE ROL!");

            do
            {
                Console.WriteLine("__MENU__\n(1) CARGAR PERSONAJES\n(2) MOSTRAR PERSONAJES CARGADOS\n(3) CARGAR CARACTERISTICAS\n(4) MOSTRAR CARACTERISTICAS\n(5) COMENZAR!!!\n(0) SALIR");
                cond = Convert.ToInt32(Console.ReadLine());
                if (cond == 1) {
                    personajes.Add(generarPersonaje());
                    listarPersonajes(personajes);
                }
                else if (cond == 2){
                    listarPersonajes(personajes);
                    Console.WriteLine("INGRESE ID DEL PERSONAJE: ");
                    indice = Convert.ToInt32(Console.ReadLine()) -1;
                    mostrarDatosCargados(personajes, indice);
                }
                else if (cond == 3)
                {
                    Console.WriteLine("CARGAR DATOS DEL PERSONAJE N°: ");
                    indice = Convert.ToInt32(Console.ReadLine()) - 1;
                    cargarCaracteristicas(personajes, indice);
                    listarPersonajes(personajes);
                }
                else if (cond == 4)
                {
                    listarPersonajes(personajes);
                    Console.WriteLine("INGRESE ID DEL PERSONAJE: ");
                    indice = Convert.ToInt32(Console.ReadLine()) -1;
                    mostrarCaracteristicas(personajes, indice);
                }
                else if (cond == 5)
                {
                    indice = rand.Next(2);
                    uint danio = 0;
                    Console.WriteLine("¡COMIENZA PELEA! - GOLPEA PRIMERO EL PERSONAJE {0} {1}", indice+1, personajes[indice].Apodo);
                    for (int i = 0; i < 6; i++) {
                        if (indice == 0) {
                            danio = (uint)Convert.ToInt32(personajes[1].DanioProvocado());
                            Console.WriteLine("danio: {0} ||| {1} --> {2}", danio, personajes[0].Apodo, personajes[1].Apodo);
                            //personajes[1].Salud = personajes[1].Salud - (uint)Convert.ToInt32(personajes[0].DanioProvocado());
                            personajes[1].Salud -= danio;
                            indice = 1;                            

                        }else if (indice == 1){
                            danio = (uint)Convert.ToInt32(personajes[1].DanioProvocado());
                            Console.WriteLine("danio: {0} ||| {1} --> {2}", danio, personajes[1].Apodo, personajes[0].Apodo);
                            //personajes[0].Salud = personajes[0].Salud - (uint)Convert.ToInt32(personajes[1].DanioProvocado());
                            personajes[0].Salud -= danio;
                            indice = 0;

                        }
                        

                    }

                    Console.WriteLine("\n-------");
                    Console.WriteLine("NOMBRE: {0} - NICKNAME: {1} - SALUD{2}\n", personajes[0].Nombre, personajes[0].Apodo, personajes[0].Salud);
                    Console.WriteLine("NOMBRE: {0} - NICKNAME: {1} - SALUD{2}\n", personajes[1].Nombre, personajes[1].Apodo, personajes[1].Salud);
                    Console.WriteLine("-------\n");

                    if (personajes[0].Salud < personajes[1].Salud) {
                        Console.WriteLine("GANO EL PERSONAJE {0} CON {1} DE SALUD", personajes[1].Apodo, personajes[1].Salud);
                        personajes[1].Salud += 10;
                        personajes.RemoveAt(0);
                        
                    }else if (personajes[1].Salud < personajes[0].Salud)
                    {
                        Console.WriteLine("GANO EL PERSONAJE {0} CON {1} DE SALUD", personajes[0].Apodo, personajes[0].Salud);
                        personajes[0].Salud += 10;
                        personajes.RemoveAt(1);
                    }



                }
            } while (cond != 0);
            
        }

        public static void cargarCaracteristicas(List<Personaje> lista, int indice) {
            var rand = new Random();
            lista[indice].Velocidad = (uint)rand.Next(1, 11);
            lista[indice].Destreza = (uint)rand.Next(1, 6);
            lista[indice].Fuerza = (uint)rand.Next(1, 11);
            lista[indice].Nivel = (uint)rand.Next(1, 11);
            lista[indice].Armadura = (uint)rand.Next(1, 11);
            Console.WriteLine("CARACTERISTICAS CARGADAS!");
        }
        public static Personaje generarPersonaje()
        {
            int diaNac, mesNac, anioNac, tipo;
            Personaje aux = new Personaje();
            Console.WriteLine("__CARGANDO DATOS DE PERSONAJE__");
            Console.WriteLine("TIPO DE PERSONAJE: 1 GUERRERO - 2 MAGO - 3 ARQUERO - 4 ARTESANO: ");
            tipo = Convert.ToInt32(Console.ReadLine());
            aux.Tipo = ((Constantes.TipoPersonaje)tipo).ToString();
            Console.WriteLine("NOMBRE: ");
            aux.Nombre = (Console.ReadLine());
            Console.WriteLine("NICKNAME: ");
            aux.Apodo= (Console.ReadLine());
            Console.WriteLine("DIA DE NACIMIENTO: ");diaNac = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("MES DE NACIMIENTO: "); mesNac = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ANIO DE NACIMIENTO: "); anioNac = Convert.ToInt32(Console.ReadLine());
            aux.Nacimiento = new DateTime(anioNac, mesNac, diaNac);
            aux.Edad = (uint)Constantes.hoy.Year - (uint)aux.Nacimiento.Year;
            aux.Salud = 100;
            Console.Clear();
            return aux;
        }
        public static void mostrarDatosCargados(List<Personaje> lista, int indice) {
            Console.Clear();
            Console.WriteLine("__MOSTRAR DATOS CARGADOS__\n");
            Console.WriteLine("__PERSONAJE ({0})__", indice);
            Console.WriteLine("TIPO: " + lista[indice].Tipo);
            Console.WriteLine("NOMBRE: " + lista[indice].Nombre);
            Console.WriteLine("NICKNAME: " + lista[indice].Apodo);
            Console.WriteLine("NACIMIENTO: {0}/{1}/{2}", lista[indice].Nacimiento.Day, lista[indice].Nacimiento.Month, lista[indice].Nacimiento.Year);
            Console.WriteLine("EDAD: {0}", lista[indice].Edad);
            Console.WriteLine("SALUD: {0}", lista[indice].Salud);
            Console.WriteLine("_____________\n");
        }
        public static void mostrarCaracteristicas(List<Personaje> lista, int indice)
        {
            Console.Clear();
            Console.WriteLine("__MOSTRAR CARACTERISTICAS__\n");
            Console.WriteLine("__PERSONAJE ({0})__", indice + 1);
            Console.WriteLine("VELOCIDAD: " + lista[indice].Velocidad);
            Console.WriteLine("DESTREZA: " + lista[indice].Destreza);
            Console.WriteLine("FUERZA: " + lista[indice].Fuerza);
            Console.WriteLine("NIVEL: " + lista[indice].Nivel);
            Console.WriteLine("ARMADURA: " + lista[indice].Armadura);
            Console.WriteLine("_____________\n");
        }
        public static void listarPersonajes(List<Personaje> lista)
        {
            Console.Clear();
            Console.WriteLine("__MOSTRAR CARACTERISTICAS__\n");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine("__PERSONAJE ({0})__", i + 1);
                Console.WriteLine("TIPO: " + lista[i].Tipo);
                Console.WriteLine("NOMBRE: " + lista[i].Nombre);
                Console.WriteLine("NICKNAME: " + lista[i].Apodo);
                Console.WriteLine("_____________\n");
            }
        }

    }
}
