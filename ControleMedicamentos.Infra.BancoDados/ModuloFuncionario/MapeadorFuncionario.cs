using ControleMedicamentos.Dominio.ModuloFuncionario;
using ControleMedicamentos.Infra.BancoDados.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.ModuloFuncionario
{
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override Dictionary<string, object> ObtemParametrosRegistro(Funcionario registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("LOGIN", registro.Login);
            parametros.Add("SENHA", registro.Senha);

            return parametros;
        }

        public override Funcionario ConverterEmRegistro(IDataReader dataReader)
        {
            int id = Convert.ToInt32(dataReader[0]);
            string nome = Convert.ToString(dataReader[1]);
            string login = Convert.ToString(dataReader[2]);
            string senha = Convert.ToString(dataReader[3]);

            var funcionario = new Funcionario(nome, login, senha);
            funcionario._id = id;

            return funcionario;
        }
    }
}
