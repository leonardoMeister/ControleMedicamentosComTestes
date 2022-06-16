using FluentValidation;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;
using ControleMedicamentos.Dominio;
using System.Data;

namespace ControleMedicamentos.Infra.BancoDados.Shared
{
    public abstract class Controlador<T,  TValidador, TMapeador> 
        where T : EntidadeBase
        where TValidador : AbstractValidator<T>,new()
        where TMapeador : MapeadorBase<T>, new()        
    {
        protected abstract string SqlUpdate { get; }
        protected abstract string SqlDelete { get; }
        protected abstract string SqlInsert { get; }
        protected abstract string SqlSelectAll { get; }
        protected abstract string SqlSelectId { get; }
        protected abstract string SqlExiste { get; }

        public virtual ValidationResult InserirNovo(T registro)
        {

            var resultadoValidacao = new TValidador().Validate(registro);

            if (resultadoValidacao.IsValid)
            {
                int id = Db.Insert(SqlInsert, new TMapeador().ObtemParametrosRegistro(registro));
                registro._id = id;
            }
            return resultadoValidacao;
        }
        public virtual ValidationResult Editar(int id, T registro)
        {
            var resultadoValidacao = new TValidador().Validate(registro);

            if (resultadoValidacao.IsValid)
            {
                registro._id = id;
                Db.Update(SqlUpdate, new TMapeador().ObtemParametrosRegistro(registro));
            }
            return resultadoValidacao;
        }
        public virtual bool Existe(int id)
        {
            return Db.Exists(SqlExiste, new TMapeador().AdicionarParametro("ID", id));
        }
        public virtual ValidationResult Excluir(int id)
        {
            var resultadoValidacao = new ValidationResult();
            try
            {
                Db.Delete(SqlDelete, new TMapeador().AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));
                return resultadoValidacao;
            }

            return resultadoValidacao;
        }
        public virtual List<T> SelecionarTodos()
        {
            return Db.GetAll(SqlSelectAll, new TMapeador().ConverterEmRegistro);
        }
        public virtual T SelecionarPorId(int id)
        {
            var mapa = new TMapeador();
            return Db.Get(SqlSelectId, mapa.ConverterEmRegistro, mapa.AdicionarParametro("ID", id));
        }

    }
}
