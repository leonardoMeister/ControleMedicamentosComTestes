using ControleMedicamentos.Infra.BancoDados.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.Tests.ModuloMedicamento
{
    [TestClass]
    public class IntegratedMedicamentoTeste
    {
        public IntegratedMedicamentoTeste()
        {
            string sql =
                @"DELETE FROM TBMedicamento;
                  DBCC CHECKIDENT (TBMedicamento, RESEED, 0)";

            Db.ExecutarComando(sql);

        }

        [TestMethod]
        public void DeveInserirMedicamento()
        {

        }
        [TestMethod]
        public void DeveVerificarExistenciaMedicamento()
        {

        }
        [TestMethod]
        public void DeveEditarMedicamento()
        {

        }

        [TestMethod]
        public void DeveDeletarMedicamento()
        {

        }
        [TestMethod]
        public void DeveSelecionarIDMedicamento()
        {

        }

        [TestMethod]
        public void DeveSelecionarVariosMedicamento()
        {

        }
    }
}
