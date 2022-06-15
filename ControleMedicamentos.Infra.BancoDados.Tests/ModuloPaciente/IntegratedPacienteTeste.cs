using ControleMedicamentos.Dominio.ModuloPaciente;
using ControleMedicamentos.Infra.BancoDados.ModuloPaciente;
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
        public void DeveInserirSelecionarPaciente() 
        {
            var controlador = new ControladorPaciente();

            Paciente paciente = new Paciente("Leonardo","000-0000-0000-0000");

            controlador.InserirNovo(paciente);

            var pasVerificado = controlador.SelecionarPorId(paciente._id);


            Assert.AreEqual(paciente._id, pasVerificado._id);
            Assert.AreEqual(paciente.CartaoSUS, pasVerificado.CartaoSUS);
            Assert.AreEqual(paciente.Nome, pasVerificado.Nome);


        }  

        [TestMethod]
        public void DeveEditarPaciente()
        {
            var controlador = new ControladorPaciente();

            Paciente paciente = new Paciente("Leonardo", "000-0000-0000-0000");

            controlador.InserirNovo(paciente);

            Paciente novoPaciente = new Paciente("Pedro", "111-2223-3333-3333");

            controlador.Editar(paciente._id, novoPaciente);


            var pasVerificado = controlador.SelecionarPorId(paciente._id);

            Assert.AreEqual(novoPaciente.CartaoSUS, pasVerificado.CartaoSUS);
            Assert.AreEqual(novoPaciente.Nome, pasVerificado.Nome);

        }

        [TestMethod]
        public void DeveDeletarPaciente()
        {
            var controlador = new ControladorPaciente();

            Paciente paciente = new Paciente("Leonardo", "000-0000-0000-0000");

            controlador.InserirNovo(paciente);

            controlador.Excluir(paciente._id); 

            var existePaciente = controlador.Existe(paciente._id);

            Assert.AreEqual(false, existePaciente);

        }       

        [TestMethod]
        public void DeveSelecionarVariosPaciente()
        {
            var controlador = new ControladorPaciente();

            Paciente paciente = new Paciente("Leonardo", "000-0000-0000-0000");
            Paciente paciente2 = new Paciente("Leonardo2", "111-1111-1111-1111");

            controlador.InserirNovo(paciente);
            controlador.InserirNovo(paciente2);

            var lista = controlador.SelecionarTodos();

            Assert.AreEqual(2,lista.Count);
        }
    }
}
