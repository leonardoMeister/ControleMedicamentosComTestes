using ControleMedicamentos.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.Tests.ModuloFuncionario
{
    [TestClass]
    public class UnitFuncionarioTeste
    {
        [TestMethod]
        public void DeveImpedirCriarFuncionario()
        {
            ValidadorFuncionario validador = new ValidadorFuncionario();

            Funcionario forne = new Funcionario("le", "LeonardoMargoti", "SenhaParaLeo");
            var result = validador.Validate(forne);
            Assert.AreEqual(result.IsValid, false);

            Funcionario forne2 = new Funcionario("leonardo", "", "SenhaParaLeo");
            result = validador.Validate(forne);
            Assert.AreEqual(result.IsValid, false);

            Funcionario forne3 = new Funcionario("Leonardo", "LeonardoMargoti", "le");
            result = validador.Validate(forne);
            Assert.AreEqual(result.IsValid, false);
        }
        [TestMethod]
        public void DevePermitirCriarFuncionario()
        {
            ValidadorFuncionario validador = new ValidadorFuncionario();
            Funcionario forne = new Funcionario("Leonardo","LeonardoMargoti","SenhaParaLeo");
            var result = validador.Validate(forne);
            Assert.AreEqual(result.IsValid, true);

        }

    }
}
