using ControleMedicamentos.Dominio.ModuloPaciente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.Tests.ModuloPaciente
{
    [TestClass]
    public class UnitPacienteTeste
    {
        [TestMethod]
        public void DeveImpedirCriarPaciente()
        {
            ValidadorPaciente validador = new ValidadorPaciente();

            Paciente pac1 = new Paciente("Leonardo","322 0000 0000 ");
            var result = validador.Validate(pac1);
            Assert.AreEqual(result.IsValid, false);

            Paciente pac2 = new Paciente("", "322 0000 0000 0000");
            result = validador.Validate(pac2);
            Assert.AreEqual(result.IsValid, false);

            Paciente pac3 = new Paciente("leonardo", "");
            result = validador.Validate(pac3);
            Assert.AreEqual(result.IsValid, false);

        }
        [TestMethod]
        public void DevePermitirCriarPaciente()
        {
            ValidadorPaciente validador = new ValidadorPaciente();

            Paciente pac1 = new Paciente("Leonanrdo", "322 0000 0000 0000");
            var result = validador.Validate(pac1);
            Assert.AreEqual(result.IsValid, true);
        }        
    }
}
