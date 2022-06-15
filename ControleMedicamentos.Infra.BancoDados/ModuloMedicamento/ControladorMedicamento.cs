using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Dominio.ModuloRequisicao;
using ControleMedicamentos.Infra.BancoDados.ModuloFornecedor;
using ControleMedicamentos.Infra.BancoDados.ModuloRequisicao;
using ControleMedicamentos.Infra.BancoDados.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.ModuloMedicamento
{
    public class ControladorMedicamento : Controlador<Medicamento>
    {
        protected override string SqlUpdate =>
                @"UPDATE TBMedicamento
                   SET [Nome] = @NOME
                      ,[Descricao] = @DESCRICAO
                      ,[Lote] = @LOTE
                      ,[Validade] = @VALIDADE
                      ,[QuantidadeDisponivel] =  @QUANTIDADE
                      ,[Forncedor_Id] = @FKFORNECEDOR
                 WHERE ID = @ID";
        protected override string SqlDelete =>
             @"DELETE FROM TBMedicamento
                    WHERE id = @ID";
        protected override string SqlInsert =>
                @"INSERT INTO TBMedicamento
                   (Nome
                   ,Descricao
                   ,Lote
                   ,Validade
                   ,QuantidadeDisponivel
                   ,Forncedor_Id)
                  VALUES
                   (@NOME, @DESCRICAO, @LOTE, @VALIDADE, @QUANTIDADE, @FKFORNECEDOR)";               
        protected override string SqlSelectAll =>
                @"SELECT [Id]
                  ,[Nome]
                  ,[Descricao]
                  ,[Lote]
                  ,[Validade]
                  ,[QuantidadeDisponivel]
                  ,[Forncedor_Id]
                FROM TBMedicamento";
        protected override string SqlSelectId =>
                @"SELECT [Id]
                  ,[Nome]
                  ,[Descricao]
                  ,[Lote]
                  ,[Validade]
                  ,[QuantidadeDisponivel]
                  ,[Forncedor_Id]
              FROM TBMedicamento
                WHERE Id = @ID";
        protected override string SqlExiste =>
             @"SELECT
                        COUNT(*)
                    FROM 
                        TBMedicamento
                    WHERE Id = @ID ;";

        protected override Dictionary<string, object> ObtemParametrosRegistro(Medicamento registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("DESCRICAO", registro.Descricao);
            parametros.Add("LOTE", registro.Lote);
            parametros.Add("VALIDADE", registro.Validade);
            parametros.Add("QUANTIDADE", registro.QuantidadeDisponivel);
            parametros.Add("FKFORNECEDOR", registro.Fornecedor._id);

            return parametros;
        }

        public override Medicamento SelecionarPorId(int id)
        {
            Medicamento medicamento = base.SelecionarPorId(id);

            AlimentarReferenciasMedicamento(medicamento);
            return medicamento;
        }

        private void AlimentarReferenciasMedicamento(Medicamento medicamento)
        {
            var controlF = new ControladorFornecedor();
            var controlR = new ControladorRequisicao();

            Fornecedor fornecedor = controlF.SelecionarPorId(medicamento.Fornecedor._id);
            
            List<Requisicao> listaR = controlR.SelecionarTodasRequisicoesApenasParaMedicamento(medicamento._id);

            foreach(Requisicao requisicao in listaR)
            {
                requisicao.Medicamento = medicamento;
            }

            medicamento.Fornecedor = fornecedor;
            medicamento.Requisicoes = listaR;

        }

        public override List<Medicamento> SelecionarTodos()
        {
            List<Medicamento> lista = base.SelecionarTodos();

            foreach(Medicamento medicamento in lista)
            {
                AlimentarReferenciasMedicamento(medicamento);
            }

            return lista;
        }

        public override Medicamento ConverterEmRegistro(IDataReader dataReader)
        {
            int id = Convert.ToInt32(dataReader[0]);
            string nome = Convert.ToString(dataReader[1]);
            string descricao = Convert.ToString(dataReader[2]);
            string lote = Convert.ToString(dataReader[3]);
            DateTime validade = Convert.ToDateTime(dataReader[4]);
            int quantidade = Convert.ToInt32(dataReader[5]);
            Fornecedor forne = new Fornecedor(Convert.ToInt32(dataReader[6]));
                       
            var medicamento = new Medicamento(nome,descricao,lote,validade,forne);
            medicamento.QuantidadeDisponivel = quantidade;
            medicamento._id = id;

            return medicamento;
        }

        public override AbstractValidator<Medicamento> ObterValidador(Medicamento item, List<Medicamento> lista)
        {
            return new ValidadorMedicamento();
        }

      
    }
}
