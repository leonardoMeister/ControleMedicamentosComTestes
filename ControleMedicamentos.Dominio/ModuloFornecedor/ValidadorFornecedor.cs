using ControleMedicamentos.Dominio.Compartilhado;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.ModuloFornecedor
{
    public class ValidadorFornecedor : AbstractValidator<Fornecedor>
    {

        public ValidadorFornecedor()
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

            RuleFor(x => x.Nome)
                .Must(x => x.Length < 20)
                .WithMessage("Nome não pode ser maior que 20");

            RuleFor(x => x.Nome)
                .Must(x => x.Length > 3)
                .WithMessage("Nome não pode ser menor que 3");

            RuleFor(x => x.Cidade)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Estado)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Email)
                .Custom(VerificarEmail);

            RuleFor(x => x.Telefone)
                .Custom(VerificarTelefone);

        }
         
        private void VerificarTelefone(string telefone, ValidationContext<Fornecedor> validation)
        {            
            if (!telefone.TelefoneValido()) validation.AddFailure( new ValidationFailure("Telefone", "Telefone Inválido"));
        }

        private void VerificarEmail(string email, ValidationContext<Fornecedor> validation)
        {
            if (!email.EmailValido()) validation.AddFailure( new ValidationFailure("Email", "Email Inválido"));
        }
    }
}
