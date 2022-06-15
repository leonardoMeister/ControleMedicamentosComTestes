using ControleMedicamentos.Dominio.ModuloPaciente;
using ControleMedicamentos.Infra.BancoDados.Shared;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.ModuloPaciente
{
    public class ControladorPaciente : Controlador<Paciente>
    {
        protected override string SqlUpdate =>
                @"UPDATE TBPaciente
                   SET Nome = @NOME
                      ,CartaoSUS = @SUS
                 WHERE id = @ID";

        protected override string SqlDelete =>
                @"DELETE FROM TBPaciente
                  WHERE Id = @ID";

        protected override string SqlInsert =>
                @"INSERT INTO TBPaciente
                   (Nome,CartaoSUS)
                  VALUES (@NOME , @SUS);";

        protected override string SqlSelectAll =>
                @"SELECT Id , Nome, CartaoSUS
                  FROM TBPaciente";

        protected override string SqlSelectId =>
                @"SELECT Id , Nome, CartaoSUS
                  FROM TBPaciente
                  WHERE id = @ID";

        protected override string SqlExiste =>
                @"SELECT
                        COUNT(*)
                    FROM 
                        TBPaciente
                    WHERE Id = @ID ;";

        public override Paciente ConverterEmRegistro(IDataReader dataReader)
        {
            int id = Convert.ToInt32(dataReader[0]);
            string nome = Convert.ToString(dataReader[1]);
            string cartaoSUS = Convert.ToString(dataReader[2]);

            var funcionario = new Paciente(nome,cartaoSUS);
            funcionario._id = id;

            return funcionario;
        }

        public override AbstractValidator<Paciente> ObterValidador(Paciente item, List<Paciente> lista)
        {
            return new ValidadorPaciente();
        }

        protected override Dictionary<string, object> ObtemParametrosRegistro(Paciente registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("SUS", registro.CartaoSUS);            

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
