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
    public class ControladorFuncionario : Controlador<Funcionario>
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

        public override Funcionario ConverterEmRegistro(IDataReader dataReader)
        {
            int id = Convert.ToInt32(dataReader[0]);
            string nome = Convert.ToString(dataReader[1]);
            string login = Convert.ToString(dataReader[2]);
            string senha = Convert.ToString(dataReader[3]);

            var funcionario = new Funcionario(nome,login,senha);
            funcionario._id = id;

            return funcionario;
        }

        public override AbstractValidator<Funcionario> ObterValidador(Funcionario item, List<Funcionario> lista)
        {
            return new ValidadorFuncionario();
        }

        protected override Dictionary<string, object> ObtemParametrosRegistro(Funcionario registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("LOGIN", registro.Login);
            parametros.Add("SENHA", registro.Senha);

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
