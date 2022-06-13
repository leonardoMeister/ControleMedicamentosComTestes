using ControleMedicamentos.Dominio.ModuloFuncionario;
using ControleMedicamentos.Infra.BancoDados.ModuloFuncionario;
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
            var controlador = new ControladorFuncionario();

            Funcionario funcionario = new Funcionario("Leonardo", "LeonardoMargoti", "SenhaParaLeo");

            controlador.InserirNovo(funcionario);

            var verificadoFunc = controlador.SelecionarPorId(funcionario._id);

            Assert.AreEqual(verificadoFunc.Senha, funcionario.Senha);
            Assert.AreEqual(verificadoFunc.Nome, funcionario.Nome);
            Assert.AreEqual(verificadoFunc.Login, funcionario.Login);
            Assert.AreEqual(verificadoFunc._id, funcionario._id);

        }
        [TestMethod]
        public void DeveEditarFuncionario()
        {
            var controlador = new ControladorFuncionario();

            Funcionario funcionario = new Funcionario("Leonardo", "LeonardoMargoti", "SenhaParaLeo");

            controlador.InserirNovo(funcionario);

            Funcionario funcionarioEditado = new Funcionario("Leonardo2", "LeonardoMargoti2", "SenhaParaLeo2");
            controlador.Editar(funcionario._id, funcionarioEditado);

            var verificadoFunc = controlador.SelecionarPorId(funcionario._id);

            Assert.AreEqual(verificadoFunc.Senha, funcionarioEditado.Senha);
            Assert.AreEqual(verificadoFunc.Nome, funcionarioEditado.Nome);
            Assert.AreEqual(verificadoFunc.Login, funcionarioEditado.Login);

        }

        [TestMethod]
        public void DeveDeletarFuncionario()
        {
            var controlador = new ControladorFuncionario();

            Funcionario funcionario = new Funcionario("Leonardo", "LeonardoMargoti", "SenhaParaLeo");

            controlador.InserirNovo(funcionario);

            controlador.ExcluirComReferencias(funcionario._id); 

            var existeFuncionaro = controlador.Existe(funcionario._id);

            Assert.AreEqual(false, existeFuncionaro);

        }

        [TestMethod]
        public void DeveSelecionarVariosFuncionario()
        {
            var controlador = new ControladorFuncionario();

            Funcionario funcionario = new Funcionario("Leonardo", "LeonardoMargoti", "SenhaParaLeo");
            controlador.InserirNovo(funcionario);

            Funcionario funcionario2 = new Funcionario("Leonardo2", "LeonardoMargoti2", "SenhaParaLeo2");
            controlador.InserirNovo(funcionario2);

            var lista = controlador.SelecionarTodos();

            Assert.AreEqual(2, lista.Count);

        }
    }
}
