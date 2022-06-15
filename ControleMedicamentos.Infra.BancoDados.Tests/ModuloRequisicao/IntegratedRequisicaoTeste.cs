using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamentos.Dominio.ModuloFuncionario;
using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Dominio.ModuloPaciente;
using ControleMedicamentos.Dominio.ModuloRequisicao;
using ControleMedicamentos.Infra.BancoDados.ModuloFornecedor;
using ControleMedicamentos.Infra.BancoDados.ModuloFuncionario;
using ControleMedicamentos.Infra.BancoDados.ModuloMedicamento;
using ControleMedicamentos.Infra.BancoDados.ModuloPaciente;
using ControleMedicamentos.Infra.BancoDados.ModuloRequisicao;
using ControleMedicamentos.Infra.BancoDados.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.Tests.ModuloRequisicao
{
    [TestClass]
    public  class IntegratedRequisicaoTeste
    {
        public IntegratedRequisicaoTeste()
        {
            string sql =
               @"DELETE FROM TBRequisicao;
                  DBCC CHECKIDENT (TBRequisicao, RESEED, 0)";
            Db.ExecutarComando(sql);

            string sql2 =
               @"DELETE FROM TBPaciente;
                  DBCC CHECKIDENT (TBPaciente, RESEED, 0)";
            Db.ExecutarComando(sql2);

            string sql3 =
                @"DELETE FROM TBFuncionario;
                  DBCC CHECKIDENT (TBFuncionario, RESEED, 0)";
            Db.ExecutarComando(sql3);

            string sql4 =
                @"DELETE FROM TBMedicamento;
                  DBCC CHECKIDENT (TBMedicamento, RESEED, 0)";
            Db.ExecutarComando(sql4);

            string sql5 =
                @"DELETE FROM TBFornecedor;
                  DBCC CHECKIDENT (TBFornecedor, RESEED, 0)";
            Db.ExecutarComando(sql5);

        }

        [TestMethod]
        public void DeveInserirRequisicao()
        {
            var controlador = new ControladorRequisicao();

            Fornecedor forn = new Fornecedor("leonardo", "48 88888-8989", "leonazinh@gmail.com", "MonteCastelo", "SC");
            new ControladorFornecedor().InserirNovo(forn);

            Funcionario funcionario = new Funcionario("Leonardo", "LeonardoMargoti", "SenhaParaLeo");
            new ControladorFuncionario().InserirNovo(funcionario);

            Medicamento medicamento = new Medicamento("Dipirona", "Anti inflamatorio", "Lote 991", DateTime.Now, forn);
            medicamento.AdicionarQuantidadeMedicamentos(100);
            new ControladorMedicamento().InserirNovo(medicamento);

            Paciente pacinte = new Paciente("Leonanrdo", "322 0000 0000 0000");
            new ControladorPaciente().InserirNovo(pacinte);

            Requisicao requisicao = new Requisicao(medicamento, pacinte, 10, DateTime.Now, funcionario);
            controlador.InserirNovo(requisicao);

            var requisicaoSelecionada = controlador.SelecionarPorId(requisicao._id);

            Assert.AreEqual(requisicaoSelecionada._id , requisicao._id);
            Assert.AreEqual(requisicaoSelecionada.QtdMedicamento, requisicao.QtdMedicamento);
            Assert.AreEqual(requisicaoSelecionada.Data.Date, requisicao.Data.Date);
            Assert.AreEqual(requisicaoSelecionada.Medicamento._id, requisicao.Medicamento._id);
            Assert.AreEqual(requisicaoSelecionada.Paciente._id, requisicao.Paciente._id);
            Assert.AreEqual(requisicaoSelecionada.Funcionario._id, requisicao.Funcionario._id);

        }
        [TestMethod]
        public void DeveEditarRequisicao()
        {
            
        }

        [TestMethod]
        public void DeveDeletarRequisicao()
        {

        }

        [TestMethod]
        public void DeveSelecionarVariosRequisicao()
        {

        }
    }
}
