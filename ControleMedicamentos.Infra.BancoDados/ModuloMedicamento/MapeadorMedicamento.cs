using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Infra.BancoDados.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.ModuloMedicamento
{
    public class MapeadorMedicamento : MapeadorBase<Medicamento>
    {
        public override Medicamento ConverterEmRegistro(IDataReader dataReader)
        {
            int id = Convert.ToInt32(dataReader[0]);
            string nome = Convert.ToString(dataReader[1]);
            string descricao = Convert.ToString(dataReader[2]);
            string lote = Convert.ToString(dataReader[3]);
            DateTime validade = Convert.ToDateTime(dataReader[4]);
            int quantidade = Convert.ToInt32(dataReader[5]);
            Fornecedor forne = new Fornecedor(Convert.ToInt32(dataReader[6]));

            var medicamento = new Medicamento(nome, descricao, lote, validade, forne);
            medicamento.QuantidadeDisponivel = quantidade;
            medicamento._id = id;

            return medicamento;
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(Medicamento registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("DESCRICAO", registro.Descricao);
            parametros.Add("LOTE", registro.Lote);
            parametros.Add("VALIDADE", registro.Validade);
            parametros.Add("QUANTIDADE", registro.QuantidadeDisponivel);
            parametros.Add("FKFORNECEDOR", registro.Fornecedor._id);

            return parametros;
        }
    }
}
