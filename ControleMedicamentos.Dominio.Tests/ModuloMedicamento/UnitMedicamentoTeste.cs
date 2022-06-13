using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamentos.Dominio.ModuloFuncionario;
using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Dominio.ModuloPaciente;
using ControleMedicamentos.Dominio.ModuloRequisicao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.Tests.ModuloMedicamento
{
    [TestClass]
    public class UnitMedicamentoTeste
    {
        [TestMethod]
        public void DeveImpedirCriarMedicamento()
        {
            ValidadorMedicamento validador = new ValidadorMedicamento();
            Fornecedor forn = new Fornecedor("leonardo", "48 88888-8989", "leonazinh@gmail.com", "MonteCastelo", "SC");

            Medicamento medicamento = new Medicamento("Dipirona", "Anti inflamatorio", "Lote 991", DateTime.Now, null);
            var result = validador.Validate(medicamento);
            Assert.AreEqual(result.IsValid, false);

            Medicamento medicamento2 = new Medicamento("Dipirona", "Anti inflamatorio", "", DateTime.Now, forn);
            result = validador.Validate(medicamento2);
            Assert.AreEqual(result.IsValid, false);

            Medicamento medicamento3 = new Medicamento("Dipirona", "", "Lote 991", DateTime.Now, forn);
            result = validador.Validate(medicamento3);
            Assert.AreEqual(result.IsValid, false);


            Medicamento medicamento4 = new Medicamento("", "Anti inflamatorio", "Lote 991", DateTime.Now, forn);
            result = validador.Validate(medicamento4);
            Assert.AreEqual(result.IsValid, false);
        }

        [TestMethod]
        public void DeveAdicionarQuantidadeMedicamento()
        {
            ValidadorMedicamento validador = new ValidadorMedicamento();
            Fornecedor forn = new Fornecedor("leonardo", "48 88888-8989", "leonazinh@gmail.com", "MonteCastelo", "SC");

            Medicamento medicamento = new Medicamento("Dipirona", "Anti inflamatorio", "Lote 991", DateTime.Now, forn);
            var result = validador.Validate(medicamento);
            Assert.AreEqual(result.IsValid, true);

            medicamento.AdicionarQuantidadeMedicamentos(10);

            Assert.AreEqual(medicamento.QuantidadeDisponivel, 10);            

        }

        [TestMethod]
        public void DeveAdicionarQuantidadeRequisicoesDeMedicamento()
        {
            ValidadorMedicamento validador = new ValidadorMedicamento();
            Fornecedor forn = new Fornecedor("leonardo", "48 88888-8989", "leonazinh@gmail.com", "MonteCastelo", "SC");

            Medicamento medicamento = new Medicamento("Dipirona", "Anti inflamatorio", "Lote 991", DateTime.Now, forn);
            var result = validador.Validate(medicamento);
            Assert.AreEqual(result.IsValid, true);

            medicamento.AdicionarQuantidadeMedicamentos(10);

            Assert.AreEqual(medicamento.QuantidadeDisponivel, 10);

            Funcionario funcionario = new Funcionario("Leonardo", "LeonardoMargoti", "SenhaParaLeo");

            Paciente pacinte = new Paciente("Leonanrdo", "322 0000 0000 0000");


            Requisicao req = new Requisicao(medicamento, pacinte, 5, DateTime.Now, funcionario);


            medicamento.AdicionarRequisicao(req);

            Assert.AreEqual(medicamento.QuantidadeDisponivel, 5);

            Assert.AreEqual(medicamento.Requisicoes.Count, 1);
        }

        [TestMethod]
        public void DevePermitirCriarMedicamento()
        {
            ValidadorMedicamento validador = new ValidadorMedicamento();
            Fornecedor forn = new Fornecedor("leonardo","48 88888-8989","leonazinh@gmail.com","MonteCastelo","SC");

            Medicamento medicamento = new Medicamento("Dipirona", "Anti inflamatorio", "Lote 991", DateTime.Now, forn);
            var result = validador.Validate(medicamento);
            Assert.AreEqual(result.IsValid, true);
        }        
    }
}
