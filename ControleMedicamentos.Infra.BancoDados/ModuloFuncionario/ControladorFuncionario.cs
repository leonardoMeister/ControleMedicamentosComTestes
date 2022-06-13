using ControleMedicamentos.Dominio.ModuloFuncionario;
using ControleMedicamentos.Infra.BancoDados.Shared;
using FluentValidation;
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
        protected override string SqlUpdate => throw new NotImplementedException();

        protected override string SqlDelete => throw new NotImplementedException();

        protected override string SqlInsert => throw new NotImplementedException();

        protected override string SqlSelectAll => throw new NotImplementedException();

        protected override string SqlSelectId => throw new NotImplementedException();

        protected override string SqlExiste => throw new NotImplementedException();

        public override Funcionario ConverterEmRegistro(IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public override AbstractValidator<Funcionario> ObterValidador(Funcionario item, List<Funcionario> lista)
        {
            throw new NotImplementedException();
        }

        protected override Dictionary<string, object> ObtemParametrosRegistro(Funcionario registro)
        {
            throw new NotImplementedException();
        }

        public void ExcluirComReferencias(int id)
        {
            throw new NotImplementedException();
        }
    }
}
