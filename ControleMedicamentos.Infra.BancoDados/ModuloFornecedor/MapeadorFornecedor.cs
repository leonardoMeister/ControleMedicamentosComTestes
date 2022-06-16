using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamentos.Infra.BancoDados.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.ModuloFornecedor
{
    public class MapeadorFornecedor : MapeadorBase<Fornecedor>
    {
        public override Dictionary<string, object> ObtemParametrosRegistro(Fornecedor registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("EMAIL", registro.Email);
            parametros.Add("TELEFONE", registro.Telefone);
            parametros.Add("CIDADE", registro.Cidade);
            parametros.Add("ESTADO", registro.Estado);

            return parametros;
        }

        public override Fornecedor ConverterEmRegistro(IDataReader dataReader)
        {
            int id = Convert.ToInt32(dataReader[0]);
            string nome = Convert.ToString(dataReader[1]);
            string telefone = Convert.ToString(dataReader[2]);
            string email = Convert.ToString(dataReader[3]);
            string cidade = Convert.ToString(dataReader[4]);
            string estado = Convert.ToString(dataReader[5]);

            Fornecedor fornecedor = new Fornecedor(nome, telefone, email, cidade, estado);
            fornecedor._id = id;

            return fornecedor;
        }
    }
}
