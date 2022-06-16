using ControleMedicamentos.Dominio.ModuloPaciente;
using ControleMedicamentos.Infra.BancoDados.Shared;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.ModuloPaciente
{
    public class ControladorPaciente : Controlador<Paciente,ValidadorPaciente,MapeadorPaciente>
    {
        protected override string SqlUpdate =>
                @"UPDATE TBPaciente
                   SET Nome = @NOME
                      ,CartaoSUS = @SUS
                 WHERE id = @ID";

        protected override string SqlDelete =>
                @"DELETE FROM TBPaciente
                  WHERE Id = @ID";

        protected override string SqlInsert =>
                @"INSERT INTO TBPaciente
                   (Nome,CartaoSUS)
                  VALUES (@NOME , @SUS);";

        protected override string SqlSelectAll =>
                @"SELECT Id , Nome, CartaoSUS
                  FROM TBPaciente";

        protected override string SqlSelectId =>
                @"SELECT Id , Nome, CartaoSUS
                  FROM TBPaciente
                  WHERE id = @ID";

        protected override string SqlExiste =>
                @"SELECT
                        COUNT(*)
                    FROM 
                        TBPaciente
                    WHERE Id = @ID ;";
    }
}
