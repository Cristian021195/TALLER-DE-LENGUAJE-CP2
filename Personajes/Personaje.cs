using System;
using System.Collections.Generic;
using System.Text;



namespace ControlProgresos2.Personajes
{    
    public class Personaje
    {
        //datos
        private string tipo;
        private string nombre;
        private string apodo;
        private DateTime nacimiento;
        private uint edad;
        private uint salud;
        //caracteristicas
        private uint velocidad;
        private uint destreza;
        private uint fuerza;
        private uint armadura;
        private uint nivel;



        public string Tipo{ get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime Nacimiento { get => nacimiento; set => nacimiento = value; }
        public uint Edad { get => edad; set => edad = value; }
        public uint Salud { get => salud; set => salud = value; }
        public uint Velocidad { get => velocidad; set => velocidad = value; }
        public uint Destreza { get => destreza; set => destreza = value; }
        public uint Fuerza { get => fuerza; set => fuerza = value; }
        public uint Armadura { get => armadura; set => armadura = value; }
        public uint Nivel { get => nivel; set => nivel = value; }

        public float DanioProvocado() {
            var rand = new Random();
            float MDP = 5000f; 
            float PD = Destreza * Fuerza * Nivel;
            int ED = rand.Next(1, 101);
            float VA = PD*ED;
            int PDEF = (int)Armadura * (int)Velocidad;
            float DPROV = ((VA - PDEF) / MDP)*10;

            return DPROV;
        } 
    }
}
