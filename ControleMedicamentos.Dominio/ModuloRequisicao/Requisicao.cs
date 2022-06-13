using ControleMedicamentos.Dominio.ModuloFuncionario;
using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Dominio.ModuloPaciente;
using System;
using System.Collections.Generic;

namespace ControleMedicamentos.Dominio.ModuloRequisicao
{
    public class Requisicao : EntidadeBase
    {

        private Medicamento medicamento;
        private Paciente paciente;
        private int qtdMedicamento;
        private DateTime data;
        private Funcionario funcionario;

        public Medicamento Medicamento { get => medicamento; set => medicamento = value; }
        public Paciente Paciente { get => paciente; set => paciente = value; }
        public int QtdMedicamento { get => qtdMedicamento; set => qtdMedicamento = value; }
        public DateTime Data { get => data; set => data = value; }
        public Funcionario Funcionario { get => funcionario; set => funcionario = value; }

        public Requisicao(Medicamento medicamento, Paciente paciente, int qtdMedicamento, DateTime data, Funcionario funcionario)
        {
            Medicamento = medicamento;
            Paciente = paciente;
            QtdMedicamento = qtdMedicamento;
            Data = data;
            Funcionario = funcionario;
        }

        public override string ToString()
        {
            return $"";
        }
    }
}
