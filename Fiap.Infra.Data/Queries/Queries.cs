using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Infra.Data.Queries
{
    public class Queries
    {
        public const string InsertCandidate = @"   
            INSERT INTO
              tbl_candidato (
                tx_cpf,
                tx_email,
                dt_nascimento,
                tx_nome,
                tx_telefone
              )
            VALUES
              (
                :Document,
                :Email,
                :BirthDate,
                :Name,
                :PhoneNumber
              )
        ";

        public const string InsertCandidateSkill = @"
            INSERT INTO
              tbl_skills (tx_descricao, id_tipo, id_candidato)
            VALUES
              (:skill, 1, :candidateId)
        ";

        public const string InsertCandidateCertification = @"
            INSERT INTO
              tbl_certificacao (tx_nivel, tx_nome, id_candidato)
            VALUES
              (10, :certification, :candidateId)
        ";

        public const string GetCandidates = @"
            SELECT
              id_candidato Id,
              tx_cpf Document,
              tx_email Email,
              dt_nascimento BirthDate,
              tx_nome Name,
              tx_telefone PhoneNumber
            FROM
              tbl_candidato c
        ";

        public const string GetCandidatesWithFilter = @"
            SELECT
              DISTINCT c.id_candidato Id,
              c.tx_cpf Document,
              c.tx_email Email,
              c.dt_nascimento BirthDate,
              c.tx_nome Name,
              c.tx_telefone PhoneNumber
            FROM
              tbl_candidato c
              LEFT JOIN tbl_skills s ON s.id_candidato = c.id_candidato
              LEFT JOIN tbl_certificacao ct ON ct.id_candidato = c.id_candidato
            WHERE
              s.tx_descricao = :skill
              OR ct.tx_nome = :certification
        ";

        public const string GetCandidateSkills = @"
            select tx_descricao from tbl_skills where id_candidato = :candidateId
        ";

        public const string GetCandidateCertifications = @"
            select tx_nome from tbl_certificacao where id_candidato = :candidateId
        ";

    }
}
