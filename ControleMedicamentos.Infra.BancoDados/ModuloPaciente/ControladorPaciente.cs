using ControleMedicamentos.Dominio.ModuloPaciente;
using ControleMedicamentos.Infra.BancoDados.Shared;
using FluentValidation;
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
        protected override string SqlUpdate => throw new NotImplementedException();

        protected override string SqlDelete => throw new NotImplementedException();

        protected override string SqlInsert => throw new NotImplementedException();

        protected override string SqlSelectAll => throw new NotImplementedException();

        protected override string SqlSelectId => throw new NotImplementedException();

        protected override string SqlExiste => throw new NotImplementedException();

        public override Paciente ConverterEmRegistro(IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public override AbstractValidator<Paciente> ObterValidador(Paciente item, List<Paciente> lista)
        {
            throw new NotImplementedException();
        }

        protected override Dictionary<string, object> ObtemParametrosRegistro(Paciente registro)
        {
            throw new NotImplementedException();
        }
    }
}
