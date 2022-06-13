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

namespace ControleMedicamentos.Dominio.Tests.ModuloRequisicao
{
    [TestClass]
    public class UnitRequisicaoTeste
    {
        [TestMethod]
        
        public void DeveImpedirCriarRequisicao()
        {
            ValidadorRequisicao validador = new ValidadorRequisicao();

            Fornecedor forn = new Fornecedor("leonardo", "48 88888-8989", "leonazinh@gmail.com", "MonteCastelo", "SC");
            Funcionario funcionario = new Funcionario("Leonardo", "LeonardoMargoti", "SenhaParaLeo");
            Medicamento medicamento = new Medicamento("Dipirona", "Anti inflamatorio", "Lote 991", DateTime.Now, forn);
            Paciente pacinte = new Paciente("Leonanrdo", "322 0000 0000 0000");



            Requisicao req = new Requisicao(medicamento,pacinte,10,DateTime.Now,funcionario);

            var resultado = validador.Validate(req);



        }
        [TestMethod]
        public void DevePermitirCriarRequisicao()
        {
            ValidadorRequisicao validador = new ValidadorRequisicao();

            Fornecedor forn = new Fornecedor("leonardo", "48 88888-8989", "leonazinh@gmail.com", "MonteCastelo", "SC");
            Funcionario funcionario = new Funcionario("Leonardo", "LeonardoMargoti", "SenhaParaLeo");
            Medicamento medicamento = new Medicamento("Dipirona", "Anti inflamatorio", "Lote 991", DateTime.Now, forn);
            medicamento.AdicionarQuantidadeMedicamentos(100);
            Paciente pacinte = new Paciente("Leonanrdo", "322 0000 0000 0000");



            Requisicao req = new Requisicao(medicamento, pacinte, 10, DateTime.Now, funcionario);
            medicamento.AdicionarRequisicao(req);

            var resultado = validador.Validate(req);

            Assert.AreEqual(true, resultado.IsValid);
        }
        
    }
}
