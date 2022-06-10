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

        }
        [TestMethod]
        public void DeveVerificarExistenciaFornecedor()
        {

        }
        [TestMethod]
        public void DeveEditarFornecedor()
        {

        }

        [TestMethod]
        public void DeveDeletarFornecedor()
        {

        }
        [TestMethod]
        public void DeveSelecionarIDFornecedor()
        {

        } 

        [TestMethod]
        public void DeveSelecionarVariosFornecedor()
        {

        }
    }
}
