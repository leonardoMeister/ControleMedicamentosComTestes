using ControleMedicamentos.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.Shared
{
    public abstract class MapeadorBase<T> where T : EntidadeBase
    {
        public abstract Dictionary<string, object> ObtemParametrosRegistro(T registro);

        public abstract T ConverterEmRegistro(IDataReader dataReader);

        public Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}
