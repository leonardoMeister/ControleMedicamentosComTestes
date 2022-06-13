using ControleMedicamentos.Dominio.ModuloFornecedor;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.ModuloMedicamento
{
    public class ValidadorMedicamento : AbstractValidator<Medicamento>
    {
        public ValidadorMedicamento()
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

            RuleFor(x => x.Requisicoes)
                .NotNull();

            RuleFor(x => x.Descricao)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Fornecedor)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Lote)
                .NotNull().NotEmpty();

            RuleFor(x => x.Nome)
               .Must(x => x.Length < 20)
               .WithMessage("Nome não pode ser maior que 20");

            RuleFor(x => x.Nome)
                .Must(x => x.Length > 3)
                .WithMessage("Nome não pode ser menor que 3");
            RuleFor(x => x.Fornecedor)
                .Custom(ValidarFornecedor);

        }

        private void ValidarFornecedor(Fornecedor fornecedor, ValidationContext<Medicamento> validador)
        {
            ValidadorFornecedor val = new ValidadorFornecedor();
            ValidationResult result;
            if (fornecedor != null)
            {
                result = val.Validate(fornecedor);
                if (!result.IsValid) validador.AddFailure(new ValidationFailure("Fornecedor", "Fornecedor deve ser valido"));
            }

        }
    }
}
