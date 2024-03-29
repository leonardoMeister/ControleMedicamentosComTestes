﻿using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamentos.Dominio.ModuloRequisicao;
using System;
using System.Collections.Generic;

namespace ControleMedicamentos.Dominio.ModuloMedicamento
{
    public class Medicamento : EntidadeBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Lote { get; set; }
        public DateTime Validade { get; set; }
        public int QuantidadeDisponivel { get; set; }

        public List<Requisicao> Requisicoes { get; set; }

        public Fornecedor Fornecedor { get; set; }

        public int QuantidadeRequisicoes { get { return Requisicoes.Count; } }

        public Medicamento(int id)
        {
            this._id = id;
        }
        public Medicamento(string nome, string descricao, string lote, DateTime validade, Fornecedor forn)
        {
            Nome = nome;
            Descricao = descricao;
            Lote = lote;
            Validade = validade;
            this.Fornecedor = forn;
            QuantidadeDisponivel = 0;
            Requisicoes = new List<Requisicao>();
        }

        public bool AdicionarRequisicao(Requisicao req)
        {

            QuantidadeDisponivel -= req.QtdMedicamento;
            Requisicoes.Add(req);

            return true;
        }
        public void AdicionarQuantidadeMedicamentos(int quantidade)
        {
            QuantidadeDisponivel += quantidade;
        }

    }
}
