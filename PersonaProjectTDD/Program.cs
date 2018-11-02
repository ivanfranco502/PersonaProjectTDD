using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaProjectTDD
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
             * PERSONA
             *  Nombre - obligatorio
             *  Apellido - obligatorio
             *  DNI - obligatorio y numérico
             *  CELULAR - opcional y format NN-NNNN-NNNN
             */
        }
    }
    public class Persona
    {
        public int DNI;

        public Persona()
        {
            Nombre = "no es un nombre válido";
            DNI = -10000;
        }

        public Persona(string nombre, int dni, string celular)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new PersonaNombreException();
            }

            if (dni < 1)
            {
                throw new PersonaDNIException();
            }

            if (celular.Length != 12 && !string.IsNullOrEmpty(celular))
            {
                throw new PersonaCelularException();
            }

            this.Celular = celular;
            this.DNI = dni;
            this.Nombre = nombre;
        }

        public string Nombre { get; set; }
        public string Celular { get; set; }
    }

    public class PersonaNombreException: Exception
    {

    }

    public class PersonaDNIException : Exception
    {
    }

    public class PersonaCelularException : Exception
    {
    }
}
