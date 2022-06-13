using ControleMedicamentos.Dominio.ModuloRequisicao;
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
        protected override string SqlUpdate => throw new NotImplementedException();

        protected override string SqlDelete => throw new NotImplementedException();

        protected override string SqlInsert => throw new NotImplementedException();

        protected override string SqlSelectAll => throw new NotImplementedException();

        protected override string SqlSelectId => throw new NotImplementedException();

        protected override string SqlExiste => throw new NotImplementedException();

        public override List<Requisicao> SelecionarTodos()
        {
            return base.SelecionarTodos();
        }

        public override Requisicao SelecionarPorId(int id)
        {
            return base.SelecionarPorId(id);
        }

        public override Requisicao ConverterEmRegistro(IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public override AbstractValidator<Requisicao> ObterValidador(Requisicao item, List<Requisicao> lista)
        {
            throw new NotImplementedException();
        }

        protected override Dictionary<string, object> ObtemParametrosRegistro(Requisicao registro)
        {
            throw new NotImplementedException();
        }
    }
}
