﻿using ControleMedicamentos.Dominio.ModuloFuncionario;
using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Dominio.ModuloPaciente;
using ControleMedicamentos.Dominio.ModuloRequisicao;
using ControleMedicamentos.Infra.BancoDados.ModuloFuncionario;
using ControleMedicamentos.Infra.BancoDados.ModuloMedicamento;
using ControleMedicamentos.Infra.BancoDados.ModuloPaciente;
using ControleMedicamentos.Infra.BancoDados.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.ModuloRequisicao
{
    public class ControladorRequisicao : Controlador<Requisicao>
    {
        protected override string SqlUpdate =>
                @"UPDATE TBRequisicao
                   SET [Funcionario_Id] = ''
                      ,[Paciente_Id] = ''
                      ,[Medicamento_Id] = ''
                      ,[QuantidadeMedicamento] = ''
                      ,[Data] = ''
                 WHERE Id = @ID";

        protected override string SqlDelete =>
                @"DELETE FROM TBRequisicao
                    WHERE Id = @ID";

        protected override string SqlInsert =>
                @"INSERT INTO TBRequisicao
                   (Funcionario_Id
                   ,Paciente_Id
                   ,Medicamento_Id
                   ,QuantidadeMedicamento
                   ,[Data])
                 VALUES
                       (@FKFUNCIONARIO, @FKPACIENTE, @FKMEDICAMENTO, @QUANTIDADE, @DATA)";
        protected override string SqlSelectAll =>
                @"SELECT [Id]
                      ,[Funcionario_Id]
                      ,[Paciente_Id]
                      ,[Medicamento_Id]
                      ,[QuantidadeMedicamento]
                      ,[Data]
                  FROM TBRequisicao";

        protected override string SqlSelectId =>
                @"SELECT [Id]
                      ,[Funcionario_Id]
                      ,[Paciente_Id]
                      ,[Medicamento_Id]
                      ,[QuantidadeMedicamento]
                      ,[Data]
                  FROM TBRequisicao
                  WHERE Id = @ID";

        protected override string SqlExiste =>
                @"SELECT
                        COUNT(*)
                    FROM 
                        TBRequisicao
                    WHERE Id = @ID;";

        protected override Dictionary<string, object> ObtemParametrosRegistro(Requisicao registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("FKFUNCIONARIO", registro.Funcionario._id);                                    
            parametros.Add("FKPACIENTE", registro.Paciente._id);
            parametros.Add("FKMEDICAMENTO", registro.Medicamento._id);
            parametros.Add("QUANTIDADE", registro.QtdMedicamento);
            parametros.Add("DATA", registro.Data);

            return parametros;
        }

        public override List<Requisicao> SelecionarTodos()
        {
            List<Requisicao> lista = base.SelecionarTodos();

            foreach (var item in lista)
            {
                AlimentarReferenciasDeRequisicao(item);
            }

            return lista;
        }
         
        private void AlimentarReferenciasDeRequisicao(Requisicao requisicao)
        {
            var controlF = new ControladorFuncionario();
            var controlP = new ControladorPaciente();
            var controlM = new ControladorMedicamento();

            requisicao.Funcionario = controlF.SelecionarPorId(requisicao.Funcionario._id);
            requisicao.Paciente = controlP.SelecionarPorId(requisicao.Paciente._id);

            requisicao.Medicamento = controlM.SelecionarPorId(requisicao.Medicamento._id);

        }

        public override Requisicao SelecionarPorId(int id)
        {
            Requisicao requisicao = base.SelecionarPorId(id);

            AlimentarReferenciasDeRequisicao(requisicao);

            return requisicao;
        }

        public override Requisicao ConverterEmRegistro(IDataReader dataReader)
        {
            int id = Convert.ToInt32(dataReader[0]);
            Funcionario func = new Funcionario(Convert.ToInt32(dataReader[1]));
            Paciente paci = new Paciente(Convert.ToInt32(dataReader[2]));
            Medicamento medi = new Medicamento(Convert.ToInt32(dataReader[3]));
            int quantidade = Convert.ToInt32(dataReader[4]);
            DateTime data = Convert.ToDateTime(dataReader[5]);

            var requisicao = new Requisicao(medi,paci,quantidade,data,func);
            requisicao._id = id;

            return requisicao;
        }
        public override AbstractValidator<Requisicao> ObterValidador(Requisicao item, List<Requisicao> lista)
        {
            return new ValidadorRequisicao();
        }

        internal List<Requisicao> SelecionarTodasRequisicoesApenasParaMedicamento(int id)
        {
            string query = @"SELECT [Id]
                      ,[Funcionario_Id]
                      ,[Paciente_Id]
                      ,[Medicamento_Id]
                      ,[QuantidadeMedicamento]
                      ,[Data]
                  FROM TBRequisicao
                  WHERE Medicamento_Id = @ID ;";

            List<Requisicao> lista = Db.GetAll(query,ConverterEmRegistro,AdicionarParametro("ID", id));

            var controlF = new ControladorFuncionario();
            var controlP = new ControladorPaciente();
            
            foreach(Requisicao requisicao in lista)
            {
                requisicao.Funcionario = controlF.SelecionarPorId(requisicao.Funcionario._id);
                requisicao.Paciente = controlP.SelecionarPorId(requisicao.Paciente._id);                
            }
            return lista;
        }
    }
}
