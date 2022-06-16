using ControleMedicamentos.Dominio.ModuloFuncionario;
using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Dominio.ModuloPaciente;
using ControleMedicamentos.Dominio.ModuloRequisicao;
using ControleMedicamentos.Infra.BancoDados.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.ModuloRequisicao
{
    public class MapeadorRequisicao : MapeadorBase<Requisicao>
    {
        public override Requisicao ConverterEmRegistro(IDataReader dataReader)
        {
            int id = Convert.ToInt32(dataReader[0]);
            Funcionario func = new Funcionario(Convert.ToInt32(dataReader[1]));
            Paciente paci = new Paciente(Convert.ToInt32(dataReader[2]));
            Medicamento medi = new Medicamento(Convert.ToInt32(dataReader[3]));
            int quantidade = Convert.ToInt32(dataReader[4]);
            DateTime data = Convert.ToDateTime(dataReader[5]);

            var requisicao = new Requisicao(medi, paci, quantidade, data, func);
            requisicao._id = id;

            return requisicao;
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(Requisicao registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("FKFUNCIONARIO", registro.Funcionario._id);
            parametros.Add("FKPACIENTE", registro.Paciente._id);
            parametros.Add("FKMEDICAMENTO", registro.Medicamento._id);
            parametros.Add("QUANTIDADE", registro.QtdMedicamento);
            parametros.Add("DATA", registro.Data);

            return parametros;
        }
    }
}
