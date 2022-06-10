using ControleMedicamentos.Infra.BancoDados.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.Tests.ModuloFuncionario
{
    [TestClass]
    public class IntegratedFuncionarioTeste
    {
        public IntegratedFuncionarioTeste()
        {
            string sql =
                @"DELETE FROM TBFuncionario;
                  DBCC CHECKIDENT (TBFuncionario, RESEED, 0)";

            Db.ExecutarComando(sql);
        }

        [TestMethod]
        public void DeveInserirFuncionario()
        {

        }
        [TestMethod]
        public void DeveVerificarExistenciaFuncionario()
        {

        }
        [TestMethod]
        public void DeveEditarFuncionario()
        {

        }

        [TestMethod]
        public void DeveDeletarFuncionario()
        {

        }
        [TestMethod]
        public void DeveSelecionarIDFuncionario()
        {

        }

        [TestMethod]
        public void DeveSelecionarVariosFuncionario()
        {

        }
    }
}
