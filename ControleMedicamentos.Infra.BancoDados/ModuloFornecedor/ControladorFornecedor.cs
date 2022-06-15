using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamentos.Infra.BancoDados.Shared;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.ModuloFornecedor
{
    public class ControladorFornecedor : Controlador<Fornecedor>
    {
        protected override string SqlUpdate =>
            @"UPDATE TBFornecedor
               SET Nome = @NOME
                  ,Telefone = @TELEFONE
                  ,Email = @EMAIL
                  ,Cidade = @CIDADE
                  ,Estado = @ESTADO
             WHERE Id = @ID";

        protected override string SqlDelete =>
                @"DELETE FROM TBFornecedor
                    WHERE id = @ID";

        protected override string SqlInsert => @"
                    INSERT INTO TBFORNECEDOR
                        ([NOME],
                        [EMAIL],
                        [TELEFONE],
                        [CIDADE],
                        [ESTADO])
                    VALUES
                (@NOME, @EMAIL, @TELEFONE, @CIDADE, @ESTADO);";

        protected override string SqlSelectAll =>
            @"SELECT [Id]
              ,[Nome]
              ,[Telefone]
              ,[Email]
              ,[Cidade]
              ,[Estado]
            FROM TBFornecedor";

        protected override string SqlSelectId =>
            @"SELECT [Id]
              ,[Nome]
              ,[Telefone]
              ,[Email]
              ,[Cidade]
              ,[Estado]
              FROM TBFornecedor
              where id = @ID";

        protected override string SqlExiste =>
                @"SELECT
                        COUNT(*)
                    FROM 
                        TBFornecedor
                    WHERE Id = @ID;";

        public override Fornecedor ConverterEmRegistro(IDataReader dataReader)
        {
            int id = Convert.ToInt32(dataReader[0]);
            string nome = Convert.ToString(dataReader[1]);
            string telefone = Convert.ToString(dataReader[2]);
            string email = Convert.ToString(dataReader[3]);            
            string cidade = Convert.ToString(dataReader[4]);
            string estado = Convert.ToString(dataReader[5]);

            Fornecedor fornecedor = new Fornecedor(nome,telefone,email,cidade,estado);
            fornecedor._id = id;

            return fornecedor;
        }

        public override AbstractValidator<Fornecedor> ObterValidador(Fornecedor item, List<Fornecedor> lista)
        {
            return new ValidadorFornecedor();
        }

        protected override Dictionary<string, object> ObtemParametrosRegistro(Fornecedor registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("EMAIL", registro.Email);
            parametros.Add("TELEFONE", registro.Telefone);
            parametros.Add("CIDADE", registro.Cidade);
            parametros.Add("ESTADO", registro.Estado);

            return parametros;
        }

        public override ValidationResult Excluir(int id)
        {
            return base.Excluir(id);
        }
        private ValidationResult ExcluirComReferencias(int id)
        {
            throw new NotImplementedException();
        }
    }
}
