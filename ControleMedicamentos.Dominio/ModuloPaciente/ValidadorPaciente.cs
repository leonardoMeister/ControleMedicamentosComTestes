using ControleMedicamentos.Dominio.Compartilhado;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.ModuloPaciente
{
    public class ValidadorPaciente : AbstractValidator<Paciente>
    {
        public ValidadorPaciente()
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");        

            RuleFor(x => x.Nome)
                .Must(x => x.Length < 20)
                .WithMessage("Nome não pode ser maior que 20");

            RuleFor(x => x.Nome)
                .Must(x => x.Length > 3)
                .WithMessage("Nome não pode ser menor que 3");

            RuleFor(x => x.CartaoSUS)
                .Custom(ValidarSUS);

        }

        private void ValidarSUS(string sus, ValidationContext<Paciente> validador)
        {

            if (!sus.SusValido()) validador.AddFailure(new ValidationFailure("Sus", "Sus Invalido"));

        }
    }
}
