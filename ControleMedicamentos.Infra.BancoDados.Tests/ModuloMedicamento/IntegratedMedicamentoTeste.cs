using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Infra.BancoDados.ModuloFornecedor;
using ControleMedicamentos.Infra.BancoDados.ModuloMedicamento;
using ControleMedicamentos.Infra.BancoDados.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ControleMedicamentos.Infra.BancoDados.Tests.ModuloMedicamento
{
    [TestClass]
    public class IntegratedMedicamentoTeste
    {
        public IntegratedMedicamentoTeste()
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
        public void DeveInserirMedicamento()
        {
            Fornecedor forn = new Fornecedor("leonardo", "48 88888-8989", "leonazinh@gmail.com", "MonteCastelo", "SC");
            new ControladorFornecedor().InserirNovo(forn);

            var controlador = new ControladorMedicamento();
            Medicamento medicamento = new Medicamento("Dipirona", "Anti inflamatorio", "Lote 991", DateTime.Now, forn);
            controlador.InserirNovo(medicamento);

            var medicamentoVerificado = controlador.SelecionarPorId(medicamento._id);

            Assert.AreEqual(medicamentoVerificado.Descricao , medicamento.Descricao);
            Assert.AreEqual(medicamentoVerificado.Lote, medicamento.Lote);
            Assert.AreEqual(medicamentoVerificado.Nome, medicamento.Nome);
            Assert.AreEqual(medicamentoVerificado.Validade.Date, medicamento.Validade.Date);
            Assert.AreEqual(medicamentoVerificado.QuantidadeDisponivel, medicamento.QuantidadeDisponivel);
            Assert.AreEqual(medicamentoVerificado.QuantidadeRequisicoes, medicamento.QuantidadeRequisicoes);
            Assert.AreEqual(medicamentoVerificado._id, medicamento._id);

            Assert.AreEqual(medicamentoVerificado.Fornecedor.Nome, medicamento.Fornecedor.Nome);
            Assert.AreEqual(medicamentoVerificado.Fornecedor.Telefone, medicamento.Fornecedor.Telefone);
            Assert.AreEqual(medicamentoVerificado.Fornecedor.Cidade, medicamento.Fornecedor.Cidade);
            Assert.AreEqual(medicamentoVerificado.Fornecedor.Email, medicamento.Fornecedor.Email);
            Assert.AreEqual(medicamentoVerificado.Fornecedor.Estado, medicamento.Fornecedor.Estado);
            Assert.AreEqual(medicamentoVerificado.Fornecedor._id, medicamento.Fornecedor._id);            
        }

        [TestMethod]
        public void DeveEditarMedicamento()
        {
            Fornecedor forn = new Fornecedor("leonardo", "48 88888-8989", "leonazinh@gmail.com", "MonteCastelo", "SC");
            new ControladorFornecedor().InserirNovo(forn);

            var controlador = new ControladorMedicamento();
            Medicamento medicamento = new Medicamento("Dipirona", "Anti inflamatorio", "Lote 991", DateTime.Now, forn);
            controlador.InserirNovo(medicamento);

            Fornecedor fornEditado = new Fornecedor("leonardo2", "48 88888-9999", "leonardo@gmail.com", "Monte Carlo", "RS");
            new ControladorFornecedor().InserirNovo(fornEditado);
            
            Medicamento medicamentoEditado = new Medicamento("Dipirona", "Anti inflamatorio", "Lote 991", DateTime.Now, fornEditado);

            controlador.Editar(medicamento._id,medicamentoEditado);

            var medicamentoVerificado = controlador.SelecionarPorId(medicamento._id);

            Assert.AreEqual(medicamentoVerificado.Descricao, medicamentoEditado.Descricao);
            Assert.AreEqual(medicamentoVerificado.Lote, medicamentoEditado.Lote);
            Assert.AreEqual(medicamentoVerificado.Nome, medicamentoEditado.Nome);
            Assert.AreEqual(medicamentoVerificado.Validade.Date, medicamentoEditado.Validade.Date);
            Assert.AreEqual(medicamentoVerificado.QuantidadeDisponivel, medicamentoEditado.QuantidadeDisponivel);
            Assert.AreEqual(medicamentoVerificado.QuantidadeRequisicoes, medicamentoEditado.QuantidadeRequisicoes);
            Assert.AreEqual(medicamentoVerificado._id, medicamentoEditado._id);

            Assert.AreEqual(medicamentoVerificado.Fornecedor.Nome, medicamentoEditado.Fornecedor.Nome);
            Assert.AreEqual(medicamentoVerificado.Fornecedor.Telefone, medicamentoEditado.Fornecedor.Telefone);
            Assert.AreEqual(medicamentoVerificado.Fornecedor.Cidade, medicamentoEditado.Fornecedor.Cidade);
            Assert.AreEqual(medicamentoVerificado.Fornecedor.Email, medicamentoEditado.Fornecedor.Email);
            Assert.AreEqual(medicamentoVerificado.Fornecedor.Estado, medicamentoEditado.Fornecedor.Estado);
            Assert.AreEqual(medicamentoVerificado.Fornecedor._id, medicamentoEditado.Fornecedor._id);
        }

        [TestMethod]
        public void DeveDeletarMedicamento()
        {
            Fornecedor forn = new Fornecedor("leonardo", "48 88888-8989", "leonazinh@gmail.com", "MonteCastelo", "SC");
            new ControladorFornecedor().InserirNovo(forn);

            var controlador = new ControladorMedicamento();
            Medicamento medicamento = new Medicamento("Dipirona", "Anti inflamatorio", "Lote 991", DateTime.Now, forn);
            controlador.InserirNovo(medicamento);

            controlador.Excluir(medicamento._id);

            var existeMedicamento = controlador.Existe(medicamento._id);

            Assert.AreEqual(false, existeMedicamento);
        }

        [TestMethod]
        public void DeveSelecionarVariosMedicamento()
        {
            Fornecedor forn = new Fornecedor("leonardo", "48 88888-8989", "leonazinh@gmail.com", "MonteCastelo", "SC");
            new ControladorFornecedor().InserirNovo(forn);

            var controlador = new ControladorMedicamento();

            Medicamento medicamento = new Medicamento("Dipirona", "Anti inflamatorio", "Lote 991", DateTime.Now, forn);
            controlador.InserirNovo(medicamento);

            Medicamento medicamento2 = new Medicamento("Dipirona", "Anti inflamatorio", "Lote 991", DateTime.Now, forn);
            controlador.InserirNovo(medicamento2);

            var lista = controlador.SelecionarTodos();

            Assert.AreEqual(2, lista.Count);
        }
    }
}
