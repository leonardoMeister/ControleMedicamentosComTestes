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
    public class ControladorMedicamento : Controlador<Medicamento,ValidadorMedicamento, MapeadorMedicamento>
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
    }
}
