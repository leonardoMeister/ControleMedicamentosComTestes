using ControleMedicamentos.Dominio.ModuloFuncionario;
using ControleMedicamentos.Infra.BancoDados.Shared;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.ModuloFuncionario
{
    public class ControladorFuncionario : Controlador<Funcionario, ValidadorFuncionario, MapeadorFuncionario>
    {
        protected override string SqlUpdate =>
            @"UPDATE TBFUNCIONARIO	
                SET
	                [NOME] = @NOME,
	                [LOGIN] = @LOGIN,
	                [SENHA] = @SENHA
                WHERE
	                [ID] = @ID;";

        protected override string SqlDelete =>
             @"DELETE FROM[TBFUNCIONARIO]
                WHERE
                    [ID] = @ID";

        protected override string SqlInsert => 
            @"INSERT INTO TBFUNCIONARIO 
                ([NOME], [LOGIN], [SENHA])
	            VALUES
                ( @NOME, @LOGIN, @SENHA);";

        protected override string SqlSelectAll =>
             @"SELECT 
	                FUNCIONARIO.ID,
	                FUNCIONARIO.NOME,
	                FUNCIONARIO.LOGIN,
	                FUNCIONARIO.SENHA
                FROM TBFUNCIONARIO AS FUNCIONARIO;";

        protected override string SqlSelectId =>
            @"SELECT 
	                FUNCIONARIO.ID,
	                FUNCIONARIO.NOME,
	                FUNCIONARIO.LOGIN,
	                FUNCIONARIO.SENHA
                FROM TBFUNCIONARIO AS FUNCIONARIO
                WHERE ID = @ID";

        protected override string SqlExiste =>
                @"SELECT
                        COUNT(*)
                    FROM 
                        TBFuncionario
                    WHERE Id = @ID;";

    }
}
