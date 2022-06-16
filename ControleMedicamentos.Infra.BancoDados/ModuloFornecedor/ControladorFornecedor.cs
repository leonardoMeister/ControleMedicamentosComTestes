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
    public class ControladorFornecedor : Controlador<Fornecedor , ValidadorFornecedor, MapeadorFornecedor>
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

    }
}
