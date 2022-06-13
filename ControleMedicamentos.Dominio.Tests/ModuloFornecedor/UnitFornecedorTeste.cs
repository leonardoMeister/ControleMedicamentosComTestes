using ControleMedicamentos.Dominio.ModuloFornecedor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.Tests.ModuloFornecedor
{
    [TestClass]
    public class UnitFornecedorTeste
    {
        [TestMethod]
        public void DeveImpedirCriarFornecedor()
        {
            ValidadorFornecedor validador = new ValidadorFornecedor();

            Fornecedor forne = new Fornecedor("leonardo", "" ,"leozinhomm1@gmail.com","MOnte","SC");
            Fornecedor forne2 = new Fornecedor("le", "22 99939-8644", "leozinhomm1@gmail.com", "MOnte", "SC");
            Fornecedor forne3 = new Fornecedor("leonardo", "22 99939-8644", "leozinhomm1gmail.com", "MOnte", "SC");
            Fornecedor forne4 = new Fornecedor("leonardo", "9999939-8644", "leozinhomm1@gmail.com", "", "SC");
            Fornecedor forne5 = new Fornecedor("leonardo", "22 99939-8644", "leozinhomm1@gmail.com", "Monte", "");

            var result = validador.Validate(forne);
            Assert.AreEqual(result.IsValid ,false);
            Assert.AreEqual(result.Errors[0].ToString(), "Telefone Inválido");

            result = validador.Validate(forne2);
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.Errors[0].ToString(), "Nome não pode ser menor que 3");


            result = validador.Validate(forne3);
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.Errors[0].ToString(), "Email Inválido");

            result = validador.Validate(forne4);
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.Errors[0].ToString(), "'Cidade' deve ser informado.");


            result = validador.Validate(forne5);
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.Errors[0].ToString(), "'Estado' deve ser informado.");


        }
        [TestMethod]
        public void DevePermitirCriarFornecedor()
        {
            ValidadorFornecedor validador = new ValidadorFornecedor();
            Fornecedor forne = new Fornecedor("leonardo", "22 99939-8644", "leozinhomm1@gmail.com", "MOnte", "SC");
            var result = validador.Validate(forne);
            Assert.AreEqual(result.IsValid, true);


        }
    }
}
