using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.Compartilhado
{
    public static class ExtensioMethods
    {
        private const string telefone = @"^\(?([0-9]{2})\)?[-. ]?([0-9]{5})[-. ]?([0-9]{4})$";


        private const string SUS = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})[-. ]?([0-9]{4})$";

        public static bool TelefoneValido(this string telefone)
        {
            if (telefone != null) return Regex.IsMatch(telefone, ExtensioMethods.telefone);
            else return false;
        }
        public static bool SusValido(this string sus)
        {
            if (sus != null) return Regex.IsMatch(sus, ExtensioMethods.SUS);
            else return false;
        }
        public static bool EmailValido(this string email)
        {
            if (new EmailAddressAttribute().IsValid(email)) return true;

            return false;
        }

    }
}
