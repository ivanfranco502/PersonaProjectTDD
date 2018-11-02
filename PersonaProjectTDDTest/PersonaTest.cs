using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonaProjectTDDTest
{
    using System;
    using System.Runtime.Remoting.Channels;
    using PersonaProjectTDD;

    [TestClass]
    public class PersonaTest
    {
        [TestMethod]
        public void DadoNombrePepeCrearUnaPersonaConElNombre_DebePersonaNombreTenerElValorCorrecto()
        {
            var nombre = "Pepe";

            var persona = new Persona(nombre, 1, "");

            Assert.AreEqual(nombre, persona.Nombre);
        }

        [TestMethod]
        public void DadoNombreVacioCrearPersona_DebeFallar()
        {
            Persona persona = new Persona();
            try
            {
                persona = new Persona("",1, "");
                
               throw new Exception();
            }
            catch (PersonaNombreException)
            {
                Assert.AreEqual("no es un nombre válido", persona.Nombre);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void DadoNombreNuloCrearPersona_DebeFallar()
        {
            Persona persona = new Persona();
            try
            {
                persona = new Persona(null, 1, "");

                throw new Exception();
            }
            catch (PersonaNombreException)
            {
                Assert.AreEqual("no es un nombre válido", persona.Nombre);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }

        [TestMethod]
        public void DadoDNI0CrearPersona_DebeFallar()
        {
            Persona persona = new Persona();
            try
            {
                persona = new Persona("Pepe", 0, "");

                throw new Exception();
            }
            catch (PersonaDNIException){
                Assert.AreEqual(-10000, persona.DNI);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void DadoDNINegativoCrearPersona_DebeFallar()
        {
            Persona persona = new Persona();
            try
            {
                persona = new Persona("Pepe", -1, "");

                throw new Exception();
            }
            catch (PersonaDNIException)
            {
                Assert.AreEqual(-10000, persona.DNI);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void DadoDNIPositivoCrearPersona_DebeAsignarDNICorrectamente()
        {
            var persona = new Persona("Pepe", 1, "");

            Assert.AreEqual(1, persona.DNI);
        }

        [TestMethod]
        public void DadoCelularVacioCrearPersona_DebeAsignarCelularCorrectamente()
        {
            var persona = new Persona("Pepe", 1, "");

            Assert.AreEqual("", persona.Celular);
        }

        //HACER TEST CELULAR CON NULO
        //HACER TEST APELLIDO

        [TestMethod]
        public void DadoCelular12CaracteresCrearPersona_DebeAsignarCelularCorrectamente()
        {
            var persona = new Persona("Pepe", 1, "12-3456-7890");

            Assert.AreEqual(12, persona.Celular.Length);
        }

        [TestMethod]
        public void DadoCelular11CaracteresCrearPersona_DebeAsignarCelularCorrectamente()
        {
            Persona persona = new Persona();
            try
            {
                persona = new Persona("Pepe", 1, "12-3456-789");
                
                throw new Exception();
            }
            catch (PersonaCelularException)
            {
                Assert.IsNull(persona.Celular);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void DadoCelular13CaracteresCrearPersona_DebeAsignarCelularCorrectamente()
        {
            Persona persona = new Persona();
            try
            {
                persona = new Persona("Pepe", 1, "12-3456-78901");

                throw new Exception();
            }
            catch (PersonaCelularException)
            {
                Assert.IsNull(persona.Celular);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        //HACER TEST GUIONES

        //HACER TEST DE NUMERO EN FORMATO
        //SPLIT, ELIMINAR GUIONES 
    }
}
