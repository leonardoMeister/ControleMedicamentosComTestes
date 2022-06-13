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

        }

        [TestMethod]
        public void DeveInserirRequisicao()
        {

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
