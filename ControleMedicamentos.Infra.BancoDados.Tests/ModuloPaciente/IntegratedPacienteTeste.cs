using ControleMedicamentos.Infra.BancoDados.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.Tests.ModuloPaciente
{
    [TestClass]
    public class IntegratedPacienteTeste
    {
        public IntegratedPacienteTeste()
        {
            string sql =
               @"DELETE FROM TBPaciente;
                  DBCC CHECKIDENT (TBPaciente, RESEED, 0)";

            Db.ExecutarComando(sql);

        }

        [TestMethod]
        public void DeveInserirPaciente()
        {

        }
        [TestMethod]
        public void DeveVerificarExistenciaPaciente()
        {

        }
        [TestMethod]
        public void DeveEditarPaciente()
        {

        }

        [TestMethod]
        public void DeveDeletarPaciente()
        {

        }
        [TestMethod]
        public void DeveSelecionarIDPaciente()
        {

        }

        [TestMethod]
        public void DeveSelecionarVariosPaciente()
        {

        }
    }
}
