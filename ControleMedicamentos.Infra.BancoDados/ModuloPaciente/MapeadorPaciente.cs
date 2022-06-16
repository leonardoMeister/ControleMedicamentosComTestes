using ControleMedicamentos.Dominio.ModuloPaciente;
using ControleMedicamentos.Infra.BancoDados.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.ModuloPaciente
{
    public class MapeadorPaciente : MapeadorBase<Paciente>
    {
        public override Paciente ConverterEmRegistro(IDataReader dataReader)
        {
            int id = Convert.ToInt32(dataReader[0]);
            string nome = Convert.ToString(dataReader[1]);
            string cartaoSUS = Convert.ToString(dataReader[2]);

            var funcionario = new Paciente(nome, cartaoSUS);
            funcionario._id = id;

            return funcionario;
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(Paciente registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("SUS", registro.CartaoSUS);

            return parametros;
        }
    }
}
