using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamentos.Infra.BancoDados.ModuloFornecedor;
using ControleMedicamentos.Infra.BancoDados.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleMedicamentos.Infra.BancoDados.Tests.ModuloFornecedor
{
    [TestClass]
    public class IntegratedFornecedorTeste
    {
        public IntegratedFornecedorTeste()
        {
            string sql =
                @"DELETE FROM TBFornecedor;
                  DBCC CHECKIDENT (TBFornecedor, RESEED, 0)";

            Db.ExecutarComando(sql);
        }

        [TestMethod]
        public void DeveInserirFornecedor()
        {
            Fornecedor forne = new Fornecedor("leonardo", "22 99939-8644", "leozinhomm1@gmail.com", "Monte Castelo", "SC");

            var controlador = new ControladorFornecedor();

            controlador.InserirNovo(forne);

            var verificadoForne = controlador.SelecionarPorId(forne._id);

            Assert.AreEqual(forne.Cidade, verificadoForne.Cidade);
            Assert.AreEqual(forne.Nome, verificadoForne.Nome);
            Assert.AreEqual(forne.Telefone, verificadoForne.Telefone);
            Assert.AreEqual(forne.Email, verificadoForne.Email);
            Assert.AreEqual(forne.Estado, verificadoForne.Estado);
            Assert.AreEqual(forne._id, verificadoForne._id);
        }

        [TestMethod]
        public void DeveEditarFornecedor()
        {
            Fornecedor forne = new Fornecedor("leonardo", "22 99939-8644", "leozinhomm1@gmail.com", "Monte Castelo", "SC");

            var controlador = new ControladorFornecedor();

            controlador.InserirNovo(forne);

            Fornecedor forneEditado = new Fornecedor("leonardo2", "22 99939-9999", "leonardomm1@gmail.com", "Monte Carlo", "RS");
            controlador.Editar(forne._id, forneEditado);

            var verificadoForne = controlador.SelecionarPorId(forne._id);

            Assert.AreEqual(forneEditado.Cidade, verificadoForne.Cidade);
            Assert.AreEqual(forneEditado.Nome, verificadoForne.Nome);
            Assert.AreEqual(forneEditado.Telefone, verificadoForne.Telefone);
            Assert.AreEqual(forneEditado.Email, verificadoForne.Email);
            Assert.AreEqual(forneEditado.Estado, verificadoForne.Estado);
        }

        [TestMethod]
        public void DeveDeletarFornecedor()
        {
            Fornecedor forne = new Fornecedor("leonardo", "22 99939-8644", "leozinhomm1@gmail.com", "Monte Castelo", "SC");

            var controlador = new ControladorFornecedor();

            controlador.InserirNovo(forne);

            controlador.ExcluirComReferencias(forne._id);

            var existeFornecedor = controlador.Existe(forne._id);

            Assert.AreEqual(false, existeFornecedor);
        }

        [TestMethod]
        public void DeveSelecionarVariosFornecedor()
        {
            Fornecedor forne = new Fornecedor("leonardo", "22 99939-8644", "leozinhomm1@gmail.com", "Monte Castelo", "SC");
            Fornecedor forne2 = new Fornecedor("leonardo2", "22 99939-9999", "leonardomm1@gmail.com", "Monte Carlo", "RS");

            var controlador = new ControladorFornecedor();

            controlador.InserirNovo(forne);
            controlador.InserirNovo(forne2);

            var lista = controlador.SelecionarTodos();

            Assert.AreEqual(2, lista.Count);

        }
    }
}
