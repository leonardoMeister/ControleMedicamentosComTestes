using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

            RuleFor(x => x.Senha)
                .Must(x => x.Length < 20)
                .WithMessage("Senha não pode ser maior que 20");

            RuleFor(x => x.Senha)
                .Must(x => x.Length > 3)
                .WithMessage("Senha não pode ser menor que 3");

            RuleFor(x => x.Nome)
                 .Must(x => x.Length < 20)
                 .WithMessage("Nome não pode ser maior que 20");

            RuleFor(x => x.Nome)
                .Must(x => x.Length > 3)
                .WithMessage("Nome não pode ser menor que 3");

            RuleFor(x => x.Login)
                .NotNull()
                .NotEmpty();

        }
    }
}
