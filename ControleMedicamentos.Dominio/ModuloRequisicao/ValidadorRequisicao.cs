using ControleMedicamentos.Dominio.ModuloFuncionario;
using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Dominio.ModuloPaciente;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.ModuloRequisicao
{
    public class ValidadorRequisicao : AbstractValidator<Requisicao>
    {


        public ValidadorRequisicao()
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

            RuleFor(x => x.QtdMedicamento)
                .NotNull();

            RuleFor(x => x.Paciente)
                .NotEmpty()
                .NotNull();            
            RuleFor(x => x.Medicamento)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Data)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Funcionario)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Paciente)
                .Custom(ValidarPaciente);
            RuleFor(x => x.Medicamento)
                .Custom(ValidarMedicamento);
            RuleFor(x => x.Funcionario)
                .Custom(ValidarFuncionario);
        }

        private void ValidarFuncionario(Funcionario funcionario, ValidationContext<Requisicao> validador)
        {
            ValidadorFuncionario val = new ValidadorFuncionario();

            var result = val.Validate(funcionario);

            if (!result.IsValid) validador.AddFailure(new ValidationFailure("Funcionario", "Funcionario deve ser valido"));
        }

        private void ValidarMedicamento(Medicamento medicamento, ValidationContext<Requisicao> validador)
        {
            ValidadorMedicamento val = new ValidadorMedicamento();

            var result = val.Validate(medicamento);

            if (!result.IsValid) validador.AddFailure(new ValidationFailure("Medicamento", "Medicamento deve ser valido"));
        }

        private void ValidarPaciente(Paciente paciente, ValidationContext<Requisicao> validador)
        {
            ValidadorPaciente val = new ValidadorPaciente();

            var result = val.Validate(paciente);

            if (!result.IsValid) validador.AddFailure(new ValidationFailure("Paciente", "Paciente deve ser valido"));
        }
    }
}
